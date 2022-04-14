using System;
using System.Collections.Generic;

namespace myArchery.Persistance.Models
{
    public partial class Target
    {
        public Target()
        {
            ParcoursTargets = new HashSet<ParcoursTarget>();
        }
        [Key]
        public int TarId { get; set; }
        public string Targetname { get; set; } = null!;

        public virtual ICollection<ParcoursTarget> ParcoursTargets { get; set; }
    }
}
