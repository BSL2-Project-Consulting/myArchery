using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace myArchery.Pages
{
    public class LiveRankingModel : PageModel
    {
        public UserManager<AspNetUser> UserManager { get; }

        public LiveRankingModel(UserManager<AspNetUser> userManager)
        {
            UserManager = userManager;
        }

        public void OnGet()
        {
        }
    }
}
