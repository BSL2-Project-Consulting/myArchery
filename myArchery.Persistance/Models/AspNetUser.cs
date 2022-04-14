using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace myArchery.Persistance.Models
{
    public partial class AspNetUser : IdentityUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            EventUserRoles = new HashSet<EventUserRole>();
            Roles = new HashSet<AspNetRole>();
        }

        public string? Vname { get; set; }
        public string? Nname { get; set; }
        public int Getnewsletter { get; set; }

        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual ICollection<EventUserRole> EventUserRoles { get; set; }

        public virtual ICollection<AspNetRole> Roles { get; set; }
    }
}
