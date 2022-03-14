﻿namespace myArchery.Services
{
    public static class EventService
    {
        public static int CreateEvent(string name, DateTime startDate, DateTime endDate, sbyte isPrivate, int par_id, string username)
        {            
            Event evt = new Event();
            evt.Eventname = name;
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
         SQL select for Linq statement below

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

        /// <summary>
        /// Gets the Current Running Event a specified user is in
        /// </summary>
        /// <param name="username">The username that is used to retrieve the events</param>
        /// <returns>List of events with EventId and Event Name</returns>
        public static object GetUsersCurrentEventsByUsername(string username)
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                var res = from users in db.Users
                          where users.Username == username
                          join eventRoles in db.EventUserRoles on users.UseId equals eventRoles.UseId
                          join events in db.Events on eventRoles.EveId equals events.EveId
                          into result1
                          from finalResult in result1
                          where finalResult.Startdate < DateTime.UtcNow
                          where finalResult.Enddate > DateTime.UtcNow
                          select new
                          {
                              finalResult.EveId,
                              finalResult.Eventname
                          };

                return res.ToList();                
            }
        }

        /// <summary>
        /// Gets the Completed Event a specified user is in
        /// </summary>
        /// <param name="username">The username that is used to retrieve the events</param>
        /// <returns>List of events with EventId and Event Name</returns>
        public static object GetUsersPastEventsByUsername(string username)
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                var res = from users in db.Users
                          where users.Username == username
                          join eventRoles in db.EventUserRoles on users.UseId equals eventRoles.UseId
                          join events in db.Events on eventRoles.EveId equals events.EveId
                          into result1
                          from finalResult in result1
                          where finalResult.Enddate < DateTime.UtcNow
                          select new
                          {
                              finalResult.EveId,
                              finalResult.Eventname
                          };

                return res.ToList();
            }
        }

        /// <summary>
        /// Gets the Ongoing Event a specified user is in
        /// </summary>
        /// <param name="username">The username that is used to retrieve the events</param>
        /// <returns>List of events with EventId and Event Name</returns>
        public static object GetUsersOngoingEventsByUsername(string username)
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                var res = from users in db.Users
                          where users.Username == username
                          join eventRoles in db.EventUserRoles on users.UseId equals eventRoles.UseId
                          join events in db.Events on eventRoles.EveId equals events.EveId
                          into result1
                          from finalResult in result1
                          where finalResult.Startdate > DateTime.UtcNow
                          select new
                          {
                              finalResult.EveId,
                              finalResult.Eventname
                          };

                return res.ToList();
            }
        }

        /*
        SELECT 
	        e.name AS 'Event',
            u.username AS 'Username',
            r.name AS 'Role'
        FROM event_user_roles eur
        LEFT JOIN event e ON eur.eve_id = e.eve_id
        LEFT JOIN user u ON eur.use_id = u.use_id
        LEFT JOIN roles r ON eur.rol_id = r.rol_id
        ORDER BY e.name, r.name;
        */


        /// <summary>
        /// Get all Users in an Event with Roles by given event id
        /// </summary>
        /// <param name="eve_id">Event Id that coresponds with Event in the db</param>
        /// <returns>List of objects with Event Name</returns>
        public static object GetAllUsersFromEventWithRoles(int eve_id)
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                var res = from eventUserRoles in db.EventUserRoles
                          where eventUserRoles.EveId == eve_id
                          join events in db.Events on eventUserRoles.EveId equals events.EveId
                          join user in db.EventUserRoles on eventUserRoles.UseId equals user.UseId
                          join roles in db.Roles on eventUserRoles.RolId equals roles.RolId
                          into result1
                          from finalResult in result1
                          select new
                          {
                              finalResult.Rolename,
                              user.Use.Username,
                              events.Eventname
                          };

                return res.ToList();
            }
        }
    }
}