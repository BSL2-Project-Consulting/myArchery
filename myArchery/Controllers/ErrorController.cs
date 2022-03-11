using Microsoft.AspNetCore.Mvc;

namespace myArchery.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
