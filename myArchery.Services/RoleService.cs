namespace myArchery.Services
{
    public static class RoleService
    {
        /// <summary>
        /// Add Role to Db
        /// </summary>
        /// <param name="name">Name of the Role</param>
        /// <returns>Amount of affected rows</returns>
        public static int AddRole(string name)
        {
            Role role = new Role
            {
                Rolename = name
            };

            using (myarcheryContext db = new myarcheryContext())
            {
                db.Roles.Add(role);
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// Get Role by given id
        /// </summary>
        /// <param name="id">Id that is coresponding with db entry</param>
        /// <returns>Found role or null</returns>

        public static Role? GetRoleById(int id)
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                return db.Roles.FirstOrDefault(x => x.RolId == id);
            }
        }

        /// <summary>
        /// Remove Role by given Id
        /// </summary>
        /// <param name="id">Id that is coresponding with given Id</param>
        /// <returns>Amount of affected Rows</returns>
        public static int RemoveRoleById(int id)
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                var role = GetRoleById(id);
                if (role != null)
                {
                    db.Roles.Remove(role);
                    return db.SaveChanges();
                }
                return 0;
            }
        }
    }
}
