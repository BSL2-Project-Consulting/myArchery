using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myArchery.Services
{
    public class ParcourTargetService
    {
        private ArcheryDbContext _context;
        private ParcourService _parcourService;

        public ParcourTargetService(ArcheryDbContext context, ParcourService parcourService)
        {
            _context = context;
            _parcourService = parcourService;
        }
    }
}