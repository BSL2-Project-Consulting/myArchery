using Microsoft.EntityFrameworkCore;

namespace myArchery.Services
{
    public class UserService
    {

        public static List<AspNetUser> GetAllUsers()
        {
            using (ArcheryDbContext db = new())
            {
                return db.AspNetUsers.ToList();
            }
        }

        public static ICollection<AspNetUser>? GetUsersInEventById(int id)
        {
            using (ArcheryDbContext db = new ArcheryDbContext())
            {

                // FUCKING TODO

                return null;
            }
        }

        public static AspNetUser? GetUserById(string userId)
        {
            using (ArcheryDbContext db = new ArcheryDbContext())
            {
                return db.AspNetUsers.FirstOrDefault(x => x.Id == userId);
            }
        }

        public static AspNetUser? GetUserByName(string name)
        {
            using (ArcheryDbContext db = new ArcheryDbContext())
            {
                return db.AspNetUsers.FirstOrDefault(x => x.UserName == name);
            }
        }       
    }
}