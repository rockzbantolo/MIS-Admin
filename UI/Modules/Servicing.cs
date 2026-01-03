using MIS_Admin.Forms;
using MIS_Admin.Services;
using MIS_Admin.Utilities.Handler;
using Next.Controls.Extention;
using static MIS_Admin.Utilities.Functions;
using static Next.Controls.Extention.Gridviews;
using static Next.Controls.Extention.Labels;
using static Next.Controls.Extention.Radius;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace MIS_Admin.Modules
{
    public partial class Servicing : UserControl, IKeyHandler
    {
        private readonly OpsService _Ops;

        public Servicing()
        {
            InitializeComponent();
            _Ops = new OpsService();
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
            new RadiusBatch()
             .Default(radius: 8, borderColor: Color.FromArgb(39, 60, 117), width: 1)
             .Add(pn_MM, pn_Prov, pn_Total)
             .Add(pn_Body, borderColor: Color.White)
             .Add(pn_Nav, borderColor: Color.FromArgb(223, 228, 234))
             .Add(btn_New, borderColor: Color.White)
             .Add(dgv_Services, borderColor: Color.FromArgb(224, 224, 224))
             .Apply();
        }

        private async Task InitializedData()
        {
            await Task.WhenAll(
                dgv_Services.BindDataWithLoaderAsync(_Ops.GetServicesAsync(), "Loading Services ...", "No Services Found."),
                AreaSummaryAsync()
             );
        }
        
        private async Task AreaSummaryAsync()
        {
            var rowMap = new Dictionary<string, List<LabelBinding>>(StringComparer.OrdinalIgnoreCase)
            {
                ["Summary"] = new List<LabelBinding>  
                {
                    new (lb_Manila, "Manila", formatString: "N0"),
                    new (lb_Province, "Province", formatString: "N0"),
                    new (lb_Total, "TotalServices", formatString: "N0")
                }
            };

            await LoadLabelsAsync(
                dataTask: _Ops.GetServiceAreaSummaryAsync(),
                keyColumn: "Description", 
                rowMap: rowMap
            );
        }

        // Key pressed Events
        public async void OnEnterPressed()
        {
            await dgv_Services.BindDataWithLoaderAsync(_Ops.GetServicesAsync(txt_Search.Text), "Loading Services ...");
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

            // Handle N/A
            if (value.Equals("N/A", StringComparison.OrdinalIgnoreCase))
            {
                cell.Style.ForeColor = Color.Gray;
                cell.Style.Font = new Font(dgv_Services.Font, FontStyle.Italic);
                return;
            }

            var ServiceStatus = new Dictionary<string, (Color back, Color fore)>
            {
                { "NORMAL",     (Color.White, Color.Green)  },
                { "MEDIUM",     (Color.White, Color.Orange)  },
                { "HIGH",       (Color.White, Color.DarkOrange)  },
                { "CRITICAL",   (Color.White, Color.Red)  },
            };

            dgv_Services.ApplyStatusStyle(e, "Priority", ServiceStatus);
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
            
        }

        private void dgv_Services_Leave(object sender, EventArgs e)
        {
            
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            new ServiceDetailsForm().DimmedBackground(new Main());
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
