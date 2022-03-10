using myArchery.Persistance.Models;

namespace myArchery.Services
{
    public static class UserService
    {
        public static User? GetUserByName(string name)
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                return db.Users.FirstOrDefault(x => x.Username == name && x.Isactive == 1);
            }
        }

        public static int AddUser(string vname,string nname,string username,string email,string password)
        {
            User user = new User();
            using (myarcheryContext db = new myarcheryContext())
            {
                db.Users.Add(user);
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// Checks the db if a given user with email or username exists
        /// </summary>
        /// <param name="username">username that is bound to a user</param>
        /// <param name="email">email adress that is bound to a user</param>
        /// <returns>true when user does exist. false when user doesnt exist</returns>
        public static bool UserExists(string username, string email)
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Username == username || x.Email == email);
                return user != null;
            }
        }
    }
}