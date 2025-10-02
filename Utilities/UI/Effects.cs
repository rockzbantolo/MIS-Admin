using MIS_Admin.Utilities.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS_Admin.Utilities.UI
{
    internal static class Effects
    {
        public static async Task SlideIn(this UserControl newControl, Panel container, int speed = 100, int delay = 1)
        {
            newControl.Size = container.Size;
            newControl.Left = -container.Width; // Start off-screen (left)
            container.Controls.Add(newControl);
            newControl.BringToFront();
            newControl.Visible = true;

            while (newControl.Left < 0)
            {
                newControl.Left += speed; // Move faster
                await Task.Delay(delay); // Reduce delay
            }

            newControl.Left = 0;
        }

        public static async Task SlideOut(this UserControl control, int speed = 100, int delay = 1)
        {
            while (control.Left < control.Width)
            {
                control.Left += speed; // Move faster
                await Task.Delay(delay); // Reduce delay
            }

            control.Parent.Controls.Remove(control);
        }

        public static void Radius(this Control control, int radius, Color color)
        {
            control.setRadius(radius, color, 1);
        }

        public static void RadiusControl(this Control control, Color btnColor, Color pnColor)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is Panel pn)
                {
                    pn.Radius(10, pnColor);
                }
                else if (ctrl is Button btn)
                {
                    btn.Radius(8, btnColor);
                }
            }
        }

        public static void Placeholder(this TextBox Txt, string placeholder, Color? placeholderColor = null)
        {
            Color colorToUse = placeholderColor ?? Txt.ForeColor;

            Txt.setPlaceholder(placeholder, colorToUse);
        }

        public static async Task FadeIn(this Form form, int Steps, int Duration)
        {
            for (int i = 0; i <= Steps; i++)
            {
                double opacity = (double)i / Steps;
                form.Opacity = opacity; // Set the form's opacity gradually

                await Task.Delay(Duration / Steps);
            }

            form.Opacity = 1; // Ensure the opacity is fully set at the end
        }

        public static async Task FadeOut(this Form form, int Steps, int Duration)
        {
            for (int i = Steps; i >= 0; i--)
            {
                double opacity = (double)i / Steps;
                form.Opacity = opacity; // Set the form's opacity gradually

                await Task.Delay(Duration / Steps);
            }

            form.Opacity = 0; // Ensure the opacity is fully set at the end
        }


    }
}
