using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myArchery.Services.TmpClasses
{
    public class TargetTemplate
    {
        public int pataId;

        public int EveId { get; set; }
        public string Eventname { get; set; }
        public int ArrowAmount { get; set; }
        public int ParId { get; set; }
        public string ParcourName { get; set; }
        public int TarId { get; set; }
        public string TargetName { get; set; }
        public IEnumerable<Arrow> ArrowCount { get; set; }
        public IEnumerable<Point> Points { get; set; }
    }
}