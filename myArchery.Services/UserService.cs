using Microsoft.EntityFrameworkCore;

namespace myArchery.Services
{
    public class UserService
    {

        public static List<User> GetAllUsers()
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                return db.Users.ToList();
            }
        }

        public static ICollection<User>? GetUsersInEventById(int id)
        {
            using (myarcheryContext db = new myarcheryContext())
            {

                // FUCKING TODO

                return null;
            }
        }

        public static User? GetUserByName(string name)
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                return db.Users.FirstOrDefault(x => x.Username == name && x.Isactive == 1);
            }
        }       

        public static async Task<int> AddUser(string vname,string nname,string username,string email,string password, int getNewsletter)
        {
            User user = new()
            {
                Vname = vname,
                Nname = nname,
                Username = username,
                Email = email,
                Password = password,
                Isactive = 1,
                Getnewsletter = getNewsletter
            };
            
            using (myarcheryContext db = new myarcheryContext())
            {
                db.Users.Add(user);
                return await db.SaveChangesAsync();
            }
        }

        public static async Task<User?> ModifyUser(int id, string? vname = null, string? nname = null, string? username = null, string? email = null, string? password = null, int getNewsletter = 0)
        {
            var user = await GetUserById(id);
            if (user != null)
            {
                user.Vname = vname ?? user.Vname;
                user.Nname = nname ?? user.Nname;
                user.Username = username ?? user.Username;
                user.Email = email ?? user.Email;
                user.Password = password ?? user.Password;
                user.Getnewsletter = getNewsletter;

                using (myarcheryContext db = new myarcheryContext())
                {
                    db.Users.Update(user);
                    await db.SaveChangesAsync();
                    return user;
                }
            }           
            return null;
        }

        /// <summary>
        /// Get User by id
        /// </summary>
        /// <param name="id">Id that is coresponding with a user</param>
        /// <returns>Found user or null</returns>
        public static async Task<User?> GetUserById(int id)
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                var tmp = await db.Users.FirstOrDefaultAsync(x => x.UseId == id);
                return tmp;
            }
        }

        /// <summary>
        /// Checks the db if a given user with email or username exists
        /// </summary>
        /// <param name="username">username that is bound to a user</param>
        /// <param name="email">email adress that is bound to a user</param>
        /// <returns>true when user does exist. false when user doesnt exist</returns>
        public static async Task<bool> UserExists(string? username = null, string? email = null)
        {            
            using (myarcheryContext db = new myarcheryContext())
            {
                var user = await db.Users.FirstOrDefaultAsync(x => x.Username == username || x.Email == email);
                return user != null;
            }
        }


        /// <summary>
        /// "Remove" User by removing vname, nname, email, setting password to null and adding "//del//" as prefix to the username
        /// </summary>
        /// <param name="id">Id that is coresponding with the user in the db</param>
        /// <returns>Amount of affected rows</returns>
        public static async Task<int> RemoveUserById(int id)
        {
            var user = await GetUserById(id);
            if (user != null)
            {
                await ModifyUser(id, username: "//del//" + user.Username);
                
                using (myarcheryContext db = new myarcheryContext())
                {
                    db.Users.Update(user);
                    return await db.SaveChangesAsync();
                }
            }

            return 0;


        }
    }
}