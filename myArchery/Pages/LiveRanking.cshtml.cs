using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace myArchery.Pages
{
    public class LiveRankingModel : PageModel
    {
        public UserManager<User> UserManager { get; }

        public LiveRankingModel(UserManager<User> userManager)
        {
            UserManager = userManager;
        }

        public void OnGet()
        {
        }
    }
}
