#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
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
        public LoginModel()
        {
            Console.WriteLine("All users in the DB:");
            foreach (var item in UserService.GetAllUsers())
            {
                Console.WriteLine(item.Username);
            }
        }

        public IActionResult OnGet()
        {
            Console.WriteLine($"Username Cookie is: {Request.Cookies["Username"]}");
            return Page();
        }

        [BindProperty]
        public User RegisterUser { get; set; } = new User();

        [BindProperty]
        public User LoginUser { get; set; } = new User();

        [BindProperty]
        public bool GetNewsletterChecked { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }

        public IActionResult Register()
        {
            Console.WriteLine("---- Register Method");

            if (RegisterUser != null && RegisterUser.Username != null)
            {
                Console.WriteLine("---- Registered");
                if (!UserService.UserExists(RegisterUser.Username).GetAwaiter().GetResult())
                {
                    int tmpNewsletter;
                    if (GetNewsletterChecked == true) tmpNewsletter = 1;
                    else tmpNewsletter = 0;

                    var addUserRes = UserService.AddUser(RegisterUser.Vname, RegisterUser.Nname, RegisterUser.Username, RegisterUser.Email, RegisterUser.Password.ConvertToSha256(), tmpNewsletter);
                    addUserRes.GetAwaiter().GetResult();
                    Console.WriteLine($"Added {RegisterUser.Username} to db.");

                    using (myarcheryContext db = new myarcheryContext())
                    {
                        foreach (var item in db.Users)
                        {
                            Console.WriteLine(item.Username);
                        }
                    }

                    RedirectToPage("Index");
                }
                else
                {
                    Console.WriteLine("User exists");
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
            }
        }
    }
}