using MIS_Admin.Settings;
using System.Runtime.CompilerServices;
using System.Text;


namespace MIS_Admin.Utilities
{
    public static class Functions
    {

        public static void EnableDoubleBuffering(Control control)
        {
            control.GetType()
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance)
                ?.SetValue(control, true, null);
        }

        public static void ClearGridSelection(DataGridView grid)
        {
            grid.ClearSelection();
            grid.CurrentCell = null;

            // Clear again whenever new data is bound
            grid.DataBindingComplete += (s, e) =>
            {
                grid.ClearSelection();
                grid.CurrentCell = null;
            };
        }

        public static void TriggerBtn(UserControl userControl, string buttonName, KeyEventArgs e)
        {
            var button = userControl.Controls.Find(buttonName, true).FirstOrDefault() as Button;

            if (button != null && button.Enabled)
            {
                button.PerformClick();
                e.Handled = true;
            }
        }

        public static void LoadingMessage(DataGridView grid, PaintEventArgs e, string text, int px, int py)
        {
            // measure the text size
            Size textSize = TextRenderer.MeasureText(text, grid.Font);

            // calculate center X/Y relative to the client area
            int x = (grid.ClientSize.Width - textSize.Width) / px;
            int y = (grid.ClientSize.Height - textSize.Height) / py;

            // draw the text
            TextRenderer.DrawText(
                e.Graphics,
                text,
                grid.Font,
                new Point(x, y),
                Color.Gray
            );
        }

        public static void BindComboBox<T>(ComboBox comboBox,
            IEnumerable<T> data,
            Func<T, string> displaySelector,
            Func<T, object> valueSelector)
        {
            var items = data?.Select(item => new
            {
                Display = displaySelector(item),
                Value = valueSelector(item)
            }).ToList();

            comboBox.DataSource = items;
            comboBox.DisplayMember = "Display";
            comboBox.ValueMember = "Value";
            comboBox.SelectedIndex = -1;
        }

        public static void PopulateGridDynamic(DataGridView dgv, IEnumerable<dynamic> data, params string[] propertyNames)
        {
            if (dgv == null || data == null || propertyNames == null)
                return;

            dgv.Rows.Clear();

            foreach (var item in data)
            {
                var values = propertyNames.Select(name =>
                {
                    var prop = item.GetType().GetProperty(name);
                    return prop?.GetValue(item);
                }).ToArray();

                dgv.Rows.Add(values);
            }
        }

