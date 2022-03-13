using System;
using System.Collections.Generic;

namespace myArchery.Persistance.Models
{
    public partial class PasswordHistory
    {
        public int PhyId { get; set; }
        public string Password { get; set; } = null!;
        public DateTime Fromdate { get; set; }
        public DateTime? Untildate { get; set; }
        public int IsActive { get; set; }
        public int UseId { get; set; }

        public virtual User Use { get; set; } = null!;
    }
}
