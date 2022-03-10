using Microsoft.EntityFrameworkCore;
using myArchery.Persistance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myArchery.Services
{
    public static class EventService
    {
        public static int CreateEvent(string name, DateTime startDate, DateTime endDate, sbyte isPrivate, int par_id, string username)
        {            
            Event evt = new Event();
            evt.Name = name;
            evt.Startdate = startDate;
            evt.Enddate = endDate;
            evt.Isprivat = isPrivate;
            evt.Par = ParcourService.GetParcourById(par_id);
            

            // TODO: Add Includes for Roles, Event and User

            using (myarcheryContext db = new myarcheryContext())
            {
                db.Events.Add(evt);
                return db.SaveChanges();
            }
        }

        public static List<Event> GetAllPublicEvents()
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                return db.Events.Where(x => x.Isprivat == 0 && x.Password != null).ToList();
            }
        }

        public static Event JoinEvent(int id, string password, string username)
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                var evt = db.Events.Where(x => x.Password == password.ConvertToSha256() && x.EveId == id);
            }
        }

        public static int RemoveEvent(int evtId)
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                db.Events.Remove(db.Events.First(x => x.EveId == evtId));
                return db.SaveChanges();
            }
        }        
    }
}