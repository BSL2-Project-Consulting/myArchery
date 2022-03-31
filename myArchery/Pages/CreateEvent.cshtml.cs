using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myArchery.Services;

namespace myArchery.Pages
{
    public class CreateEventModel : PageModel
    {
        private Event newEvent;
        private int state;
        private List<int> bodyList;
        private List<int> lifeList;
        private List<int> killList;
        private List<int> centerKillList;

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
        public int CenterKill { get; set; } = 0;
        [Required]
        [BindProperty]
        public int Kill { get; set; } = 0;
        [Required]
        [BindProperty]
        public int Life { get; set; } = 0;
        [Required]
        [BindProperty]
        public int Body { get; set; } = 0;

        public List<int> CenterKillList { get => centerKillList; set => centerKillList = value; }
        public List<int> KillList { get => killList; set => killList = value; }
        public List<int> LifeList { get => lifeList; set => lifeList = value; }
        [Required]
        public List<int> BodyList { get => bodyList; set => bodyList = value; }

        [BindProperty]
        public int State { get => state; set => state = value; }

        public Event NewEvent { get => newEvent; set => newEvent = value; }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("---- Event Erstellen Methode");
            if (User.Identity == null)
            {
                return RedirectToPage("./Login");
            }
            else
            {
                if (State == 0)
                {
                    NewEvent = new Event
                    {
                        Eventname = EventName,
                        Startdate = StartDate,
                        Enddate = EndDate,
                        Arrowamount = ArrowAmount
                    };

                    State = 1;
                }
                else if (State == 1)
                {
                    if (CenterKillList.Count + 1 <= ArrowAmount)
                    {
                        State = 2;
                        // Fill List
                        CenterKillList.Add(CenterKill);
                        CenterKill = 0;

                        KillList.Add(Kill);
                        Kill = 0;

                        LifeList.Add(Life);
                        Life = 0;

                        BodyList.Add(Body);
                        Body = 0;
                    }
                    else
                    {
                        State = 2;
                    }
                }
                else if (State == 2)
                {
                    // Generate Event and Points and Add Current User as Creator

                }
            }
        }
    }
}