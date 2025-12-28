using MIS_Admin.Utilities.UI;
using Next.Common;
using Next.Controls.Extention;
using System.Data;
using static MIS_Admin.Controller.OperationsCtrl;
using static MIS_Admin.Utilities.Functions;
using static Next.Controls.Extention.Gridviews;


namespace MIS_Admin.Modules
{
    public partial class Overview : UserControl
    {
        public Overview()
        {
            InitializeComponent();
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeHelpers();
            await InitializedData();
        }

        private void InitializeHelpers()
        {
            ApplyRadiusToPanels(this, 8, Color.FromArgb(206, 214, 224));
            lb_TicketCount.Radius(6, Color.FromArgb(224, 224, 224));
            lb_RequestCount.Radius(6, Color.White);
            lb_HelpdeskCount.Radius(6, Color.White);
        }

        public static Task<IResult> LoadGridAsync<T>(
            DataGridView dgv,
            Task<T> dataTask,
            string loadingMessage = "Loading...",
            string emptyMessage = "No data found")
        {
            return dgv.BindDataWithLoaderAsync(
                dataTask,
                loadingMessage,
                emptyMessage,
                Color.Gray,
                minSpinnerMilliseconds: 2000,
                loaderType: LoaderType.Skeleton
            );
        }

        private async Task InitializedData()
        {
            await LoadDashboard();
            await ServiceSummary();
            await SLASummary();

            lb_RequestCount.Text = $"{dgv_Request.Rows.Count:N0}";
            lb_TicketCount.Text = $"{dgv_CloseTickets.Rows.Count:N0}";
            lb_HelpdeskCount.Text = $"{dgv_HelpdeskRequest.Rows.Count:N0}";

        }

        private async Task LoadDashboard()
        {
            var tasks = new List<Task>
            {
                LoadGridAsync(dgv_Services, getAllRecentServices(), "Loading Services ...", "No Services Found."),
                LoadGridAsync(dgv_Request, getAllServiceRequest(DateTime.Now), "Loading Request ...", "No Request Found."),
                LoadGridAsync(dgv_CloseTickets, getAllUnclosedTickets(), "Loading Tickets ...", "No Request Found."),
                LoadGridAsync(dgv_TotalServices, getAllMonthlyServiceCount(), "Loading Details ...", "No Summary Found."),
                LoadGridAsync(dgv_HelpdeskRequest, getAllHelpdeskRequest(), "Loading Helpdesk Request ...", "No Request Found."),
            };

            await Task.WhenAll(tasks);
        }

        private async Task ServiceSummary()
        {
            DataTable dt = await getAllServiceSummary();

            int total = 0, completed = 0, pending = 0, negative = 0, dispatch = 0;

            var map = new Dictionary<string, (Label Total, Label Completed, Label Pending, Label Negative, Label Dispatch)>
            {
                ["INSTALLATION"] = (lb_Ins_Total, lb_Ins_Completed, lb_Ins_Pending, lb_Ins_Negative, lb_Ins_Dispatch),
                ["REPROGRAMMING"] = (lb_Repr_Total, lb_Repr_Completed, lb_Repr_Pending, lb_Repr_Negative, lb_Repr_Dispatch),
                ["PULL-OUT"] = (lb_Pull_Total, lb_Pull_Completed, lb_Pull_Pending, lb_Pull_Negative, lb_Pull_Dispatch),
                ["SERVICING"] = (lb_Serv_Total, lb_Serv_Completed, lb_Serv_Pending, lb_Serv_Negative, lb_Serv_Dispatch),
                ["REPLACEMENT"] = (lb_Rep_Total, lb_Rep_Completed, lb_Rep_Pending, lb_Rep_Negative, lb_Rep_Dispatch),
            };

            foreach (DataRow row in dt.Rows)
            {
                string desc = row["Description"].ToString();

                if (map.TryGetValue(desc, out var labels))
                {
                    labels.Total.Text = row["Total"].ToString();
                    labels.Completed.Text = row["Completed"].ToString();
                    labels.Pending.Text = row["Pending"].ToString();
                    labels.Negative.Text = row["Negative"].ToString();
                    labels.Dispatch.Text = row["Dispatch"].ToString();
                }

                // add to grand totals
                int.TryParse(row["Total"].ToString().Replace(",", ""), out int t); total += t;
                int.TryParse(row["Completed"].ToString().Replace(",", ""), out int c); completed += c;
                int.TryParse(row["Pending"].ToString().Replace(",", ""), out int p); pending += p;
                int.TryParse(row["Negative"].ToString().Replace(",", ""), out int n); negative += n;
                int.TryParse(row["Dispatch"].ToString().Replace(",", ""), out int d); dispatch += d;
            }

            // overall totals
            lb_Total.Text = total.ToString();
            lb_Total_Completed.Text = completed.ToString();
            lb_Total_Pending.Text = pending.ToString();
            lb_Total_Negative.Text = negative.ToString();
            lb_Total_Dispatch.Text = dispatch.ToString();
        }

