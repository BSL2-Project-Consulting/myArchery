using System;
using System.Collections.Generic;

namespace myArchery.Persistance.Models
{
    public partial class Event
    {
        public Event()
        {
            Arrows = new HashSet<Arrow>();
            EventUserRoles = new HashSet<EventUserRole>();
            Points = new HashSet<Point>();
        }

        public int EveId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public sbyte Isprivat { get; set; }
        public string? Password { get; set; }
        public int ParId { get; set; }

        public virtual Parcour Par { get; set; } = null!;
        public virtual ICollection<Arrow> Arrows { get; set; }
        public virtual ICollection<EventUserRole> EventUserRoles { get; set; }
        public virtual ICollection<Point> Points { get; set; }
    }
}
