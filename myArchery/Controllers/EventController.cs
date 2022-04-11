using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myArchery.Services;
using myArchery.Services.TmpClasses;

namespace myArchery.Controllers
{
    public class EventController : Controller
    {
        // GET: EventController
        public ActionResult Index()
        {
            var test = EventService.GetAllPublicEvents();
            return View(test);
        }

        //GET: EventController/AllEvents
        public ActionResult AllEvents()
        {
            return View(EventService.GetAllPublicEvents());
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
                    ParId = ParcourService.GetParcourIdByName(collection["ParId"])
                };

                for (int i = 0; i < collection.Count; i += 5)
                {
                    int currentIndex = (i / 5)+1;

                    string centerkillVal = "centerkill" + currentIndex;
                    string killVal = "kill" + currentIndex;
                    string bodyVal = "body" + currentIndex;

                    Point centerKill = new Point();
                    Point kill = new Point();
                    Point body = new Point();
                    Point nohit = new Point();

                    centerKill.ArrowNumber = currentIndex;
                    kill.ArrowNumber = currentIndex;
                    body.ArrowNumber = currentIndex;
                    nohit.ArrowNumber = currentIndex;


                    _ = int.TryParse(collection[$"Points[{currentIndex}].CenterkillValue"], out int result1);
                    centerKill.Value = result1;

                    _ = int.TryParse(collection[$"Points[{currentIndex}].KillValue"], out int result2);
                    kill.Value = result2;

                    _ = int.TryParse(collection[$"Points[{currentIndex}].BodyValue"], out int result3);
                    body.Value = result3;

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

        // GET: EventController/Currentevent
        public ActionResult CurrentEvent()
        {
            return View(EventService.GetCurrentTargetForUsername(User.Identity.Name));
        }

        // POST: EventController/Currentevent/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CurrentEvent(IFormCollection collection)
        {
            return View(EventService.GetCurrentTargetForUsername(User.Identity.Name));
        }
    }
}