using MIS_Admin.Forms;
using MIS_Admin.Model;
using MIS_Admin.Utilities.Handler;
using MIS_Admin.Utilities.UI;
using System.Windows.Forms;
using static MIS_Admin.Controller.OperationsCtrl;
using static MIS_Admin.Utilities.Functions;

namespace MIS_Admin.Modules
{
    public partial class Merchants : UserControl, IKeyHandler
    {
        private bool isLoading { get; set; }

        public Merchants()
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
            //EnableDoubleBuffering(pn_Body);
            EnableDoubleBuffering(dgv_Services);
            pn_Nav.Radius(8, Color.FromArgb(232, 65, 24));
            pn_MM.Radius(8, Color.FromArgb(232, 65, 24));
            pn_Prov.Radius(8, Color.FromArgb(232, 65, 24));
            pn_Body.Radius(8, Color.White);
            dgv_Services.Radius(8, Color.FromArgb(224, 224, 224));
        }

        private async Task InitializedData()
        {
            isLoading = true;
            dgv_Services.Refresh();

            BindTableToGrid(await getAllMerchantAsync(), dgv_Services);

            isLoading = false;
            dgv_Services.Refresh();
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

        private void ReplaceDevice(DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(dgv_Services.Rows[e.RowIndex].Cells["ColID"].Value);

            using (var frm = new DeviceReplaceForm(id))
                frm.ShadowBackground(new Main());
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
                        fore = Color.Blue;
                        break;

                    case "ACTIVE":
                        fore = Color.Green;
                        break;

                    case "INACTIVE":
                        fore = Color.DarkRed;
                        break;
                }

                e.CellStyle.BackColor = back;
                e.CellStyle.ForeColor = fore;
                e.CellStyle.Font = new Font(dgv_Services.Font, FontStyle.Bold);
                e.CellStyle.SelectionBackColor = back;
                e.CellStyle.SelectionForeColor = fore;

            }
            if (e.Value != null && e.Value.ToString().Trim().Equals("N/A", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.ForeColor = Color.Gray;
                e.CellStyle.Font = new Font(dgv_Services.Font, FontStyle.Italic);
            }
        }

        private void dgv_Services_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int merchantId = Convert.ToInt32(dgv_Services.Rows[e.RowIndex].Cells[0].Value);
            var Tid = dgv_Services.CurrentRow.Cells[0].Value?.ToString();
            var Mid = dgv_Services.CurrentRow.Cells[0].Value?.ToString();
            var merchantName = dgv_Services.CurrentRow.Cells[0].Value?.ToString();


            var columnName = dgv_Services.Columns[e.ColumnIndex].Name;

            switch (columnName)
            {
                case "ColBtnReplace":
                    ReplaceDevice(e);
                    break;

                case "ColBtnDelete":
                    // handle deletion
                    break;
            }
        }

        private void dgv_Services_Paint(object sender, PaintEventArgs e)
        {
            if (dgv_Services.Rows.Count == 0)
            {
                string msg = isLoading ? "Fetching Merchants ..." : "No records found.";
                LoadingGridMessage(dgv_Services, e, msg);
            }
        }
    }
}
