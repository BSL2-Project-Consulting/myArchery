using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myArchery.Persistance;
using myArchery.Persistance.Models;

namespace myArchery.Pages.AllEvents
{
    public class IndexModel : PageModel
    {
        public IndexModel()
        {

        }

        public IList<Event> Event { get; set; } = new List<Event>();

        public async Task OnGetAsync()
        {
            using (ArcheryDbContext db = new ArcheryDbContext())
            {
                Event = await db.Events.Include(x => x.Par).Where(x => x.Startdate < DateTime.Now && x.Enddate > DateTime.Now).ToListAsync();
            }
        }
    }
}