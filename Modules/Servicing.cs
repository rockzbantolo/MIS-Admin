using MIS_Admin.Forms;
using MIS_Admin.Utilities.Handler;
using MIS_Admin.Utilities.UI;
using static MIS_Admin.Controller.OperationsCtrl;
using static MIS_Admin.Utilities.Functions;
using static MIS_Admin.Utilities.Notifications;

namespace MIS_Admin.Modules
{
    public partial class Servicing : UserControl, IKeyHandler
    {
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
            pn_Nav.Radius(8, Color.FromArgb(39, 60, 117));
            pn_Body.Radius(8, Color.White);
            dgv_Services.Radius(8, Color.FromArgb(224, 224, 224));
        }

        private async Task InitializedData()
        {
            dgv_Services.DataSource = await getAllServicesAsync();
        }

        // Key pressed Events
        public void OnEnterPressed()
        {
            dgv_Services.DataSource = getAllServices(txt_Search.Text);
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
            if (dgv_Services.Columns[e.ColumnIndex].Name == "Priority" && e.Value != null)
            {
                var priority = e.Value.ToString();
                var cell = dgv_Services.Rows[e.RowIndex].Cells[e.ColumnIndex];

                cell.Style.Font = new Font(dgv_Services.Font, FontStyle.Bold);

                switch (priority)
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
            ServiceDetailsForm Servicing = new ServiceDetailsForm();
            Servicing.Show();
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
    }
}
