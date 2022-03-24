namespace myArchery.Services
{
    public static class EventRoleService
    {
        public static int CreateEveRole(string name)
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
    }
}
