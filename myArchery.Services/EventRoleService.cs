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
            return _context.EventUserRoles.Where(x => x.EveId == eve_id && use_id.Equals(use_id)).First();                         
        }
    }
}