using Microsoft.AspNetCore.Mvc;

namespace myArchery.Controllers
{
    public class tosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
