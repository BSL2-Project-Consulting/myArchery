using Microsoft.AspNetCore.Mvc;
using myArchery.Services;

namespace myArchery.Controllers
{
    public class LiveRankingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //GET: get all Liveranking datas as JSON
        // Liveranking/GetLiverankingDataAsJson/{id}
        public string GetLiverankingDataAsJson(int id)
        {
            return Utility.ConvertListToJson(EventService.GetUsersWithPointsFromEventById(id));
        }
    }
}
