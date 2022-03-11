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
            // get all inputs

            // check if user exists with given properties

            string vname = "";
            string nname = "";
            string username = "";
            string email = "";
            string password = "";
            bool getNewsletter = false;

            if (UserService.UserExists(username, email))
            {
                //User does exist
                return RedirectToAction("Index");
            }
            else
            {
                //User doesn't exist in the db

                UserService.AddUser(vname, nname, username, email, password.ConvertToSha256(), getNewsletter);
                ViewBag.Username = username;

                return View();
            }
        }
    }
}
