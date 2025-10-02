using MIS_Admin.Utilities.Handler;
using MIS_Admin.Utilities.UI;
using static MIS_Admin.Controller.OperationsCtrl;
using static MIS_Admin.Utilities.Functions;

namespace MIS_Admin.Modules
{
    public partial class Reports : UserControl, IKeyHandler
    {
        public Reports()
        {
            InitializeComponent();
            InitializeHelpers();
        }

        private void InitializeHelpers()
        {
            //EnableDoubleBuffering(pn_Body);
            EnableDoubleBuffering(dgv_Reports);
            pn_Nav.Radius(8, Color.FromArgb(30, 39, 46));
            pn_Body.Radius(8, Color.White);
            btn_Export.Radius(6, Color.White);
            dgv_Reports.Radius(8, Color.FromArgb(224, 224, 224));
        }

        public void OnEnterPressed()
        {
            LoadReportData(txt_Search.Text);
        }

        public void OnEscapePressed()
        {
            //throw new NotImplementedException();
        }

        public void OnF1Pressed()
        {
            //throw new NotImplementedException();
        }

        private void LoadReportData(string search = null)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                switch (cmb_Reports.SelectedIndex)
                {
                    case 0: // Terminals
                        dgv_Reports.DataSource = getAllTerminals(search);
                        break;

                    case 1: // SIMs
                        dgv_Reports.DataSource = getAllSimCards(search);
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

        private void cmb_Reports_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReportData();
        }

        private void dgv_Reports_Leave(object sender, EventArgs e)
        {
            ClearGridSelection(dgv_Reports);
        }

        private void dgv_Reports_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ClearGridSelection(dgv_Reports);
        }

    }
}
