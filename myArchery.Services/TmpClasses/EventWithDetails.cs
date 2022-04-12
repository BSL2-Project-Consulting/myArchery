using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myArchery.Services.TmpClasses
{
    public class EventWithDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserCount { get; set; }
        public int ArrowAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public short IsPrivate { get; set; }
        public Parcour Par { get; set; }
    }
}