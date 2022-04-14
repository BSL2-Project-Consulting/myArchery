using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myArchery.Services
{
    public class PointService
    {
        private ArcheryDbContext _context;

        public PointService(ArcheryDbContext context)
        {
            _context = context;
        }

        public Point GetPoint(int eve_id, int value_id, int arrowNumber)
        {
            return _context.Points.Where(x => x.EveId.Equals(eve_id) && x.ValueId == value_id && x.ArrowNumber == arrowNumber).First();
        }
    }
}
