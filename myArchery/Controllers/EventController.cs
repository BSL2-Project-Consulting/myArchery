using Microsoft.AspNetCore.Mvc;

namespace myArchery.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
