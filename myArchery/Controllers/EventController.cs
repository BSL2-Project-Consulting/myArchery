using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using myArchery.Hubs;
using myArchery.Services;
using myArchery.Services.TmpClasses;

namespace myArchery.Controllers
{
    public class EventController : Controller
    {
        private readonly EventService _eventService;
        private readonly ParcourService _parcourService;
        private readonly ArrowService _arrowService;
        private readonly IHubContext<LiverankingHub> _hubContext;

        public EventController(EventService eventService, ParcourService parcourService, ArrowService arrowService, IHubContext<LiverankingHub> hubContext)
        {
            _eventService = eventService;
            _parcourService = parcourService;
            _arrowService = arrowService;
            _hubContext = hubContext;
        }
        // GET: EventController
        public ActionResult Index()
        {
            var test = EventService.GetAllPublicEvents();
            return View(test);
        }

        //GET: EventController/AllEvents
        public ActionResult AllEvents()
        {
            var tmp = EventService.GetAllPublicEvents();
            return View(tmp);
        }

        // POST: EventController/Join/ABCDEFG
        public ActionResult Join(int eventId, string username)
        {
            var isInEvent = EventService.UserIsInEvent(eventId, username);
            // add user to event with join code

            if (isInEvent == false)
            {
                EventService.JoinEvent(eventId, username);
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult JoinWithCode(int eventId, string username, string code)
        {
            var isInEvent = EventService.UserIsInEvent(eventId, username);
            // add user to event with join code

            if (isInEvent == false)
            {
                EventService.JoinEvent(eventId, username, code);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: EventController/Details/5
        public ActionResult Details(int id)
        {
            var events = EventService.GetEventById(id);
            return View(events);
        }

        // GET: EventController/Create
        public ActionResult Create()
        {
            return View(new CreateEventTemplate { Arrowamount = 1, Startdate = DateTime.Parse(DateTime.Now.ToShortDateString()), Enddate = DateTime.Parse(DateTime.Now.AddHours(2).ToShortDateString()) });
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            string userName = User.Identity.Name;

            try
            {
                Event newEvent = new()
                {
                    Eventname = collection["EventName"],
                    Startdate = DateTime.Parse(collection["Startdate"]),
                    Enddate = DateTime.Parse(collection["EndDate"]),
                    Arrowamount = Convert.ToInt32(collection["Arrowamount"]),
                    Isprivat = 0,
                    Password = null,
                    ParId = _parcourService.GetParcourIdByName(collection["ParId"])
                };

                for (int i = 6; i < collection.Count-1; i+=3)
                {
                    int currentIndex = i - 6;
                    string centerkillVal = "centerkill" + currentIndex;
                    string killVal = "kill" + currentIndex;
                    string bodyVal = "body" + currentIndex;

                    Point centerKill = new Point();
                    Point kill = new Point();
                    Point body = new Point();
                    Point nohit = new Point();

                    centerKill.ArrowNumber = currentIndex+1;
                    kill.ArrowNumber = currentIndex+1;
                    body.ArrowNumber = currentIndex+1;
                    nohit.ArrowNumber = currentIndex+1;


                    _ = int.TryParse(collection[$"Points[{currentIndex}].CenterkillValue"], out int result1);
                    centerKill.ValueId = 1;
                    centerKill.Value = result1;

                    _ = int.TryParse(collection[$"Points[{currentIndex}].KillValue"], out int result2);
                    kill.ValueId = 2;
                    kill.Value = result2;

                    _ = int.TryParse(collection[$"Points[{currentIndex}].BodyValue"], out int result3);
                    body.ValueId = 3;
                    body.Value = result3;

                    nohit.ValueId = 4;
                    nohit.Value = 0;

                    newEvent.Points.Add(centerKill);
                    newEvent.Points.Add(kill);
                    newEvent.Points.Add(body);
                    newEvent.Points.Add(nohit);                    
                }

                using (ArcheryDbContext db = new ArcheryDbContext())
                {
                    db.Events.Add(newEvent);
                    db.SaveChanges();
                }


                using (ArcheryDbContext db = new ArcheryDbContext())
                {
                    var res = db.Events.First(x => x.Equals(newEvent));
                    var user = UserService.GetUserByName(userName);

                    EventUserRole eventUserRole = new EventUserRole { EveId = res.EveId, UseId = user.Id, RolId = 1 };

                    db.EventUserRoles.Add(eventUserRole);

                    db.SaveChanges();
                }

                Console.WriteLine("---- Event successfully created");
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        // GET: EventController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(EventService.GetEventById(id));
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                EventService.RemoveEvent(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventController/Currentevent/{id}
        public ActionResult CurrentEvent(int id)
        {
            var _event = EventService.GetEventById(id);
            var list = _eventService.GetUsersCurrentTargetInEvent(id, User.Identity.Name);

            if (list == null)
            {
                TargetTemplate targetTemplate = new TargetTemplate
                {
                    EveId = id,
                    Eventname = _event.Eventname,
                    ArrowAmount = _event.Arrowamount,
                    ArrowCount = null,
                    ParcourName = _event.Par.Parcourname,
                    TargetName = null
                };
                return View(targetTemplate);
            }
            else
            {
                TargetTemplate targetTemplate = new TargetTemplate
                {
                    EveId = id,
                    Eventname = _event.Eventname,
                    ArrowAmount = _event.Arrowamount,
                    ArrowCount = list.Arrows,
                    ParcourName = _event.Par.Parcourname,
                    TargetName = list.Tar.Targetname
                };
                return View(targetTemplate);
            }
        }

        // POST: EventController/Currentevent/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CurrentEvent(int id,IFormCollection collection)
        {
            var eventId = id;
            var _event = EventService.GetEventById(eventId);
            var user = UserService.GetUserByName(User.Identity.Name);
            var targetId = _eventService.GetUsersCurrentTargetInEvent(id, User.Identity.Name).TarId;

            if (user == null)
            {
                return NoContent();
            }

            switch (collection["drone"])
            {
                case "ck":
                    // Centerkill                                                                             \/ Get Arrow Number
                    _arrowService.AddArrow(eventId, user.Id, 1, 1, targetId/*_arrowService.GetCurrentArrowNumber(eventId, user.Id)*/);
                    break;
                case "k":
                    // Kill                                                                                    \/ Get Arrow Number
                    _arrowService.AddArrow(eventId, user.Id, 2, 1, targetId/*_arrowService.GetCurrentArrowNumber(eventId, user.Id)*/);
                    break;
                case "b":
                    _arrowService.AddArrow(eventId, user.Id, 3, 1, targetId/*_arrowService.GetCurrentArrowNumber(eventId, user.Id)*/);
                    // Body                                                                                    /\ Get Arrow Number
                    break;
                case "nh":
                    _arrowService.AddArrow(eventId, user.Id, 4, 1, targetId/*_arrowService.GetCurrentArrowNumber(eventId, user.Id)*/);
                    // No Hit                                                                                  /\ Get Arrow Number
                    break;
                default:
                    break;
            }

            await _hubContext.Clients.Group(eventId.ToString()).SendAsync("RecieveLeaderboard", Utility.GetUserWithPointsAsJson(_eventService.GetUsersWithPointsFromEventById(eventId)));
            var list = _eventService.GetUsersCurrentTargetInEvent(id, User.Identity.Name);

            if (list == null)
            {
                TargetTemplate targetTemplate = new TargetTemplate
                {
                    EveId = id,
                    Eventname = _event.Eventname,
                    ArrowAmount = _event.Arrowamount,
                    ArrowCount = null,
                    ParcourName = _event.Par.Parcourname,
                    TargetName = null
                };
                return View(targetTemplate);
            }
            else
            {
                TargetTemplate targetTemplate = new TargetTemplate
                {
                    EveId = id,
                    Eventname = _event.Eventname,
                    ArrowAmount = _event.Arrowamount,
                    ArrowCount = list.Arrows,
                    ParcourName = _event.Par.Parcourname,
                    TargetName = list.Tar.Targetname
                };
                return View(targetTemplate);
            }
        }

        // GET: EventController/MyEvents
        public ActionResult MyEvents()
        {
            var tmp = _eventService.GetListOfCurrentEventsByUsername(User.Identity.Name);
            return View(tmp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyEvents(int id)
        {
            var tmp = _eventService.GetListOfCurrentEventsByUsername(User.Identity.Name);
            return View(tmp);
        }
    }
}