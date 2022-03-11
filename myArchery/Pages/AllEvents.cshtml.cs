using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace myArchery.Pages.AllEvents
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        private readonly myarcheryContext _context;

        public CurrentEventModel(myarcheryContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get; set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Events
                .Include(x => x.Par).ToListAsync();
        }
    }
}