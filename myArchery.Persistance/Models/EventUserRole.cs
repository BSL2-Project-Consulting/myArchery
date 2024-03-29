﻿using System;
using System.Collections.Generic;

namespace myArchery.Persistance.Models
{
    public partial class EventUserRole
    {
        public EventUserRole()
        {
            Arrows = new HashSet<Arrow>();
        }
        [Key]
        public int EvusroId { get; set; }
        public int EveId { get; set; }
        public int RolId { get; set; }
        public string UseId { get; set; } = null!;

        public virtual Event Eve { get; set; } = null!;
        public virtual Role Rol { get; set; } = null!;
        public virtual AspNetUser Use { get; set; } = null!;
        public virtual ICollection<Arrow> Arrows { get; set; }
    }
}
