using MIS_Admin.Services;
using Next.Controls.Extention;
using System.Data;
using static MIS_Admin.Utilities.Functions.Theme;
using static Next.Controls.Extention.Gridviews;
using static Next.Controls.Extention.Labels;
using static Next.Controls.Extention.Radius;

namespace MIS_Admin.Modules
{
    public partial class Overview : UserControl
    {
        private readonly OpsOverview _Ops;

        private Dictionary<string, List<LabelBinding>> CountMap;

        public Overview()
        {
            InitializeComponent();
            _Ops = new OpsOverview();
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
            this.BackColor = BackColor;

            // Apply Radius to Controls
            new RadiusBatch()
                .Default(radius: 8, borderColor: BodyColor, width: 1)
                .Add(lb_RequestCount, lb_HelpdeskCount, lb_TicketCount)
                .AddToAllChildren(this, c => c is Panel, radius: 12, borderColor: BackColor)
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
                LoadLabelsAsync(_Ops.GetJobOrderSummaryAsync(), "Description", CountMap),

                // Grid Data
                new GridLoaderBatch()
                .Add(dgv_Services,          _Ops.GetRecentJobOrdersAsync(), "Loading Services...", "No Services Found.")
                .Add(dgv_Request,           _Ops.GetJobOrderRequestAsync(), "Loading Requests...", "No Requests Found.")
                .Add(dgv_CloseTickets,      _Ops.GetUnclosedTicketsAsync(), "Loading Tickets...", "No Tickets Found.")
                .Add(dgv_TotalServices,     _Ops.GetMonthlyJobOrderCountAsync(), "Loading Details...", "No Summary Found.")
                .Add(dgv_HelpdeskRequest,   _Ops.GetHelpdeskRequestAsync(), "Loading Helpdesk Requests...", "No Requests Found.")
                .RunAsync()
            );
        }

        private async Task SLASummary()
        {
            DataTable dt = await _Ops.GetMonthlySlaAsync();

            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                lb_Beyond.Text = row["Beyond"]?.ToString() ?? "0";
                lb_Within.Text = row["Within"]?.ToString() ?? "0";
            }
        }

        private void dgv_Services_Leave(object sender, EventArgs e)
        {
            dgv_Services.ClearSelection();
        }

        private void dgv_Request_Leave(object sender, EventArgs e)
        {
            dgv_Request.ClearSelection();
        }

        private void dgv_CloseTickets_Leave(object sender, EventArgs e)
        {
            dgv_CloseTickets.ClearSelection();
        }

        private void dgv_Services_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var ServiceStatus = new Dictionary<string, (Color back, Color fore)>
            {
                { "DISPATCHED",  (BodyColor, StatusColor.Warning) },
                { "INSTALLED",   (BodyColor, StatusColor.Success) },
                { "COMPLETED",   (BodyColor, StatusColor.Success) },
                { "ASSIGNED",    (BodyColor, StatusColor.Assigned) },
                { "PROCESSING",  (BodyColor, StatusColor.Processing) },
                { "NO RESPONSE", (BodyColor, StatusColor.Inactive) },
                { "FAILED",      (BodyColor, StatusColor.Inactive) }
            };

            dgv_CloseTickets.ApplyStatusStyle(e, "Status", ServiceStatus);
        }

        private void dgv_CloseTickets_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var TicketsStatus = new Dictionary<string, (Color back, Color fore)>
            {
                { "NEGATIVE",  (BodyColor, StatusColor.Critical) },
                { "COMPLETED", (BodyColor, StatusColor.Success) }
            };

            dgv_CloseTickets.ApplyStatusStyle(e, "Status", TicketsStatus);
        }

        private void dgv_HelpdeskRequest_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var HdStatus = new Dictionary<string, (Color back, Color fore)>
            {
                { "DISPATCHED", (BodyColor, StatusColor.Warning) },
                { "ASSIGNED",   (BodyColor, StatusColor.Assigned) },
                { "PROCESSING", (BodyColor, StatusColor.Processing) },
                { "PENDING",    (BodyColor, StatusColor.Info) }
            };

            dgv_HelpdeskRequest.ApplyStatusStyle(e, "Status", HdStatus);
        }
    }
}
