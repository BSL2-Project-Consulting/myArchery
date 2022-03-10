using Microsoft.AspNetCore.Mvc;
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
        }
    }
}
