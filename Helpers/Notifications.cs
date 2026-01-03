using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS_Admin.Utilities
{
    public static class Notifications
    {
        private static readonly NotifyIcon notifyIcon;

        // static constructor (runs once)
        static Notifications()
        {
            notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };
        }

        public static void ShowWindowsNotification(string title, string message, ToolTipIcon iconType, int durationMs = 3000)
        {
            notifyIcon.Icon = iconType switch
            {
                ToolTipIcon.Error => SystemIcons.Error,
                ToolTipIcon.Warning => SystemIcons.Warning,
                ToolTipIcon.Info => SystemIcons.Information,
                _ => SystemIcons.Application
            };

            notifyIcon.ShowBalloonTip(durationMs, title, message, iconType);
        }

        public static void Dispose()
        {
            notifyIcon.Dispose();
        }
    }
}
