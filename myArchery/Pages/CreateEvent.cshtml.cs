using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myArchery.Services;

namespace myArchery.Pages
{
    public class CreateEventModel : PageModel
    {
        public CreateEventModel(UserManager<AspNetUser> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<AspNetUser> UserManager { get; }

        [BindProperty]
        public string EventName { get; set; }

        [BindProperty]
        public int ArrowAmount { get; set; }

        [BindProperty]
        public DateTime StartDate { get; set; }

        [BindProperty]
        public DateTime EndDate { get; set; }

        [BindProperty]
        public string Parcourname { get; set; }

        [BindProperty]
        public int CenterKill { get; set; }
        [BindProperty]
        public int Kill { get; set; }
        [BindProperty]
        public int Life { get; set; }
        [BindProperty]
        public int Body { get; set; }


        public void OnGet()
        {

        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var getEvent = EventService.GetAllPublicEvents();
        //    }
        //}
    }
}