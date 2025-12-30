using MIS_Admin.Forms;
using MIS_Admin.Services;
using MIS_Admin.Utilities.Handler;
using MIS_Admin.Utilities.UI;
using Next.Controls;
using Next.Controls.Extention;
using System.Data;
using static MIS_Admin.Model.Authenticate;
using static MIS_Admin.Utilities.Functions;
using static Next.Controls.Extention.Radius;

namespace MIS_Admin.Modules
{
    public partial class Merchants : UserControl, IKeyHandler
    {
        private readonly UserSession _session;
        private readonly OpsService _Ops;
        private string currentMode = null;

        private bool isLoading { get; set; }

        public Merchants(UserSession session)
        {
            InitializeComponent();
            _session = session;
            _Ops = new OpsService();
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeHelpers();
            await InitializedData();
        }

        private void InitializeHelpers()
        {
            dgv_Services.EnabledBuffer();

            new RadiusBatch()
            .Default(radius: 8, borderColor: Color.FromArgb(232, 65, 24), width: 1)
            .Add(pn_MM, pn_Prov, pn_Total, pn_Duplicate, pn_Total)
            .Add(pn_Body, borderColor: Color.White)
            .Add(pn_Nav, borderColor: Color.FromArgb(223, 228, 234))
            .Add(dgv_Services, borderColor: Color.FromArgb(224, 224, 224))
            .Apply();
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
            DataTable dt = await _Ops.GetInstalledTerminalCountAsync();

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
            var data = await _Ops.GetMerchantAsync(filter, mode);
            BindTableToGrid(data, dgv_Services);
        }

        public async void OnEnterPressed()
        {
            BindTableToGrid(await _Ops.GetMerchantAsync(txt_Search.Text), dgv_Services);
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

        private async void PullOutMerchantRecord(DataGridViewCellEventArgs e)
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
            {
                return;
            }

            try
            {
                // Await the async operation
                var result = await _Ops.SetPullOutMerchantAsync(id);

                // Show result message
                MessageBox.Show(
                    result.Message ?? "Operation completed.",
                    result.Success ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An unexpected error occurred: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // Refresh the grid regardless of success/failure
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
            var serviceStatusRules = new Dictionary<string, (Color back, Color fore)>
            {
                { "AVAILABLE", (Color.White, Color.DarkGreen) },
                { "ACTIVE", (Color.White, Color.Green) },
                { "INACTIVE", (Color.White, Color.DarkGray) },
                { "ASSIGNED", (Color.White, Color.SteelBlue) },
                { "DISPATCH", (Color.White, Color.Orange) }
            };

            // Apply predefined status colors
            dgv_Services.ApplyStatusStyle(e, "Status", serviceStatusRules);

            // Special N/A styling
            if (e.Value != null && e.Value.ToString().Trim().Equals("N/A", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.ForeColor = Color.Gray;
                e.CellStyle.Font = new Font(dgv_Services.Font, FontStyle.Italic);
            }
        }

        private async void dgv_Services_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var columnName = dgv_Services.Columns[e.ColumnIndex].Name;

            switch (columnName)
            {
                case "ColBtnReplace":
                    ReplaceDevice(e);
                    break;

                case "ColBtnDelete":
                    PullOutMerchantRecord(e);
                    break;
            }
        }

        private void dgv_Services_Paint(object sender, PaintEventArgs e)
        {/*
            if (dgv_Services.Rows.Count == 0)
            {
                string msg = isLoading ? "Fetching Merchants ..." : "No records found.";
                //LoadingGridMessage(dgv_Services, e, msg);
                //dgv_Services.Overlay(msg);
            }
            */
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
