using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace myArchery.Persistance.Models
{
    public partial class User
    {
        public User()
        {
            Arrows = new HashSet<Arrow>();
            EventUserRoles = new HashSet<EventUserRole>();
            PasswordHistories = new HashSet<PasswordHistory>();
        }

        public int UseId { get; set; }
        public string Username { get; set; } = null!;
        /// <summary>
        /// 64 weil sha265 immer 64 zeichen lang ist 
        /// </summary>
        public string Password { get; set; } = null!;
        public string Vname { get; set; } = null!;
        public string Nname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public sbyte Isactive { get; set; }

        public virtual ICollection<Arrow> Arrows { get; set; }
        public virtual ICollection<EventUserRole> EventUserRoles { get; set; }
        public virtual ICollection<PasswordHistory> PasswordHistories { get; set; }
    }
}
