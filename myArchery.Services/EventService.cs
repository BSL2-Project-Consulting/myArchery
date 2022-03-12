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
            // Add user to event as Creator

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

        public static Event? JoinEvent(int id, string password, string username)
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                var evt = db.Events.FirstOrDefault(x => x.EveId == id && x.Password == password.ConvertToSha256());

                var user = db.Users.FirstOrDefault(x => x.Username == username);
                if (user != null)
                {
                    // add user to event as Player
                }

                db.SaveChanges();
                return evt;
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
        /* 
         -- users current event's (you have to set username)
        SELECT 
	        u.username,
            e.eventname
        FROM user u
        LEFT JOIN event_user_roles eur ON u.use_id = eur.use_id
        LEFT JOIN event e ON eur.eve_id = e.eve_id
        WHERE u.username = 'User2'
        ORDER BY u.username
         */

        public static void GetUsersCurrentEventsByName(string username)
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                var res = db.Users.
            }
        } 
    }
}