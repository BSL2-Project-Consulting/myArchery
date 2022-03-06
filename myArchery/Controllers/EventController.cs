using Microsoft.AspNetCore.Mvc;

namespace myArchery.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
