using System;
using System.Collections.Generic;

namespace myArchery.Persistance.Models
{
    public partial class Arrow
    {
        [Key]
        public int ArrId { get; set; }
        public int PoiId { get; set; }
        public int PataId { get; set; }
        public int EvusroId { get; set; }
        public DateTime Hitdatetime { get; set; }

        public virtual EventUserRole Evusro { get; set; } = null!;
        public virtual ParcoursTarget Pata { get; set; } = null!;
        public virtual Point Poi { get; set; } = null!;
    }
}
