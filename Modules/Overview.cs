using MIS_Admin.Services;
using Next.Controls.Extention;
using System.Data;
using static MIS_Admin.Utilities.Functions;
using static Next.Controls.Extention.Gridviews;
using static Next.Controls.Extention.Labels;
using static Next.Controls.Extention.Radius;


namespace MIS_Admin.Modules
{
    public partial class Overview : UserControl
    {
        private readonly OpsService _Ops;
        private Dictionary<string, List<LabelBinding>> CountMap;

        public Overview()
        {
            _Ops = new OpsService();
            InitializeComponent();
        }

        // Base Load
        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeHelpers();
            await InitializedData();
        }

        private void InitializeHelpers()
        {   
            // Apply Radius to Controls
            new RadiusBatch()
                .Default(radius: 6, borderColor: Color.White, width: 1)
                .Add(lb_RequestCount, lb_HelpdeskCount)
                .Add(lb_TicketCount, borderColor: Color.FromArgb(224, 224, 224))
                .AddToAllChildren(this, c => c is Panel, radius: 8, borderColor: Color.FromArgb(223, 228, 234))
                .Apply();
        }

        private async Task InitializedData()
        {
            await LoadDashboard();
            lb_RequestCount.Text = $"{dgv_Request.Rows.Count:N0}";
            lb_TicketCount.Text = $"{dgv_CloseTickets.Rows.Count:N0}";
            lb_HelpdeskCount.Text = $"{dgv_HelpdeskRequest.Rows.Count:N0}";
        }

        private async Task LoadDashboard()
        {
            // Define the Column names
            string[] ServiceCountColumns =
            {
                "Total",
                "Completed",
                "Pending",
                "Negative",
                "Dispatch"
            };

            // Map the Labels
            CountMap = new Dictionary<string, List<LabelBinding>>(StringComparer.OrdinalIgnoreCase)
            {
                ["INSTALLATION"] = BindGroupLabel(
                ServiceCountColumns,
                    lb_Ins_Total, lb_Ins_Completed, lb_Ins_Pending, lb_Ins_Negative, lb_Ins_Dispatch),

                ["REPROGRAMMING"] = BindGroupLabel(
                ServiceCountColumns,
                    lb_Repr_Total, lb_Repr_Completed, lb_Repr_Pending, lb_Repr_Negative, lb_Repr_Dispatch),

                ["PULL-OUT"] = BindGroupLabel(
                ServiceCountColumns,
                    lb_Pull_Total, lb_Pull_Completed, lb_Pull_Pending, lb_Pull_Negative, lb_Pull_Dispatch),

                ["SERVICING"] = BindGroupLabel(
                ServiceCountColumns,
                    lb_Serv_Total, lb_Serv_Completed, lb_Serv_Pending, lb_Serv_Negative, lb_Serv_Dispatch),

                ["REPLACEMENT"] = BindGroupLabel(
                ServiceCountColumns,
                    lb_Rep_Total, lb_Rep_Completed, lb_Rep_Pending, lb_Rep_Negative, lb_Rep_Dispatch),

                ["ALL SERVICES"] = BindGroupLabel(
                ServiceCountColumns,
                    lb_Total, lb_Total_Completed, lb_Total_Pending, lb_Total_Negative, lb_Total_Dispatch)
            };

            // Get All Data
            await Task.WhenAll(
                SLASummary(),
                LoadLabelsAsync(_Ops.GetServiceSummaryAsync(), "Description", CountMap),

                // Grid Data
                new GridLoaderBatch()
                .Add(dgv_Services,          _Ops.GetRecentServicesAsync(), "Loading Services...", "No Services Found.")
                .Add(dgv_Request,           _Ops.GetServiceRequestAsync(), "Loading Requests...", "No Requests Found.")
                .Add(dgv_CloseTickets,      _Ops.GetUnclosedTicketsAsync(), "Loading Tickets...", "No Tickets Found.")
                .Add(dgv_TotalServices,     _Ops.GetMonthlyServiceCountAsync(), "Loading Details...", "No Summary Found.")
                .Add(dgv_HelpdeskRequest,   _Ops.GetHelpdeskRequestAsync(), "Loading Helpdesk Requests...", "No Requests Found.")
                .RunAsync()
            );
        }

        private async Task SLASummary()
        {
            DataTable dt = await _Ops.GetMonthlySLAAsync();

            if (dt != null && dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];

                lb_Beyond.Text = row["Beyond"].ToString();
                lb_Within.Text = row["Within"].ToString();
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
            var TicketsStatus = new Dictionary<string, (Color back, Color fore)>
            {
                { "NEGATIVE", (Color.White, Color.Red) },
                { "COMPLETED", (Color.White, Color.Green) }
            };

            dgv_CloseTickets.ApplyStatusStyle(e, "Status", TicketsStatus);
        }

        private void dgv_HelpdeskRequest_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var HdStatus = new Dictionary<string, (Color back, Color fore)>
            {
                { "DISPATCHED", (Color.White, Color.Orange) },
                { "ASSIGNED", (Color.White, Color.SteelBlue) },
                { "PROCESSING", (Color.White, Color.Teal) },
                { "PENDING", (Color.White, Color.YellowGreen) }
            };

            dgv_HelpdeskRequest.ApplyStatusStyle(e, "Status", HdStatus);
        }
    }
}
