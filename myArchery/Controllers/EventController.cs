using Microsoft.AspNetCore.Mvc;

namespace myArchery.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            if (ViewData["Username"] != null)
            {
                return View();
            }
            else
            {
                return View("Login");
            }
        }
    }
}
