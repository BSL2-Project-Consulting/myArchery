using Microsoft.EntityFrameworkCore;
using myArchery.Services.TmpClasses;

namespace myArchery.Services
{
    public class EventService
    {
        private readonly ArcheryDbContext _context;
        private readonly TargetService _targetService;
        private readonly EventRoleService _eventRoleService;

        public EventService(ArcheryDbContext context, TargetService targetService, EventRoleService eventRoleService)
        {
            _context = context;
            _targetService = targetService;
            _eventRoleService = eventRoleService;
        }
        /*
         * -- the create event user interface must request the following information:
        -- 1) Event Name
        -- 2) Amount of arrows a player has for each target 
        -- 3) start- and enddate
        -- 4) is event privat and if yes, a password
        -- 5) a parcour (my personal idea is to give the user a list of all parcour names, he choose the name we insert the eventId of the chosen parcour)
        -- 6) the points you get for Center Kill, Kill, Life, Body (if he dont hit, no hit, we always give 0 points the user cant change this fact)

        -- You have to make three or more inserts (depends on how many player you wanna add). 


        -- insert into event:
        -- Change the values in the row VALUES, values which stands in between '' are strings 
        -- or datetime all the other are integers. If an Event isn't privat insert NULL without '' into password
        INSERT INTO event (eventname, arrowamount, startdate, enddate, isprivat, password, par_id)
        VALUES ('eventname_here', arrowamount_here, 'startdate', 'enddate', is_privat_here, 'password_here', par_id_here);


        -- insert into points:
        -- we always make 5 inserts per event, one for Center Kill, Kill, Life, Body and no Hit (the insert for no hit never changes)
        -- replace eve_id with the event eventId (integer) and the poitns with the amount of points the user choose
        -- insert for Center Kill:
        INSERT INTO points (eve_id, value_id, value) VALUES (eve_id, 1, points);
        -- insert for Kill:
        INSERT INTO points (eve_id, value_id, value) VALUES (eve_id, 2, points);
        -- insert for Life:
        INSERT INTO points (eve_id, value_id, value) VALUES (eve_id, 3, points);
        -- insert for Body:
        INSERT INTO points (eve_id, value_id, value) VALUES (eve_id, 4, points);
        -- insert for no Hit (always 0):
        INSERT INTO points (eve_id, value_id, value) VALUES (eve_id, 5, 0);


        -- insert into event_user_roles:
        -- now we make one insert for the creater of the event, the rol_id 1 stands for the host, the
        -- use_id stands for the user who created this event 
        INSERT INTO event_user_roles (eve_id, use_id, rol_id)
        VALUES (event_id_here, user_id_here, 1);


        -- add users to an event
        -- at the end one insert for all users who join an event
        INSERT INTO event_user_roles (eve_id, use_id, rol_id)
        VALUES (event_id_here, user_id_here, 2);
         */


        /// <summary>
        /// Create event and add User as the Creator
        /// </summary>
        /// <param name="eventName">Name of the Event</param>
        /// <param name="arrowAmount">Amount of Arrows per target</param>
        /// <param name="startDate">Start Date of the Event</param>
        /// <param name="endDate">End Date of the Event</param>
        /// <param name="isPrivate">Wheter the Event is Private or not</param>
        /// <param name="password">Password of the Event if it is private</param>
        /// <param name="ParId">Id of the parcour the event is played on</param>
        /// <param name="pointList">List of point objects the user can hit</param>
        /// <param name="userId">Id of the User that is creating the event</param>
        /// <returns>-1 if the event already exists, otherwise the amount of changed rows will be returned</returns>
        public static async Task CreateEventAndAddCreator(string eventName, int arrowAmount, DateTime startDate, DateTime endDate, sbyte isPrivate, string? password, int ParId, List<Point> pointList, string userId)
        {
            // Create new Event
            Event newEvent = new Event
            {
                Eventname = eventName,
                Arrowamount = arrowAmount,
                Startdate = startDate,
                Enddate = endDate,
                Isprivat = isPrivate,
                Password = password,
                ParId = ParId
            };

            Event res;
            using (ArcheryDbContext db = new ArcheryDbContext())
            {
                if (db.Events.Contains(newEvent)) return;
                else
                {
                    db.Events.Add(newEvent);

                    await db.SaveChangesAsync();

                    res = db.Events.First(x => x.Eventname == newEvent.Eventname && x.Startdate == newEvent.Startdate && x.Enddate == newEvent.Enddate);
                }
            }

            using (ArcheryDbContext db = new ArcheryDbContext())
            {
                foreach (var item in pointList)
                {
                    db.Points.Add(item);

                    await db.SaveChangesAsync();
                }
            }

            var user = UserService.GetUserById(userId);

            EventUserRole eventUserRole = new EventUserRole { EveId = res.EveId, Use = user, RolId = 1 };

            using (ArcheryDbContext db = new ArcheryDbContext())
            {
                db.EventUserRoles.Add(eventUserRole);

                await db.SaveChangesAsync();
            }

            return;
        }

