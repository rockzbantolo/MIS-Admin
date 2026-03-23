using MIS_Admin.Services;
using MIS_Admin.Utilities.Handler;

namespace MIS_Admin.Modules
{
    public partial class ReportsModule : UserControl, IKeyHandler
    {

        public ReportsModule()
        {
            InitializeComponent();
            InitializeHelpers();
        }

        private void InitializeHelpers()
        {
            //EnableDoubleBuffering(pn_Body);
            //pn_Nav.Radius(8, Color.FromArgb(30, 39, 46));
            //pn_Body.Radius(8, Color.White);
            //btn_Export.Radius(6, Color.White);
            //dgv_Reports.Radius(8, Color.FromArgb(224, 224, 224));
        }

        public async void OnEnterPressed()
        {
            await LoadReportData(txt_Search.Text);
        }

        public void OnEscapePressed()
        {
            //throw new NotImplementedException();
        }

        public void OnF1Pressed()
        {
            //throw new NotImplementedException();
        }

        private async Task LoadReportData(string search = null)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                switch (cmb_Reports.SelectedIndex)
                {
                    case 0: // Terminals
                        //dgv_Reports.DataSource = await _Ops.GetListOfTerminalsAsync(search);
                        break;

                    case 1: // SIMs
                        //dgv_Reports.DataSource = _Ops.GetListOfSimCardsAsync(search);
                        break;

                    case 2: // Stores
                            // dgv_Reports.DataSource = repo.FindStores(search);
                        break;

                    default:
                        dgv_Reports.DataSource = null;
                        break;
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void cmb_Reports_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadReportData();
        }

        private void dgv_Reports_Leave(object sender, EventArgs e)
        {
            
        }

        private void dgv_Reports_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

    }
}
