﻿using System;
using System.Collections.Generic;

namespace myArchery.Persistance.Models
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            EventUserRoles = new HashSet<EventUserRole>();
            Roles = new HashSet<AspNetRole>();
        }

        [Key]
        public string Id { get; set; } = null!;
        public int UseId { get; set; }
        public string? Password { get; set; }
        public string? Vname { get; set; }
        public string? Nname { get; set; }
        public string? Email { get; set; }
        public int Isactive { get; set; }
        public int Getnewsletter { get; set; }
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual ICollection<EventUserRole> EventUserRoles { get; set; }

        public virtual ICollection<AspNetRole> Roles { get; set; }
    }
}
