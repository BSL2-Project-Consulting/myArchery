using Microsoft.AspNetCore.Mvc;
using myArchery.Services;

namespace myArchery.Controllers
{
    public class LiveRankingController : Controller
    {
        private EventService _eventService;

        public LiveRankingController(EventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //GET: get all Liveranking datas as JSON
        // Liveranking/GetLiverankingDataAsJson/{id}
        public string GetLiverankingDataAsJson(int id)
        {
            return Utility.ConvertListToJson(_eventService.GetUsersWithPointsFromEventById(id));
        }
    }
}
