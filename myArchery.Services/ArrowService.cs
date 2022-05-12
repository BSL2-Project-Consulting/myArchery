using Microsoft.EntityFrameworkCore;

namespace myArchery.Services
{
    public class ArrowService
    {
        private ArcheryDbContext _context;
        private EventRoleService _everoService;
        private PointService _pointService;
        private ParcourTargetService _parcourTargetService;
        private EventService _eventService;

        public ArrowService(ArcheryDbContext context, EventRoleService everoService, PointService pointService, ParcourTargetService parcourTargetService, EventService eventService)
        {
            _context = context;
            _everoService = everoService;
            _pointService = pointService;
            _parcourTargetService = parcourTargetService;
            _eventService = eventService;
        }

        /*-- 
         all infos about an arrow (you have to set eve_id)
        SELECT 
	        e.name AS 'Event Name',
            u.username AS 'Username',
            CASE 
		        WHEN p.value_id = 1 THEN 'Center Kill'
                WHEN p.value_id = 2 THEN 'Kill'
                WHEN p.value_id = 3 THEN 'Life'
                WHEN p.value_id = 4 THEN 'Body'
                WHEN p.value_id = 5 THEN 'No Hit'
	        END AS 'Hit_Type',
            p.value AS 'Points',
            a.hitdatetime AS 'Hit Time',
            t.targetname AS 'Target'
        FROM arrow a
        LEFT JOIN event_user_roles eur ON a.evusro_id = eur.evusro_id
        LEFT JOIN points p ON a.poi_id = p.poi_id
        LEFT JOIN user u ON eur.use_id = u.use_id
        LEFT JOIN event e ON eur.eve_id = e.eve_id
        LEFT JOIN parcours_target pt ON a.pata_id = pt.pata_id
        LEFT JOIN target t ON pt.tar_id = t.tar_id
        WHERE eur.eve_id = 4
        ORDER BY u.username, a.hitdatetime;
        */
        /// <summary>
        /// Gets all Arrows shot in an Event by given id
        /// </summary>
        /// <param name="eve_id">Event id that is coresponding with the given id</param>
        /// <returns>List of Arrows with additional Info</returns>
        public List<ArrowWithInfo> GetArrowInfo(int eve_id)
        {
            var res = from arrow in _context.Arrows
                      join eventUserRoles in _context.EventUserRoles on arrow.EvusroId equals eventUserRoles.EvusroId
                      join points in _context.Points on arrow.PoiId equals points.PoiId
                      join user in _context.AspNetUsers on eventUserRoles.Use.Id equals user.Id
                      join events in _context.Events on eventUserRoles.EveId equals events.EveId
                      join pt in _context.ParcoursTargets on arrow.PataId equals pt.PataId
                      join target in _context.Targets on pt.TarId equals target.TarId
                      where events.EveId == eve_id
                      orderby user.UserName
                      orderby arrow.Hitdatetime
                      select new ArrowWithInfo
                      {
                          EventName = events.Eventname,
                          Username = user.UserName,
                          HitType = points.ValueId.ToString(),
                          HitTime = arrow.Hitdatetime,
                          Points = points.Value,
                          TargetName = target.Targetname
                      };

            return res.ToList();
        }

        public void AddArrow(int eve_id, string use_id, int value_id, int arrowNumber, int TargetId)
        {
            var test = _context.Arrows.Include(x => x.Pata).Include(x => x.Evusro).Where(x => x.Evusro.EveId == eve_id);

            var evusro = _everoService.GetEventRole(eve_id, use_id);

            var poi = _pointService.GetPoint(eve_id, value_id, arrowNumber);

            var pata = _eventService.GetUsersCurrentTargetInEvent(eve_id, UserService.GetUserById(use_id).UserName);

            var target = _context.Targets.First(x => x.TarId == TargetId);

            Arrow arrow = new Arrow
            {
                EvusroId = evusro.EvusroId,
                Hitdatetime = DateTime.Now,
                PataId = pata.PataId,
                PoiId = poi.PoiId
            };
            
            pata.Arrows.Add(arrow);

            _context.Arrows.Add(arrow);
            _context.SaveChanges();
        }

        public int GetCurrentArrowNumber(int eventId, string userId)
        {
            var arrowNumber = 1; // place linq query here


            return arrowNumber;
        }
    }
}