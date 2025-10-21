using MIS_Admin.Utilities.Handler;
using MIS_Admin.Utilities.UI;
using static MIS_Admin.Controller.AuthCtrl;

namespace MIS_Admin.Modules
{
    public partial class Login : UserControl, IKeyHandler
    {
        private readonly Main _main;

        public Login(Main main)
        {
            InitializeComponent();
            _main = main;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeHelpers();
        }

        private void InitializeHelpers()
        {
            //EnableDoubleBuffering(pn_Body);
            pn_LoginBody.Radius(11, Color.FromArgb(206, 214, 224));
            pn_Username.Radius(11, Color.White);
            pn_Password.Radius(11, Color.White);
            btn_Login.Radius(11, Color.White);
            lb_Username.Radius(11, Color.WhiteSmoke);
            lb_Password.Radius(11, Color.WhiteSmoke);
        }

        private void SignIn()
        {
            string username = tx_Username.Text.Trim();
            string password = tx_Pass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lb_Message.ForeColor = Color.Red;
                lb_Message.Text = "Please enter username and password.";
                lb_Message.Visible = true;
                return;
            }

            var session = Login(username, password);

            if (session != null)
            {
                new Home(session, _main).ShowUserControl(_main.BodyPanel);
            }
            else
            {
                lb_Message.ForeColor = Color.Red;
                lb_Message.Text = "Invalid account.";
                lb_Message.Visible = true;
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            SignIn();
        }

        public void OnEnterPressed()
        {
            SignIn();
        }

        public void OnEscapePressed()
        {
            //throw new NotImplementedException();
        }

        public void OnF1Pressed()
        {
            //throw new NotImplementedException();
        }
    }
}
