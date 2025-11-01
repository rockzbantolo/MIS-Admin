using Google.Protobuf.WellKnownTypes;
using MIS_Admin.Utilities.UI;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static MIS_Admin.Controller.OperationsCtrl;
using static MIS_Admin.Utilities.Functions;


namespace MIS_Admin.Modules
{
    public partial class Overview : UserControl
    {
        private bool isLoading { get; set; }

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
            //EnableDoubleBuffering(this);
            EnableDoubleBuffering(dgv_Services);
            EnableDoubleBuffering(dgv_Request);
            EnableDoubleBuffering(dgv_CloseTickets);
            ApplyRadiusToPanels(this, 8, Color.FromArgb(206, 214, 224));
            lb_TicketCount.Radius(6, Color.FromArgb(224, 224, 224));
            lb_RequestCount.Radius(6, Color.White);
            lb_HelpdeskCount.Radius(6, Color.White);
        }

        private async Task InitializedData()
        {

            isLoading = true;
            dgv_Services.Refresh();
            dgv_Request.Refresh();
            dgv_CloseTickets.Refresh();
            dgv_HelpdeskRequest.Refresh();

            await ServiceSummary();
            await SLASummary();

            BindTableToGrid(await getAllRecentServices(), dgv_Services);
            BindTableToGrid(await getAllServiceRequest(DateTime.Now), dgv_Request);
            BindTableToGrid(await getAllUnclosedTickets(), dgv_CloseTickets);
            BindTableToGrid(await getAllMonthlyServiceCount(), dgv_TotalServices);
            BindTableToGrid(await getAllHelpdeskRequest(), dgv_HelpdeskRequest);

            lb_RequestCount.Text = $"{dgv_Request.Rows.Count:N0}";
            lb_TicketCount.Text = $"{dgv_CloseTickets.Rows.Count:N0}";
            lb_HelpdeskCount.Text = $"{dgv_HelpdeskRequest.Rows.Count:N0}";

            isLoading = false;
            dgv_Services.Refresh();
            dgv_Request.Refresh();
            dgv_CloseTickets.Refresh();
            dgv_HelpdeskRequest.Refresh();

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

        private void Overview_Load(object sender, EventArgs e)
        {

        }

        private void dgv_Services_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ClearGridSelection(dgv_Services);
        }

        private void dgv_Services_Leave(object sender, EventArgs e)
        {
            ClearGridSelection(dgv_Services);
        }

        private void dgv_Request_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ClearGridSelection(dgv_Request);
        }

        private void dgv_Request_Leave(object sender, EventArgs e)
        {
            ClearGridSelection(dgv_Request);
        }

        private void dgv_CloseTickets_Leave(object sender, EventArgs e)
        {
            ClearGridSelection(dgv_CloseTickets);
        }

        private void dgv_CloseTickets_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ClearGridSelection(dgv_CloseTickets);
        }

        private void dgv_Request_Paint(object sender, PaintEventArgs e)
        {
            if (dgv_Request.Rows.Count == 0)
            {
                string msg = isLoading ? "Fetching request ..." : "No records found.";
                LoadingGridMessage(dgv_Request, e, msg);
            }
        }

        private void dgv_Services_Paint(object sender, PaintEventArgs e)
        {
            if (dgv_Services.Rows.Count == 0)
            {
                string msg = isLoading ? "Fetching services ..." : "No records found.";
                LoadingGridMessage(dgv_Services, e, msg);
            }
        }

        private void dgv_CloseTickets_Paint(object sender, PaintEventArgs e)
        {
            if (dgv_CloseTickets.Rows.Count == 0)
            {
                string msg = isLoading ? "Fetching Unclosed Tickets ..." : "No records found.";
                LoadingGridMessage(dgv_CloseTickets, e, msg);
            }
        }

        private void dgv_HelpdeskRequest_Paint(object sender, PaintEventArgs e)
        {
            if (dgv_HelpdeskRequest.Rows.Count == 0)
            {
                string msg = isLoading ? "Fetching Helpdesk Requests ..." : "No records found.";
                LoadingGridMessage(dgv_HelpdeskRequest, e, msg);
            }
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
                case "COMPLETED":
                    fore = Color.DarkGreen;
                    break;
                case "ALLOCATED":
                    fore = Color.Blue;
                    break;
                case "PROCESSING":
                    fore = Color.Yellow;
                    break;
            }

            // apply style
            e.CellStyle.BackColor = back;
            e.CellStyle.ForeColor = fore;
            e.CellStyle.SelectionBackColor = back;
            e.CellStyle.SelectionForeColor = fore;
            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
        }
    }
}
