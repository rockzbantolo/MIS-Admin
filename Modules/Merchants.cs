using MIS_Admin.Forms;
using MIS_Admin.Utilities.Handler;
using MIS_Admin.Utilities.UI;
using Prime.Extentions;
using Prime.UI;
using System.Data;
using static MIS_Admin.Controller.OperationsCtrl;
using static MIS_Admin.Model.Authenticate;
using static MIS_Admin.Utilities.Functions;

namespace MIS_Admin.Modules
{
    public partial class Merchants : UserControl, IKeyHandler
    {
        private readonly UserSession _session;
        private string currentMode = null;

        private bool isLoading { get; set; }

        public Merchants(UserSession session)
        {
            InitializeComponent();
            _session = session;
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeHelpers();
            await InitializedData();
        }

        private void InitializeHelpers()
        {
            //EnableDoubleBuffering(pn_Body);
            EnableDoubleBuffering(dgv_Services);
            pn_Nav.Round(8, Color.FromArgb(223, 228, 234));
            pn_Body.Round(8, Color.White);

            pn_MM.Round(8, Color.FromArgb(232, 65, 24));
            pn_Prov.Round(8, Color.FromArgb(232, 65, 24));
            pn_Duplicate.Round(8, Color.FromArgb(232, 65, 24));
            pn_Total.Round(8, Color.FromArgb(232, 65, 24));
            dgv_Services.Round(8, Color.FromArgb(224, 224, 224));

        }

        private async Task InitializedData()
        {
            RoleChecked(_session);
            await DisplayData();
        }

        private void RoleChecked(UserSession session)
        {
            if (!session.Role.Equals("ADMIN", StringComparison.OrdinalIgnoreCase))
            {
                dgv_Services.Columns["ColBtnUpdate"].Visible = false;
                dgv_Services.Columns["ColBtnReplace"].Visible = false;
                dgv_Services.Columns["ColBtnDelete"].Visible = false;
            }
        }

        private async Task InstalledTerminalCount()
        {
            DataTable dt = await getAllInstalledTerminalCount();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lb_Manila.Text = row["Manila"].ToString();
                lb_Province.Text = row["Province"].ToString();
                lb_Duplicate.Text = row["Duplicates"].ToString();
                lb_Total.Text = row["Total"].ToString();
            }
        }

        private async Task getMerchantDetails(string filter = null, string mode = null)
        {
            var data = await getAllMerchantAsync(filter, mode);
            BindTableToGrid(data, dgv_Services);
        }

        public async void OnEnterPressed()
        {
            BindTableToGrid(await getAllMerchantAsync(txt_Search.Text), dgv_Services);
        }

        public void OnEscapePressed()
        {
            //throw new NotImplementedException();
        }

        public void OnF1Pressed()
        {
            //throw new NotImplementedException();
        }

        private async Task DisplayData()
        {
            isLoading = true;
            dgv_Services.Refresh();

            await InstalledTerminalCount();
            await getMerchantDetails(currentMode);

            isLoading = false;
            dgv_Services.Refresh();
        }

        private void ReplaceDevice(DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(dgv_Services.Rows[e.RowIndex].Cells["ColID"].Value);

            using (var frm = new DeviceReplaceForm(id))
                frm.ShadowBackground(new Main());
        }

        private async Task PullOutMerchantRecord(DataGridViewCellEventArgs e)
        {
            // Safely get the ID
            var cellValue = dgv_Services.Rows[e.RowIndex].Cells["ColID"].Value;

            if (cellValue == null || !int.TryParse(cellValue.ToString(), out int id))
            {
                MessageBox.Show("Invalid ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ask for confirmation
            if (MessageBox.Show(
                    "Are you sure you want to pull out this merchant?",
                    "Confirm Pull-Out",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // Execute pull-out
            var result = PulledOutMerchant(id);

            // Show result message
            MessageBox.Show(result.Message,
                result.Success ? "Success" : "Error",
                MessageBoxButtons.OK,
                result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            await DisplayData();
        }

        private void dgv_Services_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ClearGridSelection(dgv_Services);
        }

        private void dgv_Services_Leave(object sender, EventArgs e)
        {
            ClearGridSelection(dgv_Services);
        }

        private void dgv_Services_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Handle Status column color coding
            if (dgv_Services.Columns[e.ColumnIndex].HeaderText == "Status" && e.Value != null)
            {
                string status = e.Value.ToString().Trim().ToUpperInvariant();

                Color back = Color.White;
                Color fore = Color.Black;

                switch (status)
                {
                    case "AVAILABLE":
                        fore = Color.DarkGreen;
                        break;

                    case "ACTIVE":
                        fore = Color.Green;
                        break;

                    case "INACTIVE":
                        fore = Color.DarkGray;
                        break;

                    case "ASSIGNED":
                        fore = Color.SteelBlue;
                        break;

                    case "DISPATCH":
                        fore = Color.Orange;
                        break;
                }

                e.CellStyle.BackColor = back;
                e.CellStyle.ForeColor = fore;
                e.CellStyle.SelectionBackColor = back;
                e.CellStyle.SelectionForeColor = fore;

            }
            if (e.Value != null && e.Value.ToString().Trim().Equals("N/A", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.ForeColor = Color.Gray;
                e.CellStyle.Font = new Font(dgv_Services.Font, FontStyle.Italic);
            }
        }

        private async void dgv_Services_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            //int IrId       = Convert.ToInt32(dgv_Services.Rows[e.RowIndex].Cells[0].Value);
            //int merchantId = Convert.ToInt32(dgv_Services.Rows[e.RowIndex].Cells[0].Value);
            //var Tid        = dgv_Services.CurrentRow.Cells[0].Value?.ToString();
            //var Mid        = dgv_Services.CurrentRow.Cells[0].Value?.ToString();
            //var merchantName = dgv_Services.CurrentRow.Cells[0].Value?.ToString();

            var columnName = dgv_Services.Columns[e.ColumnIndex].Name;

            switch (columnName)
            {
                case "ColBtnReplace":
                    ReplaceDevice(e);
                    break;

                case "ColBtnDelete":
                    await PullOutMerchantRecord(e);
                    break;
            }
        }

        private void dgv_Services_Paint(object sender, PaintEventArgs e)
        {
            if (dgv_Services.Rows.Count == 0)
            {
                string msg = isLoading ? "Fetching Merchants ..." : "No records found.";
                //LoadingGridMessage(dgv_Services, e, msg);
                dgv_Services.Overlay(msg);
            }
        }

        private async void lb_Manila_Click(object sender, EventArgs e)
        {
            currentMode = "MANILA";
            await getMerchantDetails(null, currentMode);
        }

        private async void lb_Province_Click(object sender, EventArgs e)
        {
            currentMode = "PROVINCE";
            await getMerchantDetails(null, currentMode);
        }
       
        private async void lb_Duplicate_Click(object sender, EventArgs e)
        {
            currentMode = "DUPLICATE";
            await getMerchantDetails(null, currentMode);
        }

        private async void pb_Icon_Click(object sender, EventArgs e)
        {
            currentMode = null;
            await getMerchantDetails(null, currentMode);
        }

    }
}
