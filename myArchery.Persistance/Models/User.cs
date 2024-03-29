﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace myArchery.Persistance.Models
{
    public partial class User : IdentityUser
    {
        public User()
        {
            EventUserRoles = new HashSet<EventUserRole>();
        }
        [Key]
        public int UseId { get; set; }
        /// <summary>
        /// 64 weil sha265 immer 64 zeichen lang ist 
        /// </summary>
        
        public string? Password { get; set; }
        public string? Vname { get; set; }
        public string? Nname { get; set; }
        public string? Email { get; set; }
        public int Isactive { get; set; }
        public int Getnewsletter { get; set; }

        public virtual ICollection<EventUserRole> EventUserRoles { get; set; }
    }
}
