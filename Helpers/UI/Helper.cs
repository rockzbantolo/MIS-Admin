using MIS_Admin.Utilities.Extentions;
using System.Runtime.InteropServices;


namespace MIS_Admin.Utilities.UI
{
    internal static class Helper
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, bool wParam, int lParam);
        private const int WM_SETREDRAW = 0x000B;
        private static bool isOpen = true;

        // Usage: new NewUserAuthForm().ShadowBackground(new MainForm());
        public static void ShowUserControl(this UserControl control, Panel container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));
            if (control == null) throw new ArgumentNullException(nameof(control));

            // enable double buffering on container
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, container, new object[] { true });

            // suspend redraw completely
            SendMessage(container.Handle, WM_SETREDRAW, false, 0);
            container.SuspendLayout();

            try
            {
                // remove old control
                if (container.Controls.OfType<UserControl>().FirstOrDefault() is UserControl existing)
                {
                    container.Controls.Remove(existing);
                    existing.Dispose();
                }

                // prepare new control
                control.Dock = DockStyle.Fill;

                container.Controls.Add(control);

                control.HandleCreated += (s, e) =>
                {
                    if (control.CanFocus) control.Focus();
                    if (control.AutoScroll) control.ScrollControlIntoView(control);
                    if (HasDataGridView(control)) control.ClearGridSelection();
                };
            }
            finally
            {
                container.ResumeLayout(true);
                SendMessage(container.Handle, WM_SETREDRAW, true, 0);
                container.Refresh(); // single repaint at final state
            }
        }

        /// Usage examples:
        /// 
        /// 1. Basic form configuration without showing:
        /// <code>
        /// ControlAction<MyForm>(this, form => {
        ///     form.Text = "Configuration Dialog";
        ///     form.Size = new Size(400, 300);
        /// });
        /// </code>
        /// 
        /// 2. Show a non-modal (modeless) form:
        /// <code>
        /// ControlAction<MyForm>(this, form => {
        ///     form.InitializeData(data);
        /// }, showForm: true);
        /// </code>
        /// 
        /// 3. Show a modal dialog:
        /// <code>
        /// ControlAction<MyForm>(this, form => {
        ///     form.SetParameters(parameters);
        /// }, showForm: true, modal: true);
        /// </code>
        /// 
        /// 4. Reuse existing form if available:
        /// If the parent form is already of type T, the action will be applied to it
        /// and no new form will be created.
        /// </remarks>
        public static void ControlAction<T>(
              Control instance,
              Action<T> action,
              bool isShow = false,
              bool isModal = false
        ) where T : Form, new()
        {
            // Find the parent form (for ownership if showing)
            Form parentForm = instance?.FindForm();

            // Check if the parent is already of type T (optional)
            if (parentForm is T existingForm)
            {
                action?.Invoke(existingForm);
                return;
            }

            // Create a new form
            T form = new T();

            // Apply the action (e.g., configure the form)
            action?.Invoke(form);

            // Show the form if requested
            if (isShow)
            {
                if (isModal) form.ShowDialog(parentForm); // Blocking
                else form.Show(parentForm); // Non-blocking

            }
        }

        public static void ShadowBackground(this Form dialog, Form parent)
        {
            using (Form shadow = new Form())
            {
                shadow.FormBorderStyle = FormBorderStyle.None;
                shadow.Opacity = 0.5;
                shadow.BackColor = Color.Black;
                shadow.ShowInTaskbar = false;
                shadow.StartPosition = FormStartPosition.Manual;

                var screen = Screen.FromControl(parent);
                shadow.Size = screen.WorkingArea.Size;
                shadow.Location = screen.WorkingArea.Location;

                shadow.Show();
                dialog.Owner = shadow;
                dialog.ShowDialog();
            }
        }

        private static async Task SlideAnimation(this Panel Pnl, int TargetWidth, int Speed, int Delay)
        {
            int initialWidth = Pnl.Width;
            int totalSteps = Math.Abs(TargetWidth - initialWidth) / Speed;

            double CubicEaseInOut(double t)
            {
                // Cubic easing function (ease-in-out)
                if (t < 0.5)
                    return 4 * t * t * t;
                else
                    return 1 - Math.Pow(-2 * t + 2, 3) / 2;
            }

            for (int step = 0; step <= totalSteps; step++)
            {
                double t = (double)step / totalSteps;
                double easedValue = CubicEaseInOut(t);

                int currentWidth = initialWidth + (int)((TargetWidth - initialWidth) * easedValue);
                Pnl.Width = currentWidth;

                await Task.Delay(Delay);
            }

            // Ensure the final width is set correctly
            Pnl.Width = TargetWidth;
        }

        public static async Task ToggleSidebar(this Panel Pn, Button[] btns)
        {
            isOpen = !isOpen; // Toggle state FIRST

            int targetWidth = isOpen ? 200 : 80; // Set correct width (200 = Open, 80 = Closed)

            await SlideAnimation(Pnl: Pn, TargetWidth: targetWidth, Speed: 10, Delay: 10);

            UpdateButtonStyle(btns, !isOpen); // Pass the opposite of isOpen (true = icons only)
        }

        public static void UpdateButtonStyle(Button[] buttons, bool isIconOnly)
        {
            if (buttons == null || buttons.Length == 0) return;

            foreach (var btn in buttons)
            {
                if (btn.Tag == null) continue; // Ensure Tag is set

                if (isIconOnly)
                {
                    btn.Text = ""; // Remove text
                    btn.Refresh();  // Force UI update
                }
                else
                {
                    btn.Text = btn.Tag.ToString(); // Restore text
                }
            }
        }

        public static void ClearGridSelection(this UserControl userControl)
        {
            foreach (Control control in userControl.Controls)
            {
                // If control is a container (like a Panel, GroupBox, etc.)
                if (control is Panel || control is GroupBox || control is FlowLayoutPanel || control is TableLayoutPanel)
                {
                    // Recursively call the method to clear selections in child controls
                    foreach (Control innerControl in control.Controls)
                    {
                        if (innerControl is DataGridView innerDataGridView)
                        {
                            innerDataGridView.ClearSelection();

                            // Clear selection when the user leaves a cell
                            innerDataGridView.CellLeave += (sender, e) =>
                            {
                                innerDataGridView.ClearSelection();
                            };
                        }
                    }
                }

                // If the control is a DataGridView, clear its selection
                else if (control is DataGridView dataGridView)
                {
                    dataGridView.ClearSelection();

                    // Clear selection when the user leaves a cell
                    dataGridView.CellLeave += (sender, e) =>
                    {
                        dataGridView.ClearSelection();
                    };
                }
            }
        }

        public static bool HasDataGridView(Control control)
        {
            // Null check for safety
            if (control == null || control.Controls == null || control.Controls.Count == 0)
                return false;

            // Use a stack for iterative depth-first search to avoid recursion overhead
            var stack = new Stack<Control>();
            stack.Push(control);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                // Check if current control is a DataGridView
                if (current is DataGridView)
                    return true;

                // Skip controls that can't have children
                if (!current.HasChildren || current.Controls.Count == 0)
                    continue;

                // Add child controls to stack in reverse order for DFS
                for (int i = current.Controls.Count - 1; i >= 0; i--)
                {
                    var child = current.Controls[i];
                    stack.Push(child);
                }
            }

            return false;
        }

    }
}
