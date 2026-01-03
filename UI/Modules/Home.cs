using MIS_Admin.Services;
using MIS_Admin.Utilities.UI;
using Next.Controls.Extention;
using static MIS_Admin.Models.AuthModel;

namespace MIS_Admin.Modules
{
    public partial class Home : UserControl
    {
        private readonly UserSession _session;
        private readonly Main _main;
        private readonly AuthService _user;

        public Home(UserSession session, Main main)
        {
            InitializeComponent();
            InitializeHelpers();
            _session     = session;
            _main        = main;
            _main.UserId = session.UserID;
            _user        = new AuthService();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            new Overview().Show(pn_Body);
        }

        private void InitializeHelpers()
        {
            //EnableDoubleBuffering(pn_Body);
            //RadiusControl(flp_Nav);
            //btn_Logout.Radius(8, Color.FromArgb(30, 39, 46));
        }

        private void WaitCursor(Action action)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                action();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void RadiusControl(FlowLayoutPanel panel)
        {
            /*
            panel.SuspendLayout();

            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Radius(8, Color.FromArgb(30, 39, 46));
                }
            }

            panel.ResumeLayout();
            */
        }

        private async void SignOutAccount()
        {
            if (MessageBox.Show("Are you sure to Sign out?", "Service Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool isLoggedOut = await _user.SignOutStatusAsync(_session.UserID).ConfigureAwait(true);

                if (isLoggedOut)
                {
                    _main.UserId = 0; // Reset
                    new Login(_main).ShowUserControl(_main.BodyPanel);
                }
            }
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            lb_User.Text = _session.FullName;
            lb_Role.Text = _session.Role;
            await _user.SignInStatusAsync(_session.UserID).ConfigureAwait(true);
        }


        private void btn_Home_Click(object sender, EventArgs e) => WaitCursor(() => new Overview().Show(pn_Body));

        private void btn_Services_Click(object sender, EventArgs e) => WaitCursor(() => new Servicing().Show(pn_Body));

        private void btn_Stores_Click(object sender, EventArgs e) => WaitCursor(() => new Merchants(_session).Show(pn_Body));

        private void btn_Reports_Click(object sender, EventArgs e) => WaitCursor(() => new Reports().Show(pn_Body));

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            SignOutAccount();
        }
    }
}
