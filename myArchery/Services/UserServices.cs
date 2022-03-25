using myArchery.Data;
using myArchery.Persistance.Models;

namespace myArchery.Services
{
    public class UserServices
    {
        public UserServices(myArcheryContext context)
        {
            Context = context;
        }

        public myArcheryContext Context { get; }

        public List<User> GetAllUsers()
        {
            return Context.Users.ToList();
        }
    }
}