        public static void BindDataGridView<T>(DataGridView dataGridView, IEnumerable<T> data)
        {
            try
            {
                // Clear existing rows but keep columns
                dataGridView.Rows.Clear();

                // Add rows with data
                foreach (var item in data)
                {
                    // Get all property values in order
                    var values = typeof(T).GetProperties()
                                         .Select(prop => prop.GetValue(item) ?? DBNull.Value)
                                         .ToArray();

                    // Add new row with values
                    dataGridView.Rows.Add(values);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public static void GridButtonActionClick(DataGridView grid, DataGridViewCellEventArgs e,
            Action<string> onRemove = null,
            Action<string> onPermission = null,
            Action<string> onView = null,
            Action<string> onUpdate = null)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var cellText = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
            var id = grid.Rows[e.RowIndex].Cells[0].Value?.ToString(); // Assuming ID is in column 0

            switch (cellText)
            {/*
                case AppDataActions.Remove:
                    if (MessageBox.Show($"Remove record with User ID: {id}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        onRemove?.Invoke(id);
                    }
                    break;

                case AppDataActions.Permission:
                    onPermission?.Invoke(id);
                    break;

                case AppDataActions.View:
                    onView?.Invoke(id);
                    break;

                case AppDataActions.Update:
                    onUpdate?.Invoke(id);
                    break;*/
            }
        }

        // Global Logger/Debugger
        public static class Logger
        {
            public static void Trace(string message,
                [CallerMemberName] string caller = null,
                [CallerFilePath] string file = null,
                [CallerLineNumber] int line = 0)
            {
                if (AppSettings.IsDevelopment)
                {
                    WriteLogs("TRACE", message, ConsoleColor.Gray, caller, file, line);
                }
            }

            public static void Info(string message,
             [CallerMemberName] string caller = null,
             [CallerFilePath] string file = null,
             [CallerLineNumber] int line = 0)
            {
                if (!AppSettings.IsDevelopment) return;

                // Wrap lines at 100 characters
                //const int wrapLength = 150;
                //var wrappedMessage = WrapMessage("", message, wrapLength);

                WriteLogs("INFO", message, ConsoleColor.Cyan, caller, file, line);
            }


            public static void Warn(string message,
                [CallerMemberName] string caller = null,
                [CallerFilePath] string file = null,
                [CallerLineNumber] int line = 0)
            {
                if (AppSettings.IsDevelopment)
                {
                    WriteLogs("WARN", message, ConsoleColor.Yellow, caller, file, line);
                }
            }

            public static void Error(string message, Exception ex = null,
                [CallerMemberName] string caller = null,
                [CallerFilePath] string file = null,
                [CallerLineNumber] int line = 0)
            {
                if (!AppSettings.IsDevelopment) return;

                var sb = new StringBuilder();

                sb.AppendLine($"{message}");

                if (ex != null)
                {
                    sb.AppendLine($">[Reason]   : {ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message}");

                    sb.AppendLine($">[Exception]: {ex.GetType().Name} - {ex.Message}");

                    // Add all inner exceptions
                    var inner = ex.InnerException;
                    int depth = 1;
                    while (inner != null)
                    {
                        sb.AppendLine($" - [Inner#{depth}]    : {inner.GetType().Name} - {inner.Message}");
                        inner = inner.InnerException;
                        depth++;
                    }

                    sb.AppendLine(" - [StackTrace] :");
                    sb.AppendLine(ex.StackTrace);
                }

                WriteErrorLog("ERROR", sb.ToString(), ConsoleColor.Red, caller, file, line);
            }


            public static void Debug(string message,
                [CallerMemberName] string caller = null,
                [CallerFilePath] string file = null,
                [CallerLineNumber] int line = 0)
            {
                if (AppSettings.IsDevelopment)
                {
                    WriteLogs("DEBUG", message, ConsoleColor.DarkGray, caller, file, line);

                }
            }

            private static void WriteLogs(string level, string message, ConsoleColor color, string caller, string file, int line)
            {
                string fileName = Path.GetFileName(file);
                string folderName = Path.GetFileName(Path.GetDirectoryName(file));

                Console.WriteLine($"[{level}].[{DateTime.Now:MM-dd-yyyy HH:mm:ss}].[{caller}].[{folderName}/{fileName}:{line}]-{message}");
            }

            private static void WriteErrorLog(string level, string message, ConsoleColor color, string caller, string file, int line)
            {
                //Console.ForegroundColor = color;

                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // Extract filename and folder
                string fileName = Path.GetFileName(file);
                string folderName = Path.GetFileName(Path.GetDirectoryName(file));

                Console.WriteLine($"\n>[{level}]-[Timestamp] : {timestamp} --------------------------------------------------");
                Console.WriteLine($">[Method]   : {caller}");
                Console.WriteLine($">[Location] : {folderName}/{fileName}:{line}");
                Console.WriteLine($">[Message]  : {message}");
                Console.WriteLine($">-------------------------------------------------------------------------------------------");
                //Console.WriteLine(); // Optional: extra line space between logs

                //Console.ResetColor();
            }

            private static string WrapMessage(string label, string message, int maxLineLength)
            {
                var sb = new StringBuilder();
                var words = message.Split(' ');
                int currentLength = label.Length;

                sb.Append(label);
                foreach (var word in words)
                {
                    if (currentLength + word.Length + 1 > maxLineLength)
                    {
                        sb.AppendLine();
                        sb.Append("              "); // Indent continuation
                        currentLength = 13; // Indentation length
                    }

                    sb.Append(word + " ");
                    currentLength += word.Length + 1;
                }

                return sb.ToString().TrimEnd();
            }

        }

    }
}
