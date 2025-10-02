using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MIS_Admin.Utilities.Extentions
{
    internal static class ControlExt
    {
        private static readonly ConditionalWeakTable<Control, RadiusProperties> _controlProperties = new ConditionalWeakTable<Control, RadiusProperties>();
        private static readonly ConcurrentDictionary<Control, PlaceholderProperties> _placeholderControls = new ConcurrentDictionary<Control, PlaceholderProperties>();

        // Scroll Reset Position
        public static void ScrollToTop(this UserControl ctrl)
        {
            ctrl.BeginInvoke(new System.Windows.Forms.MethodInvoker(() =>
            {
                ctrl.AutoScrollPosition = new Point(0, 0);

            }));
        }


        // Buffer
        public static void DoubleBuffer(this Control control, bool enable, bool includeChildren = false)
        {
            if (control == null) return;

            var propertyInfo = control.GetType().GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);

            if (propertyInfo != null)
            {
                propertyInfo.SetValue(control, enable, null);
            }

            if (includeChildren)
            {
                foreach (Control child in control.Controls)
                {
                    child.DoubleBuffer(enable, true); // Recursive
                }
            }
        }

        public static void EnableStyles(this Control control)
        {
            var methodInfo = typeof(Control).GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic);
            if (methodInfo != null)
            {
                methodInfo.Invoke(control, new object[]
                {
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint |
                    ControlStyles.ResizeRedraw |
                    ControlStyles.OptimizedDoubleBuffer, true
                });
            }
        }


        // Radius
        private class RadiusProperties
        {
            public int Radius { get; set; }
            public Color BorderColor { get; set; }
            public int BorderWidth { get; set; }
            public GraphicsPath CachedPath { get; set; }
            public Rectangle LastBounds { get; set; }
            public bool IsPainting { get; set; }
        }

        public static void setRadius(this Control control, int radius, Color borderColor, int borderWidth)
        {
            if (control == null) throw new ArgumentNullException(nameof(control));

            control.DoubleBuffer(true);
            control.EnableStyles();

            var properties = _controlProperties.GetValue(control, _ => new RadiusProperties());

            // Only update if properties changed
            if (properties.Radius == radius &&
                properties.BorderColor == borderColor &&
                properties.BorderWidth == borderWidth)
            {
                return;
            }

            properties.Radius = radius;
            properties.BorderColor = borderColor;
            properties.BorderWidth = borderWidth;

            // Event management
            control.Resize -= Control_Resize;
            control.Paint -= Control_Paint;
            control.Disposed -= Control_Disposed;

            control.Resize += Control_Resize;
            control.Paint += Control_Paint;
            control.Disposed += Control_Disposed;

            UpdatePath(control, properties);
        }

        private static void Control_Disposed(object sender, EventArgs e)
        {
            if (sender is Control control && _controlProperties.TryGetValue(control, out var properties))
            {
                properties.CachedPath?.Dispose();
                _controlProperties.Remove(control);
            }
        }

        private static void Control_Resize(object sender, EventArgs e)
        {
            if (sender is Control control && _controlProperties.TryGetValue(control, out var properties))
            {
                if (properties.IsPainting) return;
                UpdatePath(control, properties);
                control.Invalidate(); // Force redraw after resize
            }
        }

        private static void Control_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Control control && _controlProperties.TryGetValue(control, out var properties))
            {
                if (properties.CachedPath == null) return;

                properties.IsPainting = true;
                try
                {
                    var graphics = e.Graphics;

                    // Enhanced smoothing settings
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    if (properties.BorderWidth > 0)
                    {
                        using (var borderPen = new Pen(properties.BorderColor, properties.BorderWidth))
                        {
                            borderPen.Alignment = PenAlignment.Inset; // Better border rendering
                            graphics.DrawPath(borderPen, properties.CachedPath);
                        }
                    }
                }
                finally
                {
                    properties.IsPainting = false;
                }
            }
        }

        private static void UpdatePath(Control control, RadiusProperties properties)
        {
            if (control.ClientRectangle == properties.LastBounds && properties.CachedPath != null)
            {
                return;
            }

            properties.CachedPath?.Dispose();
            properties.CachedPath = CreateSmoothRoundedRectanglePath(
                control.ClientRectangle,
                properties.Radius,
                properties.BorderWidth
            );
            properties.LastBounds = control.ClientRectangle;

            if (control.Visible)
            {
                control.Region?.Dispose();
                control.Region = new Region(properties.CachedPath);
            }
        }

        private static GraphicsPath CreateSmoothRoundedRectanglePath(Rectangle bounds, int radius, int borderWidth = 0)
        {
            var path = new GraphicsPath();

            if (bounds.Width <= 0 || bounds.Height <= 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // Adjust for border width
            if (borderWidth > 0)
            {
                bounds.Inflate(-borderWidth / 2, -borderWidth / 2);
            }

            // Ensure radius is within valid range
            radius = Math.Max(0, Math.Min(radius, Math.Min(bounds.Width, bounds.Height) / 2));

            if (radius <= 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // For smoother curves, we'll use Bezier curves instead of arcs
            int diameter = radius * 2;
            int left = bounds.Left;
            int top = bounds.Top;
            int right = bounds.Right;
            int bottom = bounds.Bottom;

            // Start from middle of left edge (top part)
            path.AddBezier(
                left, top + radius,
                left, top + radius / 2,
                left + radius / 2, top,
                left + radius, top
            );

            // Top edge to top-right corner
            path.AddLine(left + radius, top, right - radius, top);

            // Top-right corner
            path.AddBezier(
                right - radius, top,
                right - radius / 2, top,
                right, top + radius / 2,
                right, top + radius
            );

            // Right edge to bottom-right corner
            path.AddLine(right, top + radius, right, bottom - radius);

            // Bottom-right corner
            path.AddBezier(
                right, bottom - radius,
                right, bottom - radius / 2,
                right - radius / 2, bottom,
                right - radius, bottom
            );

            // Bottom edge to bottom-left corner
            path.AddLine(right - radius, bottom, left + radius, bottom);

            // Bottom-left corner
            path.AddBezier(
                left + radius, bottom,
                left + radius / 2, bottom,
                left, bottom - radius / 2,
                left, bottom - radius
            );

            // Left edge back to top-left corner
            path.AddLine(left, bottom - radius, left, top + radius);

            path.CloseFigure();
            return path;
        }



        // Placeholders
        private class PlaceholderProperties
        {
            public string PlaceholderText { get; set; }
            public Color PlaceholderColor { get; set; }
            public Color OriginalForeColor { get; set; }
            public bool IsPlaceholderActive { get; set; } = true;
            public bool OriginalTabStop { get; set; }
        }

        public static void setPlaceholder(this TextBox control, string placeholderText, Color? placeholderColor = null)
        {
            if (control == null) throw new ArgumentNullException(nameof(control));

            // Only attach events once per control
            if (!_placeholderControls.ContainsKey(control))
            {
                control.GotFocus += OnControlGotFocus;
                control.LostFocus += OnControlLostFocus;
                control.TextChanged += OnControlTextChanged;

                if (control is TextBoxBase textBox)
                {
                    textBox.Enter += OnTextBoxEnter;
                }
            }

            // Store or update placeholder properties
            _placeholderControls.AddOrUpdate(control,
                addValueFactory: c => new PlaceholderProperties
                {
                    PlaceholderText = placeholderText,
                    PlaceholderColor = placeholderColor ?? Color.Gray,
                    OriginalForeColor = c.ForeColor,
                    OriginalTabStop = c is TextBoxBase ? ((TextBoxBase)c).TabStop : true
                },
                updateValueFactory: (c, existing) =>
                {
                    existing.PlaceholderText = placeholderText;
                    existing.PlaceholderColor = placeholderColor ?? existing.PlaceholderColor;
                    return existing;
                });

            // Apply placeholder if needed
            ApplyPlaceholderIfEmpty(control);
        }

        private static void ApplyPlaceholderIfEmpty(Control control)
        {
            if (!_placeholderControls.TryGetValue(control, out var props)) return;

            if (string.IsNullOrEmpty(control.Text))
            {
                control.Text = props.PlaceholderText;
                control.ForeColor = props.PlaceholderColor;
                props.IsPlaceholderActive = true;

            }
            else if (control.Text == props.PlaceholderText && control.ForeColor == props.PlaceholderColor)
            {
                props.IsPlaceholderActive = true;
            }
        }

        private static void RemovePlaceholderForControl(Control control)
        {
            if (!_placeholderControls.TryGetValue(control, out var props)) return;

            if (props.IsPlaceholderActive)
            {
                control.Text = string.Empty;
                control.ForeColor = props.OriginalForeColor;
                props.IsPlaceholderActive = false;

                if (control is TextBoxBase textBox)
                {
                    textBox.TabStop = props.OriginalTabStop;
                }
            }
        }

        private static void OnControlGotFocus(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                RemovePlaceholderForControl(control); // Renamed method
            }
        }

        private static void OnControlLostFocus(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                ApplyPlaceholderIfEmpty(control);
            }
        }

        private static void OnControlTextChanged(object sender, EventArgs e)
        {
            if (sender is Control control && _placeholderControls.TryGetValue(control, out var props))
            {
                if (props.IsPlaceholderActive && control.Text != props.PlaceholderText)
                {
                    control.ForeColor = props.OriginalForeColor;
                    props.IsPlaceholderActive = false;

                    if (control is TextBoxBase textBox)
                    {
                        textBox.TabStop = props.OriginalTabStop;
                    }
                }
            }
        }

        private static void OnTextBoxEnter(object sender, EventArgs e)
        {
            if (sender is TextBoxBase textBox && _placeholderControls.TryGetValue(textBox, out var props))
            {
                if (props.IsPlaceholderActive)
                {
                    textBox.SelectAll();
                }
            }
        }

        public static void RemovePlaceholder(this TextBox control)
        {
            if (control == null) return;

            if (_placeholderControls.TryRemove(control, out _))
            {
                control.GotFocus -= OnControlGotFocus;
                control.LostFocus -= OnControlLostFocus;
                control.TextChanged -= OnControlTextChanged;

                if (control is TextBoxBase textBox)
                {
                    textBox.Enter -= OnTextBoxEnter;
                }
            }
        }

        public static bool HasPlaceholder(this TextBox control)
        {
            return _placeholderControls.ContainsKey(control);
        }


    }
}
