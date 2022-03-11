using System;
using System.Collections.Generic;

namespace myArchery.Persistance.Models
{
    public partial class Parcour
    {
        public Parcour()
        {
            Events = new HashSet<Event>();
            ParcoursTargets = new HashSet<ParcoursTarget>();
        }

        public int ParId { get; set; }
        public string Name { get; set; } = null!;
        public string Town { get; set; } = null!;
        public int Postalcode { get; set; }
        public string StreetHousenumber { get; set; } = null!;
        public int Counttargets { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<ParcoursTarget> ParcoursTargets { get; set; }
    }
}
