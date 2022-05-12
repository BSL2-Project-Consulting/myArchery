using Microsoft.EntityFrameworkCore;

namespace myArchery.Services
{
    public class EventRoleService
    {
        private ArcheryDbContext _context;

        public EventRoleService(ArcheryDbContext context)
        {
            _context = context;
        }

        public int CreateEveRole(string name)
        {
            EventUserRole role = new EventUserRole
            {
                
            };

            using (ArcheryDbContext db = new ArcheryDbContext())
            {
                db.EventUserRoles.Add(role);
                return db.SaveChanges();
            }
        }

        public EventUserRole GetEventRole(int eve_id, string use_id)
        {
            var tmp = _context.EventUserRoles.Include(x => x.Use).Include(x => x.Eve).First(x => x.EveId == eve_id && x.UseId == use_id);
            return tmp;
        }
    }
}