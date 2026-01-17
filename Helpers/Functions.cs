
namespace MIS_Admin.Utilities
{
    public static class Functions
    {
        public static class Theme {

            public static readonly Color BodyColor = Color.FromArgb(30, 39, 46);

            public static readonly Color BgColor = Color.FromArgb(47, 54, 64);

            public static class TextColor
            {
                public static readonly Color Disabled = Color.Gray;         // inactive or unavailable text
                public static readonly Color Error = Color.Red;             // error or negative state
                public static readonly Color Success = Color.Green;         // positive state
                public static readonly Color Warning = Color.Orange;        // caution or attention
                public static readonly Color Info = Color.Blue;             // informational text
                public static readonly Color Highlight = Color.SteelBlue;   // emphasized or selected text
                public static readonly Color Neutral = Color.Black;         // default / normal text
            }

            public static class StatusColor
            {
                public static readonly Color Success = Color.Green;         // Active, Completed, Installed, Normal
                public static readonly Color Warning = Color.Orange;        // Medium, Dispatched
                public static readonly Color HighRisk = Color.DarkOrange;   // High
                public static readonly Color Critical = Color.Red;          // Critical, Negative
                public static readonly Color Info = Color.YellowGreen;      // Pending
                public static readonly Color Inactive = Color.DarkGray;     // NoResponse, Failed
                public static readonly Color Assigned = Color.SteelBlue;    // workflow assignment
                public static readonly Color Processing = Color.Teal;       // workflow processing
            }
        }

    }
}
