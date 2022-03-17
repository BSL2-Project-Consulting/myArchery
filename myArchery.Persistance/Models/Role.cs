using System;
using System.Collections.Generic;

namespace myArchery.Persistance.Models
{
    public partial class Role
    {
        public Role()
        {
            EventUserRoles = new HashSet<EventUserRole>();
        }

        public int RolId { get; set; }
        public string Rolename { get; set; } = null!;

        public virtual ICollection<EventUserRole> EventUserRoles { get; set; }
    }
}
