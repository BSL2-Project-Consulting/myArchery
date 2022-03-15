using Microsoft.AspNetCore.Mvc;
using myArchery.Persistance;
using myArchery.Services;

namespace myArchery.Controllers
{
    public class LoginController : Controller
    {
        private readonly myarcheryContext _db;

        public LoginController(myarcheryContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            Console.WriteLine("Login");
            return View();
        }

        public async Task<IActionResult> Register()
        {
            Console.WriteLine("Register");
            // get all inputs
            


            // check if user exists with given properties

            string vname = "";
            string nname = "";
            string username = "";
            string email = "";
            string password = "";
            int getNewsletter = 0;

            if (await UserService.UserExists(username, email))
            {
                //User does exist
                return View("Login");
            }
            else
            {
                //User doesn't exist in the db

                await UserService.AddUser(vname, nname, username, email, password.ConvertToSha256(), getNewsletter);
                ViewBag.Username = username;

                return View("Index");
            }
        }
    }
}
