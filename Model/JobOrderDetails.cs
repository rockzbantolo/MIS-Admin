using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS_Admin.Model
{
    internal class JobOrderDetails
    {
        public int ServiceNo { get; set; }
        public int JobType { get; set; }
        public int TerminalID { get; set; }
        public int SimID { get; set; }
        public int? RepTerminalID { get; set; } = null;
        public int? RepSIMID { get; set; } = null;
        public string ActionMade { get; set; }

    }
}
