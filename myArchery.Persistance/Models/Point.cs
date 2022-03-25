using System;
using System.Collections.Generic;

namespace myArchery.Persistance.Models
{
    public partial class Point
    {
        public Point()
        {
            Arrows = new HashSet<Arrow>();
        }

        [Key]
        public int PoiId { get; set; }
        public int EveId { get; set; }
        public int ValueId { get; set; }
        public int Value { get; set; }

        public virtual Event Eve { get; set; } = null!;
        public virtual ICollection<Arrow> Arrows { get; set; }
    }
}
