using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myArchery.Services;

namespace myArchery.Controllers
{
    public class CreateEventController : Controller
    {
        // GET: CreateEventController
        public ActionResult Index()
        {
            return Create();
        }

        // GET: CreateEventController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CreateEventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreateEventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, AspNetUser creator)
        {
            
            try
            {
                Event newEvent = new Event
                {
                    Eventname = collection["id"],
                    Startdate = DateTime.Parse(collection["Startdate"]),
                    Enddate = DateTime.Parse(collection["EndDate"]),
                    Isprivat = 0,
                    Password = null,
                    ParId = ParcourService.GetParcourIdByName(collection["ParcourName"])
                };

                for (int i = 0; i < collection.Count; i+=5)
                {
                    int currentIndex = i/5;

                    string centerkillVal = "centerkill" + currentIndex;
                    string killVal = "kill" + currentIndex;
                    string lifeVal = "life" + currentIndex;
                    string bodyVal = "body" + currentIndex;
                    
                    Point centerKill = new Point();
                    Point kill = new Point();
                    Point life = new Point();
                    Point body = new Point();
                    Point nohit = new Point();

                    centerKill.ArrowNumber = i;
                    kill.ArrowNumber = i;
                    life.ArrowNumber = i;
                    body.ArrowNumber = i;
                    nohit.ArrowNumber = i;


                    _ = int.TryParse(collection[centerkillVal], out int result1);
                    centerKill.Value = result1;

                    _ = int.TryParse(collection[killVal], out int result2);
                    kill.Value = result2;

                    _ = int.TryParse(collection[lifeVal], out int result3);
                    life.Value = result3;

                    _ = int.TryParse(collection[bodyVal], out int result4);
                    body.Value = result4;

                    nohit.Value = 0;

                    newEvent.Points.Add(centerKill);
                    newEvent.Points.Add(kill);
                    newEvent.Points.Add(life);
                    newEvent.Points.Add(body);
                    newEvent.Points.Add(nohit);                    
                }

                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CreateEventController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CreateEventController/Edit/5
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

        // GET: CreateEventController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CreateEventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
