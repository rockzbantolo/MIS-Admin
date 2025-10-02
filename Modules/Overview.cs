using MIS_Admin.Utilities.UI;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using static MIS_Admin.Controller.OperationsCtrl;
using static MIS_Admin.Utilities.Functions;


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
            //EnableDoubleBuffering(dataGridView1);
            //EnableDoubleBuffering(dgv_Services);
            //EnableDoubleBuffering(dgv_Request);
            ApplyRadiusToPanels(this, 11, Color.FromArgb(224, 224, 224));
        }

        private async Task InitializedData()
        {
            dgv_Services.DataSource = await getAllRecentServices();

            dgv_Request.DataSource = await getAllServiceRequest(DateTime.Now);
            lb_RequestCount.Text = $"{dgv_Request.Rows.Count:N0}";

            dgv_CloseTickets.DataSource = await getAllUnclosedTickets(null);
            lb_TicketCount.Text = $"{dgv_CloseTickets.Rows.Count:N0}";

            await ServiceSummary();
        }

        private async Task ServiceSummary()
        {
            DataTable dt = await getAllServiceSummary(null);

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
            lb_Total.Text = total.ToString("N0");
            lb_Total_Completed.Text = completed.ToString("N0");
            lb_Total_Pending.Text = pending.ToString("N0");
            lb_Total_Negative.Text = negative.ToString("N0");
            lb_Total_Dispatch.Text = dispatch.ToString("N0");
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

        private void dgv_CloseTickets_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ClearGridSelection(dgv_CloseTickets);
        }

        private void dgv_Request_Paint(object sender, PaintEventArgs e)
        {
            if (dgv_Request.Rows.Count == 0)
            {
                LoadingMessage(dgv_Services, e, "Loading Requests ...", 1, 3);
            }
        }

        private void dgv_Services_Paint(object sender, PaintEventArgs e)
        {
            if (dgv_Services.Rows.Count == 0)
            {
                LoadingMessage(dgv_Services, e, "Loading Services ...", 2, 3);
            }
        }

        private void dgv_CloseTickets_Paint(object sender, PaintEventArgs e)
        {
            if (dgv_Services.Rows.Count == 0)
            {
                LoadingMessage(dgv_CloseTickets, e, "Loading Services ...", 2, 2);
            }
        }
    
    }
}
