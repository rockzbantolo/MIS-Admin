using MIS_Admin.Utilities.UI;
using static MIS_Admin.Utilities.Functions;
using static MIS_Admin.Controller.OperationsCtrl;
using MIS_Admin.Utilities.Handler;

namespace MIS_Admin.Modules
{
    public partial class Stores : UserControl, IKeyHandler
    {
        public Stores()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeHelpers();
            InitializedData();
        }

        private void InitializeHelpers()
        {
            //EnableDoubleBuffering(pn_Body);
            EnableDoubleBuffering(dgv_Services);
            pn_Nav.Radius(8, Color.FromArgb(232, 65, 24));
            pn_Body.Radius(8, Color.White);
            dgv_Services.Radius(8, Color.FromArgb(224, 224, 224));
        }

        private void InitializedData()
        {
            dgv_Services.DataSource = getAllStores(null);
        }

        public void OnEnterPressed()
        {
            dgv_Services.DataSource = getAllStores(txt_Search.Text);
        }

        public void OnEscapePressed()
        {
            //throw new NotImplementedException();
        }

        public void OnF1Pressed()
        {
            //throw new NotImplementedException();
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
