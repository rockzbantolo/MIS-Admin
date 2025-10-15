using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS_Admin.Model
{
    public class InstallationDetails
    {
        public string RequestNo { get; set; }
        public string Merchant { get; set; }
        public string TID { get; set; }
        public string MID { get; set; }
        public string ModelName { get; set; }
        public string TerminalSN { get; set; }
        public string Carrier { get; set; }
        public string SimSN { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Region { get; set; }
        public string AppCrc { get; set; }
        public string AppVersion { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
