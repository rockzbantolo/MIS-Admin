using MIS_Admin.Forms;
using MIS_Admin.Services;
using MIS_Admin.Utilities.Handler;
using Next.Controls;
using Next.Controls.Extention;
using static MIS_Admin.Models.AuthModel;
using static MIS_Admin.Utilities.Functions.Theme;
using static Next.Controls.Extention.Labels;
using static Next.Controls.Extention.Radius;


namespace MIS_Admin.Modules
{
    public partial class MerchantsModule : UserControl, IKeyHandler
    {
        private readonly Session _session;
        private readonly OverviewServices _ops;
        private readonly MerchantServices _merch;
        private string currentFilter = null;


        public MerchantsModule(Session session)
        {
            InitializeComponent();
            _ops = new OverviewServices();
            _merch = new MerchantServices();
            _session = session;

        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeHelpers();
            await InitializedData();
        }

        public async void OnEnterPressed()
        {
            await getMerchantDetails(txt_Search.Text);
        }

        public void OnEscapePressed()
        {
            //throw new NotImplementedException();
        }

        public void OnF1Pressed()
        {
            //throw new NotImplementedException();
        }

        private void InitializeHelpers()
        {
            this.BackColor = BackColor;

            dgv_Services.EnabledBuffer();

            new RadiusBatch()
            .Default(radius: 8, borderColor: Color.FromArgb(232, 65, 24), width: 1)
            .Add(pn_MM, pn_Prov, pn_Total, pn_Duplicate, pn_Total)
            .Add(pn_Body,       radius: 12, borderColor: BackColor)
            .Add(pn_Nav,        radius: 12, borderColor: BackColor)
            .Add(pn_GridBody,  radius: 12, borderColor: BackColor)
            .Apply();
        }




        private async Task InitializedData()
        {
            RoleChecked(_session);
            await DisplayData();
        }

        private void RoleChecked(Session session)
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

            var Summary = new Dictionary<string, List<LabelBinding>>(StringComparer.OrdinalIgnoreCase)
            {
                ["Summary"] = new List<LabelBinding>
                {
                    new(lb_Manila,   "Manila",     NullDisplayMode.Empty),
                    new(lb_Province, "Province",   NullDisplayMode.Empty),
                    new(lb_Duplicate,"Duplicates", NullDisplayMode.Empty),
                    new(lb_Total,    "Total",      NullDisplayMode.Empty)
                }
            };

            await LoadLabelsAsync(
                dataTask: _ops.GetInstalledTerminalCountAsync(),
                keyColumn: "Description",
                rowMap: Summary
            );
        }

        private async Task getMerchantDetails(string search = null, string filter = null)
        {
            IEnumerable<string> filters = string.IsNullOrWhiteSpace(filter)
                ? null
                : filter.Split(',').Select(f => f.Trim());

            await dgv_Services.BindDataWithLoaderAsync(
                _merch.GetMerchants(
                    search: string.IsNullOrWhiteSpace(search) ? null : search.Trim(),
                    filter: filters
                ),
                "Loading Merchants ..."
            );
        }

        private async Task DisplayData()
        {
            await Task.WhenAll(
                getMerchantDetails(currentFilter),
                InstalledTerminalCount()
            );
        }

        private void ReplaceDevice(DataGridViewCellEventArgs e)
        {
            var id = dgv_Services.GetValue<int>(e.RowIndex, "ColID", 0);

            using (var frm = new DeviceReplaceForm(id))
                frm.DimmedBackground(new Main());
            
        }

        private async void PullOutMerchantRecord(DataGridViewCellEventArgs e)
        {
            // Safely get the ID
            int id = dgv_Services.GetValue<int>(e.RowIndex, "ColID", 0);

            if (id <= 0)
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
                var result = await _merch.SetPullOutMerchantAsync(id);

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



        private void dgv_Services_Leave(object sender, EventArgs e)
        {
            dgv_Services.ClearSelection();
        }

        private void dgv_Services_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var serviceStatusRules = new Dictionary<string, (Color back, Color fore)>
            {
                { "AVAILABLE", (BodyColor, StatusColor.Success) },
                { "ACTIVE",    (BodyColor, StatusColor.Success) },
                { "INACTIVE",  (BodyColor, StatusColor.Inactive) },
                { "ASSIGNED",  (BodyColor, StatusColor.Assigned) }, 
                { "DISPATCH",  (BodyColor, StatusColor.Warning) }
            };

            // Apply predefined status colors
            dgv_Services.ApplyStatusStyle(e, "Status", serviceStatusRules);

            // Special N/A styling
            if (e.Value != null && e.Value.ToString().Trim().Equals("N/A", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.ForeColor = TextColor.Disabled;
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
            currentFilter = "MANILA";
            await getMerchantDetails(filter: currentFilter);
        }

        private async void lb_Province_Click(object sender, EventArgs e)
        {
            currentFilter = "PROVINCE";
            await getMerchantDetails(filter: currentFilter);
        }
       
        private async void lb_Duplicate_Click(object sender, EventArgs e)
        {
            currentFilter = "DUPLICATE";
            await getMerchantDetails(filter: currentFilter);
        }

        private async void pb_Icon_Click(object sender, EventArgs e)
        {
            currentFilter = null;
            await getMerchantDetails(filter: currentFilter);
        }

    }
}
