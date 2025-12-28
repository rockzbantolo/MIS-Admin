using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS_Admin.Model.Dto
{
    internal class ServiceUpdateResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
