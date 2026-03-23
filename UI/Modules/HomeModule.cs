using MIS_Admin.Services;
using MIS_Admin.UI.Modules;
using Next.Controls.Extention;
using static MIS_Admin.Models.AuthModel;
using static Next.Controls.Extention.Radius;

namespace MIS_Admin.Modules
{
    public partial class HomeModule : UserControl
    {
        private readonly Session _session;
        private readonly Main _main;
        private readonly AuthServices _user;

        public HomeModule(Session session, Main main)
        {
            InitializeComponent();
            InitializeHelpers();
            _session = session;
            _main = main;
            _main.UserId = session.UserID;
            _user = new AuthServices();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            new OverviewModule().Show(pn_Body);
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            lb_User.Text = _session.FullName;
            lb_Role.Text = _session.Role;
            await _user.SignInStatusAsync(_session.UserID).ConfigureAwait(true);
        }

        private void InitializeHelpers()
        {
            RadiusControl(flp_Nav);
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
            var batch = new RadiusBatch()
                .Default(radius: 8, borderColor: Color.FromArgb(30, 39, 46), width: 1);

            panel.SuspendLayout();

            foreach (Control ctrl in panel.Controls)
            {
                batch.Add(ctrl);
            }

            batch.Add(btn_Logout);
            panel.ResumeLayout();
            batch.Apply();
        }

        private async void SignOutAccount()
        {
            if (MessageBox.Show(
                    "Are you sure to Sign out?",
                    "Service Management",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (!await _user.SignOutStatusAsync(_session.UserID).ConfigureAwait(true))
                return;

            _main.UserId = 0;
            new LoginModule(_main).Show(_main.BodyPanel);
        }


        private void btn_Home_Click(object sender, EventArgs e)
        {
            Lb_Header.Text = "Dashboard";
            new OverviewModule().Show(pn_Body);
        }

        private void btn_Services_Click(object sender, EventArgs e)
        {
            Lb_Header.Text = "Services Information";
            new ServicingModule().Show(pn_Body);
        }

        private void btn_Stores_Click(object sender, EventArgs e)
        {
            Lb_Header.Text = "Merchants Information";
            new MerchantsModule(_session).Show(pn_Body);
        }

        private void btn_Reports_Click(object sender, EventArgs e)
        {
            Lb_Header.Text = "Reports";
            new ReportsModule().Show(pn_Body);
        }
        
        private void btn_Inventory_Click(object sender, EventArgs e)
        {
            Lb_Header.Text = "Inventory";
            new InventoryModule().Show(pn_Body);
        }

        private void btn_Logout_Click(object sender, EventArgs e) => SignOutAccount();


    }
}
