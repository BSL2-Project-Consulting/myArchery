using Microsoft.AspNetCore.Mvc;
using myArchery.Persistance;

using myArchery.Persistance.Models;

using myArchery.Services;

namespace myArchery.Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {

        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Forgot_Password()
        {
            Console.WriteLine("Forgot Password");

            return RedirectToPage("./Index");
        }

        
    }
}
