using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myArchery.Persistance.Models
{
    public class ArrowWithInfo
    {
        public string EventName { get; set; }
        public string Username { get; set; }
        public string HitType { get; set; }
        public int Points { get; set; }
        public DateTime HitTime { get; set; }
        public string TargetName { get; set; }
    }
}