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
        public static int CreateEvent(Event evt)
        {            
            using (myarcheryContext db = new myarcheryContext())
            {
                db.Events.Add(evt);
                return db.SaveChanges();
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