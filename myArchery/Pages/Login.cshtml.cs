#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using myArchery.Persistance;
using myArchery.Persistance.Models;
using myArchery.Services;

namespace myArchery.Pages
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public User RegisterUser { get; set; } = new User();

        [BindProperty]
        public User LoginUser { get; set; } = new User();
        public new User User { get; set; } = new User();

        [BindProperty]
        public bool GetNewsletterChecked { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }
        
        public UserManager<User> UserManager { get; }
        
        public SignInManager<User> SignInManager { get; }


        public LoginModel(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public IActionResult OnGet()
        {
            //Console.WriteLine(username + " is logged in.");
            return Page();
        }

        public async Task<IActionResult> OnPostLoginAsync()
        {
            Console.WriteLine("---- Login Method");
            Console.WriteLine($"Username Cookie is: {Request.Cookies["Username"]}");
            if (LoginUser.Username == "" || LoginUser.Password == "" || LoginUser.Password == null || LoginUser.Username == null)
            {
                Console.WriteLine("Password or User Incorrect");
            }

            var tmpUser = UserService.GetUserByName(LoginUser.Username);
            if (tmpUser == null)
            {
                Console.WriteLine("Password or User Incorrect");
                return Page();
            }
            else if (tmpUser.Password != LoginUser.Password.ConvertToSha256())
            {
                Response.WriteAsync("Password incorrect").GetAwaiter().GetResult();
                return Page();
            }
            else
            {
                if (RememberMe == true)
                {
                    Response.Cookies.Delete("Username");
                    Response.Cookies.Append("Username", LoginUser.Username, new CookieOptions { Expires = DateTime.MaxValue });

                    Console.WriteLine("Request Cookie:" + Request.Cookies["Username"]);

                }
                else
                {
                    Response.Cookies.Delete("Username");
                    Response.Cookies.Append("Username", LoginUser.Username, new CookieOptions { Expires = DateTime.Now.AddDays(-1) });

                    Console.WriteLine("Request Cookie:" + Request.Cookies["Username"]);
                }

                Console.WriteLine("---- Logged in as: " + LoginUser.Username);
                Console.WriteLine("---- Redirect in Progress");
                return RedirectToPage("Index");
                //return RedirectToAction(actionName: "Index", controllerName: "Home/Index");
            }
        }

        //public IActionResult OnPostRegisterAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        Console.WriteLine("Input is invalid");
        //        return Page();
        //    }
        //    else
        //    {
        //        Console.WriteLine("--- Registered");
        //        if (!UserService.UserExists(User.Username).GetAwaiter().GetResult())
        //        {
        //            int tmpNewsletter;
        //            if (GetNewsletterChecked == true) tmpNewsletter = 1;
        //            else tmpNewsletter = 0;

        //            UserService.AddUser(User.Vname, User.Nname, User.Username, User.Email, User.Password.ConvertToSha256(), tmpNewsletter).GetAwaiter().GetResult();
        //            Console.WriteLine($"Added {User.Username} to db.");


        //            using (myarcheryContext db = new myarcheryContext())
        //            {
        //                foreach (var item in db.Users)
        //                {
        //                    Console.WriteLine(item.Username);
        //                }
        //            }

        //            RedirectToPage("Index");
        //            return RedirectToAction("../Index");
        //        }
        //        else
        //        {
        //            Console.WriteLine("User exists");
        //        }
        //    }
        //    return RedirectToPage("Index");
        //}
                
        public async Task<IActionResult> OnPostRegisterAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = LoginUser.Username,
                    Vname = LoginUser.Vname,
                    Nname = LoginUser.Nname,
                    Email = LoginUser.Email,
                    Password = LoginUser.Password,                    
                    PasswordHash = LoginUser.Password.ConvertToSha256(),
                    Username = LoginUser.Username,
                    Getnewsletter = LoginUser.Getnewsletter
                };

                if (!UserService.UserExists(username: User.Username, email: User.Email).GetAwaiter().GetResult())
                {
                    var result = UserManager.CreateAsync(user, LoginUser.Password.ConvertToSha256());
                    if (result.IsCompletedSuccessfully)
                    {
                        Console.WriteLine("User created Successfully");
                        await UserService.AddUser(User.Vname, User.Nname, User.Username, User.Email, User.Password.ConvertToSha256(), Convert.ToInt32(GetNewsletterChecked));
                        await SignInManager.SignInAsync(user, RememberMe);

                        Console.WriteLine(SignInManager);
                        return RedirectToPage("../Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", result.Exception.Message);
                    }
                }
                else
                {
                    // User already exists in DB
                    Console.WriteLine($"{User.UserName} already exists in the DB");
                }
            }
            else
            {
                Console.WriteLine("Modelstate is invalid");
            }
            return Page();
        }
    }
}