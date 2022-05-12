using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myArchery.Services
{
    public class TargetService
    {
        public TargetService(ArcheryDbContext context)
        {
            _context = context;
        }

        public ArcheryDbContext _context { get; }

        public Target GetTargetById(int id)
        {
            var target = _context.Targets.FirstOrDefault(x => x.TarId == id);
            return target;
        }
    }
}
