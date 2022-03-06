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
        public int ParcoursParId { get; set; }
        public int TargetTarId { get; set; }

        public virtual Parcour ParcoursPar { get; set; } = null!;
        public virtual Target TargetTar { get; set; } = null!;
        public virtual ICollection<Arrow> Arrows { get; set; }
    }
}
