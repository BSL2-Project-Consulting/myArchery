#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly myarcheryContext _context;

        public LoginModel(myarcheryContext context)
        {
            _context = context;

            foreach (var item in UserService.GetAllUsers())
            {
                Console.WriteLine(item.Username);
            }
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public new User User { get; set; } = new User();

        [BindProperty]
        public bool GetNewsletterChecked { get; set; }

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

                    using (myarcheryContext db = new myarcheryContext())
                    {
                        foreach (var item in db.Users)
                        {
                            Console.WriteLine(item.Username);
                        }
                    }

                    return RedirectToAction("../Index");
                }
                else
                {
                    Console.WriteLine("User exists");
                    return RedirectToPage();
                }
                
            }
        }
    }
}