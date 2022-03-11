using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myArchery.Persistance;
using myArchery.Persistance.Models;

namespace myArchery.Pages.AllEvents
{
    public class AllEventsModel : PageModel
    {
        private readonly myarcheryContext _context;

        public AllEventsModel(myarcheryContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get; set; } = new List<Event>();

        public async Task OnGetAsync()
        {
            Event = await _context.Events
                .Include(x => x.Par).ToListAsync();
        }

        public void OnGet()
        {

        }
    }
}