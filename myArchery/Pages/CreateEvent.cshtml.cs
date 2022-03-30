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
        [Required]
        [BindProperty]
        public string EventName { get; set; }
        [Required]
        [BindProperty]
        public int ArrowAmount { get; set; } = 3;
        [Required]
        [BindProperty]
        public DateTime StartDate { get; set; }
        [Required]
        [BindProperty]
        public DateTime EndDate { get; set; }
        [Required]
        [BindProperty]
        public string Parcourname { get; set; }
        [Required]
        [BindProperty]
        public List<int> CenterKill { get; set; }
        [Required]
        [BindProperty]
        public int Kill { get; set; }
        [Required]
        [BindProperty]
        public int Life { get; set; }
        [Required]
        [BindProperty]
        public int Body { get; set; }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (User.Identity == null)
            {
                return RedirectToPage("./Login");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var getEvent = EventService.GetAllPublicEvents().Where(x => x.Eventname == EventName);
                    if (getEvent.Any())
                    {
                        ModelState.AddModelError(string.Empty, $"Es existiert ein Event mit dem Namen {EventName}");
                        return Page();
                    }
                    else
                    {
                        List<Point> pointList = new List<Point>();
                        await EventService.CreateEventAndAddCreator(eventName: EventName, arrowAmount: ArrowAmount, StartDate, EndDate, 0, null, ParcourService.GetParcourIdByName(Parcourname), pointList, UserService.GetUserByName(User.Identity.Name).Id);
                        return RedirectToPage("./Index");
                    }
                }
            }
            return Page();
        }
    }
}