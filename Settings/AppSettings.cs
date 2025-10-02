using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS_Admin.Settings
{
    internal static class AppSettings
    {
        public static bool IsDevelopment { get; private set; }

        static AppSettings()
        {
            try
            {
                var value = ConfigurationManager.AppSettings["IsDevelopment"];
                IsDevelopment = value?.ToLower() == "true";
            }
            catch
            {
                // Fallback to safe default
                IsDevelopment = true;
            }
        }
    }
}
