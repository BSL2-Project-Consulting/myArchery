namespace myArchery.Services
{
    public static class EventRoleService
    {
        public static int CreateEveRole(string name)
        {
            EventUserRole role = new EventUserRole
            {
                
            };

            using (myarcheryContext db = new myarcheryContext())
            {
                db.EventUserRoles.Add(role);
                return db.SaveChanges();
            }
        }
    }
}
