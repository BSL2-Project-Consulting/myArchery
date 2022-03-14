using System;
using System.Collections.Generic;

namespace myArchery.Persistance.Models
{
    public partial class ParcoursTarget
    {
        public ParcoursTarget()
        {
            Arrows = new HashSet<Arrow>();
        }

        public int PataId { get; set; }
        public int ParId { get; set; }
        public int TarId { get; set; }

        public virtual Parcour Par { get; set; } = null!;
        public virtual Target Tar { get; set; } = null!;
        public virtual ICollection<Arrow> Arrows { get; set; }
    }
}
