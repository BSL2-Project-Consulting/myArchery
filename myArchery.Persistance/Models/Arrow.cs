using System;
using System.Collections.Generic;

namespace myArchery.Persistance.Models
{
    public partial class Arrow
    {
        public int ArrId { get; set; }
        public int UseId { get; set; }
        public int EveId { get; set; }
        public int PoiId { get; set; }
        public int PataId { get; set; }

        public virtual Event Eve { get; set; } = null!;
        public virtual ParcoursTarget Pata { get; set; } = null!;
        public virtual Point Poi { get; set; } = null!;
        public virtual User Use { get; set; } = null!;
    }
}
