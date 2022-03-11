using Microsoft.AspNetCore.Mvc;

namespace myArchery.Controllers
{
    public class ViewEventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
