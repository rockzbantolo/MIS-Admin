using MIS_Admin.Utilities.Handler;

namespace MIS_Admin.Forms
{
    public partial class ServiceDetailsForm : Form, IKeyHandler
    {
        public ServiceDetailsForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeHelpers();
            //InitializedData();
        }

        private void InitializeHelpers()
        {
            //EnableDoubleBuffering(pn_Body);
            //this.Radius(11, Color.Black);
        }

        private void InitializedData()
        {
            //BindToComboBox(cmb_Terminals, getAllAvailableTerminals(), "Serial", "ID");
        }

        public async void OnEnterPressed()
        {
            
        }

        public void OnEscapePressed()
        {
            //throw new NotImplementedException();
        }

        public void OnF1Pressed()
        {
            //throw new NotImplementedException();
        }

        private void ServiceDetailsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            /*
            else if (e.KeyCode == Keys.Enter)
            {
                BindToComboBox(cmb_Terminals, await getAllAvailableTerminals(), "Serial", "ID");
            }
            */
        }

    }
}
