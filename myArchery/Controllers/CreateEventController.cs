using Microsoft.AspNetCore.Mvc;

namespace myArchery.Controllers
{
    public class CreateEventController : Controller
    {
        public IActionResult Index()
        {
            Console.WriteLine("Create Event Controller");
            return View();
        }
    }
}
