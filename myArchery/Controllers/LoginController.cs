using Microsoft.AspNetCore.Mvc;
<<<<<<< Updated upstream
=======
using myArchery.Persistance;
using myArchery.Persistance.Models;
>>>>>>> Stashed changes
using myArchery.Services;

namespace myArchery.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
<<<<<<< Updated upstream
            // get all inputs

            // check if user exists with given properties

            string vname = "";
            string nname = "";
            string username = "";
            string email = "";
            string password = "";

            if (UserService.UserExists(username, email))
            {
                //User does exist
                return RedirectToAction("Index");
            }
            else
            {
                //User doesn't exist in the db
                
                UserService.AddUser(vname, nname, username, email, password.ConvertToSha256());
                ViewBag.Username = username;
                
                return View();
            }            
=======
            Console.WriteLine("Login");
            return View();
        }

        public IActionResult Forgot_Password()
        {
            Console.WriteLine("Forgot Password");

            return RedirectToPage("./Index");
>>>>>>> Stashed changes
        }
    }
}
