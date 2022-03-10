using Microsoft.AspNetCore.Mvc;

namespace myArchery.Controllers
{
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            Console.WriteLine("Test");

            return View();
        }
    }
}
