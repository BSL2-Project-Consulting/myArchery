using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myArchery.Persistance.Models;
using myArchery.Services;

namespace myArchery.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public UserManager<User> UserManager { get; }

        public IndexModel(ILogger<IndexModel> logger, UserManager<User> userManager)
        {
            _logger = logger;
            UserManager = userManager;
        }


        public void OnGet()
        {

        }
    }
}