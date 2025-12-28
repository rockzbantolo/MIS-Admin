using MIS_Admin.Forms;
using MIS_Admin.Utilities.Handler;
using MIS_Admin.Utilities.UI;
using Next.Controls;
using Next.Controls.Extention;
using System.Data;
using System.Windows.Forms;
using static MIS_Admin.Controller.OperationsCtrl;
using static MIS_Admin.Utilities.Functions;
using static Next.Controls.Extention.Gridviews;

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
            //EnableDoubleBuffering(dgv_Services);
            //dgv_Services.EnabledBuffer();
            pn_Nav.Radius(8, Color.FromArgb(223, 228, 234));
            pn_Body.Radius(8, Color.White);
            btn_New.Radius(8, Color.White);
            dgv_Services.Radius(8, Color.FromArgb(224, 224, 224));
            pn_MM.Radius(8, Color.FromArgb(39, 60, 117));
            pn_Prov.Radius(8, Color.FromArgb(39, 60, 117));
            pn_Total.Radius(8, Color.FromArgb(39, 60, 117));
        }

        private async Task InitializedData()
        {
            await dgv_Services.BindDataWithLoaderAsync(getAllServicesAsync(), "Loading Services ...", "No Services Found.");
            await AreaSummary();
        }

        // Key pressed Events
        public async void OnEnterPressed()
        {
            dgv_Services.BindData(await getAllServicesAsync(txt_Search.Text));
        }

        private async Task AreaSummary()
        {
            DataTable dt = await getAllServiceAreaSummary();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lb_Manila.Text = row["Manila"].ToString();
                lb_Province.Text = row["Province"].ToString();
                lb_Total.Text = row["Total"].ToString();
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
                switch (value)
                {
                    case "NORMAL":
                        cell.Style.ForeColor = Color.Green;
                        break;
                    case "MEDIUM":
                        cell.Style.ForeColor = Color.Orange;
                        break;
                    case "HIGH":
                        cell.Style.ForeColor = Color.DarkOrange;
                        break;
                    case "CRITICAL":
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
            //new ServiceDetailsForm().ShadowBackground(new Main());
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
            new ServiceDetailsForm().ShowWithDimmedBackground(new Main());
        }

        private void dgv_Services_Paint(object sender, PaintEventArgs e)
        {
            /*
            if (dgv_Services.Rows.Count == 0)
            {
                string msg = isLoading ? "Fetching Services ..." : "No records found.";
                LoadingGridMessage(dgv_Services, e, msg);
            }
            */
        }
    }
}