        public static List<Event> GetAllPublicEvents()
        {
            using (ArcheryDbContext db = new ArcheryDbContext())
            {
                return db.Events.Include(x => x.Par).Where(x => x.Isprivat == 0).ToList();
            }
        }

        public static Event? JoinEvent(int eventId, string username, string? password = null)
        {
            Event? evt;
            using (ArcheryDbContext db = new ArcheryDbContext())
            {
                if (password == null)
                {
                    evt = db.Events.FirstOrDefault(x => x.EveId == eventId);
                }
                else
                {
                    evt = db.Events.FirstOrDefault(x => x.EveId == eventId && x.Password == password.ConvertToSha256());
                }

                var user = db.AspNetUsers.FirstOrDefault(x => x.UserName == username);
                if (user != null)
                {
                    // add user to event as Player
                    EventUserRole eventUser = new EventUserRole { UseId = UserService.GetUserByName(username).Id, RolId = 2, EveId = eventId };
                    db.EventUserRoles.Add(eventUser);
                }

                db.SaveChanges();
                return evt;
            }
        }

        public static int RemoveEvent(int evtId)
        {
            using (ArcheryDbContext db = new ArcheryDbContext())
            {
                db.Events.Remove(db.Events.First(x => x.EveId == evtId));
                return db.SaveChanges();
            }
        }