        private async Task SLASummary()
        {
            DataTable dt = await getAllMonthlySLACount();

            if (dt != null && dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];

                lb_Beyond.Text = row["Beyond"].ToString();
                lb_Within.Text = row["Within"].ToString();
            }
        }

        private void ApplyRadiusToPanels(Control parent, int radius, Color backColor)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is Panel panel)
                {
                    panel.Radius(radius, backColor);
                }

                // Recursively apply to child containers (if panels are nested)
                if (ctrl.HasChildren)
                {
                    ApplyRadiusToPanels(ctrl, radius, backColor);
                }
            }
        }

        private void dgv_Services_Leave(object sender, EventArgs e)
        {
            ClearGridSelection(dgv_Services);
        }

        private void dgv_Request_Leave(object sender, EventArgs e)
        {
            ClearGridSelection(dgv_Request);
        }

        private void dgv_CloseTickets_Leave(object sender, EventArgs e)
        {
            ClearGridSelection(dgv_CloseTickets);
        }

        private void dgv_Services_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_Services.Columns[e.ColumnIndex].HeaderText != "Status" || e.Value == null)
                return;

            string status = e.Value.ToString().Trim().ToUpperInvariant();

            Color back = Color.White;
            Color fore = Color.Black;

            switch (status)
            {
                case "DISPATCHED":
                    fore = Color.Orange;
                    break;
                case "INSTALLED":
                case "COMPLETED":
                    fore = Color.DarkGreen;
                    break;
                case "ASSIGNED":
                    fore = Color.SteelBlue;
                    break;
                case "PROCESSING":
                    fore = Color.Teal;
                    break;
                case "NO RESPONSE":
                    fore = Color.DarkGray;
                    break;
            }

            // apply style
            e.CellStyle.BackColor = back;
            e.CellStyle.ForeColor = fore;
            e.CellStyle.SelectionBackColor = back;
            e.CellStyle.SelectionForeColor = fore;
        }

        private void dgv_CloseTickets_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_CloseTickets.Columns[e.ColumnIndex].HeaderText != "Status" || e.Value == null)
                return;

            string status = e.Value.ToString().Trim().ToUpperInvariant();

            Color back = Color.White;
            Color fore = Color.Black;

            switch (status)
            {
                case "NEGATIVE":
                    fore = Color.Red;
                    break;
                case "COMPLETED":
                    fore = Color.DarkGreen;
                    break;
            }

            // apply style
            e.CellStyle.BackColor = back;
            e.CellStyle.ForeColor = fore;
            e.CellStyle.SelectionBackColor = back;
            e.CellStyle.SelectionForeColor = fore;
        }

        private void dgv_HelpdeskRequest_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_HelpdeskRequest.Columns[e.ColumnIndex].HeaderText != "Status" || e.Value == null)
                return;

            string status = e.Value.ToString().Trim().ToUpperInvariant();

            Color back = Color.White;
            Color fore = Color.Black;

            switch (status)
            {
                case "DISPATCHED":
                    fore = Color.Orange;
                    break;
                case "ASSIGNED":
                    fore = Color.SteelBlue;
                    break;
                case "PROCESSING":
                    fore = Color.Teal;
                    break;
                case "PENDING":
                    fore = Color.YellowGreen;
                    break;
            }

            // apply style
            e.CellStyle.BackColor = back;
            e.CellStyle.ForeColor = fore;
            e.CellStyle.SelectionBackColor = back;
            e.CellStyle.SelectionForeColor = fore;
        }
    }
}
