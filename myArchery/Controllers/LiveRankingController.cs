using Microsoft.AspNetCore.Mvc;

namespace myArchery.Controllers
{
    public class LiveRankingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