        /* 
         SQL select for Linq statement below

         -- AspNetUsers current event's (you have to set username)
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
        public static List<EventWithId> GetUsersCurrentEventsByUsername(string username)
        {
            using (ArcheryDbContext db = new ArcheryDbContext())
            {
                var res = from AspNetUsers in db.AspNetUsers
                            join eventRoles in db.EventUserRoles on AspNetUsers.Id equals eventRoles.UseId
                            join events in db.Events on eventRoles.EveId equals events.EveId
                            into result1
                            from finalResult in result1
                            where finalResult.Startdate < DateTime.Now && finalResult.Enddate > DateTime.Now
                            select new EventWithId
                            {
                                Eventname = finalResult.Eventname,
                                Id = finalResult.EveId
                            };
                return res.ToList();                
            }
        }

        public IEnumerable<EventWithDetails> GetListOfCurrentEventsByUsername(string username)
        {
            IEnumerable<EventWithDetails> res = from AspNetUsers in _context.AspNetUsers
                                                where AspNetUsers.UserName == username
                                                join eventRoles in _context.EventUserRoles on AspNetUsers.Id equals eventRoles.UseId
                                                join parcours in _context.Parcours on eventRoles.Eve.ParId equals parcours.ParId
                                                join events in _context.Events on eventRoles.EveId equals events.EveId
                                                into result1
                                                from finalResult in result1
                                                where finalResult.Startdate < DateTime.Now && finalResult.Enddate > DateTime.Now
                                                select new EventWithDetails
                                                {
                                                    Name = finalResult.Eventname,
                                                    Id = finalResult.EveId,
                                                    ArrowAmount = finalResult.Arrowamount,
                                                    UserCount = _context.EventUserRoles.Where(x => x.EveId == finalResult.EveId).Count(),
                                                    StartDate = finalResult.Startdate,
                                                    EndDate = finalResult.Enddate,
                                                    IsPrivate = finalResult.Isprivat,
                                                    Par = parcours
                                                };

            return res;
        }

        public ParcoursTarget GetUsersCurrentTargetInEvent(int eveId, string username)
        {
            var user = UserService.GetUserByName(username);
            var _event = GetEventById(eveId);
            var eveusro = _eventRoleService.GetEventRole(eveId, user.Id);

            var result2 = _context.ParcoursTargets.FromSqlRaw("SELECT " +
                                                            "pt.PataId, " +
                                                            "e.EveId, " +
                                                            "e.Eventname, " +
                                                            "e.Arrowamount, " +
                                                            "p.ParId, " +
                                                            "p.Parcourname, " +
                                                            "t.TarId, " +
                                                            "t.Targetname, " +
                                                            "COUNT(a.PataId) AS 'Count_Arrows', " +
                                                            "SUM(po.Value) AS 'Points' " +
                                                            "FROM ParcoursTarget pt " +
                                                            "LEFT JOIN Parcour p ON pt.ParId = p.ParId " +
                                                            "LEFT JOIN Event e ON p.ParId = e.ParId " +
                                                            "LEFT JOIN EventUserRole eur ON e.EveId = eur.EveId " +
                                                            "LEFT JOIN Target t ON pt.TarId = t.TarId " +
                                                            "LEFT JOIN Arrow a ON pt.PataId = a.PataId " +
                                                            "LEFT JOIN Point po ON a.PoiId = po.PoiId " +
                                                            $"WHERE e.EveId = {eveId} " +
                                                            $"AND eur.UseId = {user.Id} " +
                                                            "GROUP BY pt.PataId, e.EveId, e.Eventname, e.Arrowamount, p.ParId, p.Parcourname, t.TarId, t.Targetname " +
                                                            "ORDER BY pt.PataId");

            int cont = 0;
            ParcoursTarget pta = new();
            int count = 0;
            do
            {
                var tmp1 = from arrow in _context.ParcoursTargets.Include(x => x.Arrows)
                           where arrow.TarId == result2.ToList()[count].TarId
                           select arrow;

                var tmp2 = from pt in _context.ParcoursTargets.Include(x => x.Arrows).Include(x => x.Tar).Include(x => x.Par).Where(x => x.TarId == result2.ToList()[count].TarId) select pt;
                pta = tmp2.First();
                if (pta.Arrows.Count == 0)
                {
                    cont = -1;
                }
                else
                {
                    count++;
                }
            } while (cont == 0);
                      

            
            //ParcoursTarget? tmp = result2.ToList().FirstOrDefault(x => x.Arrows.Count < _event.Arrowamount);
            //tmp.Tar = target;
            return pta;
        }

        /// <summary>
        /// Gets the Completed Event a specified user is in
        /// </summary>
        /// <param name="username">The username that is used to retrieve the events</param>
        /// <returns>List of events with EventId and Event Name</returns>
        public static object GetUsersPastEventsByUsername(string username)
        {
            using (ArcheryDbContext db = new ArcheryDbContext())
            {
                var res = from AspNetUsers in db.AspNetUsers
                          where AspNetUsers.UserName == username
                          join eventRoles in db.EventUserRoles on AspNetUsers.Id equals eventRoles.Use.Id
                          join events in db.Events on eventRoles.EveId equals events.EveId
                          into result1
                          from finalResult in result1
                          where finalResult.Enddate < DateTime.Now
                          select new EventWithId
                          {
                              Id = finalResult.EveId,
                              Eventname = finalResult.Eventname
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
            using (ArcheryDbContext db = new ArcheryDbContext())
            {
                var res = from AspNetUsers in db.AspNetUsers
                          where AspNetUsers.UserName == username
                          join eventRoles in db.EventUserRoles on AspNetUsers.Id equals eventRoles.Use.Id
                          join events in db.Events on eventRoles.EveId equals events.EveId
                          into result1
                          from finalResult in result1
                          where finalResult.Startdate > DateTime.UtcNow
                          select new EventWithId
                          {
                              Id = finalResult.EveId,
                              Eventname = finalResult.Eventname
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
		/// Get all AspNetUsers in an Event with Roles by given event eventId
		/// </summary>
		/// <param name="eve_id">Event Id that coresponds with Event in the db</param>
		/// <returns>List of objects with Event Name</returns>
		public static List<EventUser> GetAllUsersFromEventWithRoles(int eveId)
        {
            using (ArcheryDbContext db = new ArcheryDbContext())
            {
                var res = from eventUserRoles in db.EventUserRoles
                          where eventUserRoles.EveId == eveId
                          join events in db.Events on eventUserRoles.EveId equals events.EveId
                          join user in db.AspNetUsers on eventUserRoles.Use.Id equals user.Id
                          join roles in db.Roles on eventUserRoles.RolId equals roles.RolId
                          into result1
                          from finalResult in result1
                          select new EventUser
                          {
                              Rolename = finalResult.Rolename,
                              Username = user.UserName,
                              Eventname = events.Eventname
                          };

				return res.ToList();
            }
        }

        /*
         -- all AspNetUsers in an event and their points (you have to set eve_id)
        SELECT 
	        e.eventname AS 'Event Name',
            u.username AS 'Username',
            SUM(p.value) AS 'Punkte'
        FROM event_user_roles eur
        LEFT JOIN event e ON eur.eve_id = e.eve_id
        LEFT JOIN user u ON eur.use_id = u.use_id
        LEFT JOIN arrow a ON eur.evusro_id = a.evusro_id
        LEFT JOIN points p ON a.poi_id = p.poi_id
        WHERE eur.eve_id = 1
        GROUP BY e.eventname, u.username
        */
        public List<UsersWithPoints> GetUsersWithPointsFromEventById(int eveId)
		{
            var res = from eventuserroles in _context.EventUserRoles
                      where eventuserroles.EveId == eveId
                      join eve in _context.Events on eventuserroles.EveId equals eve.EveId
                      join user in _context.AspNetUsers on eventuserroles.Use.Id equals user.Id
                      join arrow in _context.Arrows on eventuserroles.EvusroId equals arrow.EvusroId
                      join points in _context.Points on arrow.PoiId equals points.PoiId
                      into result1
                      from finalResult in result1
                      select new UsersWithPoints
                      {
                          Username = user.UserName,
                          Points = arrow.Poi.Value,
                      };

            var res1 = from AspNetUsers in res
                       group AspNetUsers by AspNetUsers.Username into result2
                       select new UsersWithPoints
                       {
                           Username = result2.Key,
                           Points = result2.Sum(x => x.Points)
                       };

            return res1.OrderByDescending(x => x.Points).ToList();
        }

        public static Event? GetEventById(int id)
        {
            using (ArcheryDbContext db = new ArcheryDbContext())
            {
                return db.Events.Include(x => x.Par).FirstOrDefault(x => x.EveId == id);
            }
        }

        public static bool UserIsInEvent(int eventId, string username)
        {
            using (ArcheryDbContext db = new ArcheryDbContext())
            {
                var _event = db.EventUserRoles.Where(x => x.EveId == eventId && x.Use == UserService.GetUserByName(username));
                return _event.Count() > 0;
            }
        }

        public static void AddUserToEvent(int eventId, string username)
        {
            EventUserRole eventUser = new EventUserRole { Use = UserService.GetUserByName(username), RolId = 2, EveId = eventId };
            using (ArcheryDbContext db = new ArcheryDbContext())
            {
                db.EventUserRoles.Add(eventUser);
            }
        }
    }
}