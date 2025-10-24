using MIS_Admin.Forms;
using MIS_Admin.Utilities.Handler;
using MIS_Admin.Utilities.UI;
using System.Data;
using static MIS_Admin.Controller.OperationsCtrl;
using static MIS_Admin.Utilities.Functions;
using static MIS_Admin.Utilities.Notifications;

namespace MIS_Admin.Modules
{
    public partial class Servicing : UserControl, IKeyHandler
    {
        private bool isLoading { get; set; }

        public Servicing()
        {
            InitializeComponent();
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //ShowWindowsNotification("Servicing", "Theres a new incoming service", ToolTipIcon.Info);
            InitializeHelpers();
            await InitializedData();
        }

        private void InitializeHelpers()
        {
            //EnableDoubleBuffering(pn_Body);
            EnableDoubleBuffering(dgv_Services);
            pn_Nav.Radius(8, Color.FromArgb(206, 214, 224));
            pn_Body.Radius(8, Color.White);
            btn_New.Radius(8, Color.White);
            dgv_Services.Radius(8, Color.FromArgb(224, 224, 224));
            panel1.Radius(8, Color.FromArgb(39, 60, 117));
            panel2.Radius(8, Color.FromArgb(39, 60, 117));
        }

        private async Task InitializedData()
        {
            isLoading = true;
            dgv_Services.Refresh();

            BindTableToGrid(await getAllServicesAsync(), dgv_Services);
            await AreaSummary();

            isLoading = false;
            dgv_Services.Refresh();

        }

        // Key pressed Events
        public async void OnEnterPressed()
        {
            //dgv_Services.DataSource = getAllServices(txt_Search.Text);
            BindTableToGrid(await getAllServicesAsync(txt_Search.Text), dgv_Services);
        }

        private async Task AreaSummary()
        {
            DataTable dt = await getAllAreaSummary();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lb_Manila.Text = row["Manila"].ToString();
                lb_Province.Text = row["Province"].ToString();
                //lblTotal.Text = row["Total"].ToString();
            }
        }

        public void OnEscapePressed()
        {
            //throw new NotImplementedException();
        }

        public void OnF1Pressed()
        {
            //throw new NotImplementedException();
        }

        private void dgv_Services_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;

            string value = e.Value.ToString().Trim();
            var cell = dgv_Services.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var column = dgv_Services.Columns[e.ColumnIndex];

            // Handle N/A
            if (value.Equals("N/A", StringComparison.OrdinalIgnoreCase))
            {
                cell.Style.ForeColor = Color.Gray;
                cell.Style.Font = new Font(dgv_Services.Font, FontStyle.Italic);
                return;
            }

            // Handle Priority column
            if (column.HeaderText == "Priority")
            {
                cell.Style.Font = new Font(dgv_Services.Font, FontStyle.Bold);

                switch (value)
                {
                    case "Normal":
                        cell.Style.ForeColor = Color.Green;
                        break;
                    case "Medium":
                        cell.Style.ForeColor = Color.Orange;
                        break;
                    case "High":
                        cell.Style.ForeColor = Color.DarkOrange;
                        break;
                    case "Critical":
                        cell.Style.ForeColor = Color.Red;
                        break;
                    default:
                        cell.Style.ForeColor = Color.Black;
                        break;
                }
            }
        }

        private void dgv_Services_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new ServiceDetailsForm().Show();
        }

        private void Servicing_Load(object sender, EventArgs e)
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

        private void btn_New_Click(object sender, EventArgs e)
        {
            new ServiceDetailsForm().ShadowBackground(new Main());
        }

        private void dgv_Services_Paint(object sender, PaintEventArgs e)
        {
            if (dgv_Services.Rows.Count == 0)
            {
                string msg = isLoading ? "Fetching Services ..." : "No records found.";
                LoadingGridMessage(dgv_Services, e, msg);
            }
        }
    }
}
