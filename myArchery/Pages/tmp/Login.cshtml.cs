#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
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

        [BindProperty]
        public bool GetNewsletterChecked { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }
        
        //public UserManager<AspNetUser> UserManager { get; }
        
        //public SignInManager<AspNetUser> SignInManager { get; }


        //public LoginModel(UserManager<AspNetUser> userManager, SignInManager<AspNetUser> signInManager)
        //{
        //    UserManager = userManager;
        //    SignInManager = signInManager;
        //}

        public IActionResult OnGet()
        {
            Console.WriteLine($"Username Cookie is: {Request.Cookies["Username"]}");
            return Page();
        }

        public IActionResult OnPostLoginAsync()
        {
            Console.WriteLine("---- Login Method");
            Console.WriteLine($"Logged in User is: {User.Identity.Name}");
            if (LoginUser.UserName == string.Empty || LoginUser.Password == string.Empty || LoginUser.Password == null || LoginUser.UserName == null)
            {
                Console.WriteLine("Password or User Incorrect");
                return Page();
            }
            
            //var result = await SignInManager.PasswordSignInAsync(LoginUser.UserName, LoginUser.Password, RememberMe, lockoutOnFailure: false);
            return RedirectToPage("Index");
            //return RedirectToAction(actionName: "Index", controllerName: "Home/Index");
            
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

        public IActionResult OnPostRegisterAsync()
        {
            if (ModelState.IsValid && RegisterUser.Password != String.Empty && RegisterUser.Password != null)
            {
                var user = new myArchery.Persistance.Models.User()
                {
                    UserName = RegisterUser.UserName,
                    Vname = RegisterUser.Vname,
                    Nname = RegisterUser.Nname,
                    Email = RegisterUser.Email,
                    Password = RegisterUser.Password,                    
                    PasswordHash = RegisterUser.Password.ConvertToSha256(),
                    Getnewsletter = RegisterUser.Getnewsletter,
                    Isactive = 1
                };

                //if (!await UserService.UserExists(username: RegisterUser.UserName, email: RegisterUser.Email))
                //{
                //    //var result = UserManager.CreateAsync(user, RegisterUser.Password.ConvertToSha256());
                //    //if (result.IsCompletedSuccessfully)
                //    //{
                //    //    Console.WriteLine("User created Successfully");
                //    //    await UserService.AddUser(RegisterUser.Vname, RegisterUser.Nname, RegisterUser.UserName, RegisterUser.Email, RegisterUser.Password.ConvertToSha256(), Convert.ToInt32(GetNewsletterChecked));
                //    //    await SignInManager.SignInAsync(user, RememberMe);

                //    //    Console.WriteLine(SignInManager);
                //    return RedirectToPage("./Index");
                //    //}
                //    //else
                //    //{
                //    //    ModelState.AddModelError("", result.Exception.Message);
                //    //}
                //}
                //else
                //{
                //    // User already exists in DB
                //    Console.WriteLine($"{RegisterUser.UserName} already exists in the DB");

                //}

            }

            return Page();
        }
    }
}