#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using myArchery.Persistance;
using myArchery.Persistance.Models;

namespace myArchery.Pages
{
    public class CurrentEventModel : PageModel
    {

        public UserManager<AspNetUser> UserManager { get; }

        public CurrentEventModel(UserManager<AspNetUser> userManager)
        {
            UserManager = userManager;
        }

        public void OnGet()
        {

        }
    }
}