#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using myArchery.Persistance;
using myArchery.Persistance.Models;

namespace myArchery.Pages
{
    public class CurrentEventModel : PageModel
    {
        private readonly myarcheryContext _context;

        public CurrentEventModel(myarcheryContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Events
                .Include(x => x.Par).ToListAsync();
        }
    }
}