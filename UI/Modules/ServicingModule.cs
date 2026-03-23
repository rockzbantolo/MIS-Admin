using MIS_Admin.Forms;
using MIS_Admin.Services;
using MIS_Admin.Utilities.Handler;
using Next.Controls.Extention;
using static MIS_Admin.Utilities.Functions.Theme;
using static Next.Controls.Extention.Gridviews;
using static Next.Controls.Extention.Labels;
using static Next.Controls.Extention.Radius;

namespace MIS_Admin.Modules
{
    public partial class ServicingModule : UserControl, IKeyHandler
    {
        private readonly JobOrderServices _joborder;
        private readonly OverviewServices _ops;

        public ServicingModule()
        {
            InitializeComponent();
            _joborder = new JobOrderServices();
            _ops = new OverviewServices();
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //ShowWindowsNotification("Servicing", "Theres a new incoming service", ToolTipIcon.Info);
            InitializeHelpers();
            await InitializedData();
        }

        public async void OnEnterPressed()
        {
            await dgv_Services.BindDataWithLoaderAsync(_joborder.GetJobOrdersAsync(txt_Search.Text), "Loading Services ...");
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
            this.BackColor = BgColor;

            new RadiusBatch()
             .Default(radius: 8, borderColor: Color.FromArgb(39, 60, 117), width: 1)
             .Add(pn_MM, pn_Prov, pn_Total)
             .Add(pn_Body,      radius: 12, borderColor: BgColor)
             .Add(pn_Nav,       radius: 12, borderColor: BgColor)
             .Add(btn_New,      radius: 12, borderColor: BgColor)
             .Add(pn_GridBody,  radius: 12, borderColor: BgColor)
             .Apply();
        }



        private async Task InitializedData()
        {
            await Task.WhenAll(
                dgv_Services.BindDataWithLoaderAsync(_joborder.GetJobOrdersAsync(), "Loading Services ...", "No Services Found."),
                AreaSummaryAsync()
             );
        }
        
        private async Task AreaSummaryAsync()
        {
            var rowMap = new Dictionary<string, List<LabelBinding>>(StringComparer.OrdinalIgnoreCase)
            {
                ["Summary"] = new List<LabelBinding>  
                {
                    new (lb_Manila,     "Manila", formatString: "N0"),
                    new (lb_Province,   "Province", formatString: "N0"),
                    new (lb_Total,      "TotalServices", formatString: "N0")
                }
            };

            await LoadLabelsAsync(
                dataTask: _ops.GetJobOrderAreaSummaryAsync(),
                keyColumn: "Description", 
                rowMap: rowMap
            );
        }



        private void dgv_Services_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is null) return;

            var value = e.Value.ToString().Trim();
            var cell = dgv_Services.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (value.Equals("N/A", StringComparison.OrdinalIgnoreCase))
            {
                cell.Style.ForeColor = TextColor.Disabled;
                cell.Style.Font = new Font(dgv_Services.Font, FontStyle.Italic);
                return;
            }

            dgv_Services.ApplyStatusStyle(
                e,
                "Priority",
                new Dictionary<string, (Color back, Color fore)>
                {
                    { "NORMAL",   (BodyColor, StatusColor.Success) },
                    { "MEDIUM",   (BodyColor, StatusColor.Warning) },
                    { "HIGH",     (BodyColor, StatusColor.HighRisk) },
                    { "CRITICAL", (BodyColor, StatusColor.Critical) }
                });
        }

        private void dgv_Services_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = dgv_Services.GetValue<int>(e.RowIndex, "ColID", 0);

            using (var frm = new JobOrderDetailsForm(id))
                frm.DimmedBackground(new Main());
        }

        private void Servicing_Load(object sender, EventArgs e)
        {

        }

        private void dgv_Services_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

        private void dgv_Services_Leave(object sender, EventArgs e)
        {
            dgv_Services.ClearSelection();
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            //new JobOrderDetailsForm().DimmedBackground(new Main());
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
