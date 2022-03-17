#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
=======
>>>>>>> development
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
<<<<<<< HEAD
        public LoginModel()
        {
            Console.WriteLine("All users in the DB:");
=======
        private readonly myarcheryContext _context;

        public LoginModel(myarcheryContext context)
        {
            _context = context;

>>>>>>> development
            foreach (var item in UserService.GetAllUsers())
            {
                Console.WriteLine(item.Username);
            }
        }

        public IActionResult OnGet()
        {
<<<<<<< HEAD
            Console.WriteLine($"Username Cookie is: {Request.Cookies["Username"]}");
=======
>>>>>>> development
            return Page();
        }

        [BindProperty]
<<<<<<< HEAD
        public User RegisterUser { get; set; } = new User();

        [BindProperty]
        public User LoginUser { get; set; } = new User();
=======
        public new User User { get; set; } = new User();
>>>>>>> development

        [BindProperty]
        public bool GetNewsletterChecked { get; set; }

<<<<<<< HEAD
        [BindProperty]
        public bool RememberMe { get; set; }

        public IActionResult Register()
        {
            Console.WriteLine("---- Register Method");

            if (RegisterUser != null && RegisterUser.Username != null)
            {
                Console.WriteLine("---- Registered");
                if (!UserService.UserExists(RegisterUser.Username))
                {
                    int tmpNewsletter;
                    if (GetNewsletterChecked == true) tmpNewsletter = 1;
                    else tmpNewsletter = 0;

                    var addUserRes = UserService.AddUser(RegisterUser.Vname, RegisterUser.Nname, RegisterUser.Username, RegisterUser.Email, RegisterUser.Password.ConvertToSha256(), tmpNewsletter);
                    
                    Console.WriteLine($"Added {RegisterUser.Username} to db.");
=======
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnLoginAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            ViewData["Username"] = User.Username;
            await UserService.AddUser(User.Vname, User.Nname, User.Username, User.Email, User.Password.ConvertToSha256(), User.Getnewsletter);
            Console.WriteLine("----- Logged in");
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnRegisterAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Input is invalid");
                return Page();
            }
            else
            {
                Console.WriteLine("--- Registered");
                if (!UserService.UserExists(User.Username).GetAwaiter().GetResult())
                {
                    int tmpNewsletter;
                    if (GetNewsletterChecked == true) tmpNewsletter = 1;
                    else tmpNewsletter = 0;                    

                    await UserService.AddUser(User.Vname, User.Nname, User.Username, User.Email, User.Password.ConvertToSha256(), tmpNewsletter);
                    Console.WriteLine($"Added {User.Username} to db.");
                    await _context.SaveChangesAsync();
>>>>>>> development

                    using (myarcheryContext db = new myarcheryContext())
                    {
                        foreach (var item in db.Users)
                        {
                            Console.WriteLine(item.Username);
                        }
                    }

<<<<<<< HEAD
                    RedirectToPage("Index");
=======
                    return RedirectToAction("../Index");
>>>>>>> development
                }
                else
                {
                    Console.WriteLine("User exists");
<<<<<<< HEAD
                }
            }
            return RedirectToPage("Index");
        }

        public IActionResult Login()
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
                    Response.Cookies.Append("Username", LoginUser.Username, new CookieOptions { Expires = DateTime.MaxValue});

                    Console.WriteLine("Request Cookie:" + Request.Cookies["Username"]);

                }
                else
                {
                    Response.Cookies.Delete("Username");
                    Response.Cookies.Append("Username", LoginUser.Username, new CookieOptions { Expires = DateTime.Now.AddDays(-1)});

                    Console.WriteLine("Request Cookie:" + Request.Cookies["Username"]);
                }

                Console.WriteLine("---- Logged in as: " + LoginUser.Username);
                Console.WriteLine("---- Redirect in Progress");
                return RedirectToPage("/Index/View");
                //return RedirectToAction(actionName: "Index", controllerName: "Home/Index");
=======
                    return RedirectToPage();
                }
                
>>>>>>> development
            }
        }
    }
}