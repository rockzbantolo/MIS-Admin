using MIS_Admin.Services;
using MIS_Admin.Utilities.Handler;
using Next.Controls.Extention;
using static MIS_Admin.Models.AuthModel;
using static MIS_Admin.Utilities.Functions.Theme;
using static Next.Controls.Extention.Radius;

namespace MIS_Admin.Modules
{
    public partial class LoginModule : UserControl, IKeyHandler
    {
        private readonly Main _main;
        private readonly AuthServices _user;

        public LoginModule(Main main)
        {
            InitializeComponent();
            _main = main;
            _user = new AuthServices();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeHelpers();
        }

        private void InitializeHelpers()
        {
            this.BackColor = BackColor;

            tx_Pass.ShowPasswordEye();

            new RadiusBatch()
             .Default(radius: 8, borderColor: Color.WhiteSmoke, width: 1)
             .Add(pn_Username, pn_Password, btn_Login)
             .Add(pn_LoginBody, radius: 16, borderColor: BackColor)
             .Apply();
        }

        private async void SignInAccount()
        {
            btn_Login.SetLoading(true);

            if (string.IsNullOrEmpty(tx_Username.Text.Trim()) || string.IsNullOrEmpty(tx_Pass.Text.Trim()))
            {
                lb_Message.ForeColor = TextColor.Error;
                lb_Message.Text = "Please enter username and password.";
                lb_Message.Visible = true;
                btn_Login.SetLoading(false);
                return;
            }

            Session session = await _user.GetUserAccountAsync(tx_Username.Text.Trim(), tx_Pass.Text.Trim());

            if (session != null)
            {
                await Task.Delay(1000);
                new HomeModule(session, _main).Show(_main.BodyPanel);
            }
            else
            {
                lb_Message.Text = "Invalid account.";
                lb_Message.Visible = true;
                btn_Login.SetLoading(false);
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            SignInAccount();
        }

        public void OnEnterPressed()
        {
            SignInAccount();
        }

        public void OnEscapePressed()
        {
            //throw new NotImplementedException();
        }

        public void OnF1Pressed()
        {
            //throw new NotImplementedException();
        }

        private void tx_Username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
