using System;
using System.Collections.Generic;

namespace myArchery.Persistance.Models
{
    public partial class EventUserRole
    {
        public int EvusroId { get; set; }
        public int EveId { get; set; }
        public int UseId { get; set; }
        public int RolId { get; set; }

        public virtual Event Eve { get; set; } = null!;
        public virtual Role Rol { get; set; } = null!;
        public virtual User Use { get; set; } = null!;
    }
}
