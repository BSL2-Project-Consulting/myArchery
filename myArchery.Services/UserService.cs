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

        public static int AddUser(User user, int isActive = 1)
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                db.Users.Add(user);
                return db.SaveChanges();
            }
        }
    }
}