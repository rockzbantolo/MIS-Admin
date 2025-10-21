using Microsoft.Toolkit.Uwp.Notifications;
using MIS_Admin.Model;
using MIS_Admin.Utilities.UI;

namespace MIS_Admin.Modules
{
    public partial class Home : UserControl
    {
        private readonly Authenticate.UserSession _session;
        private readonly Main _main;

        public Home(Authenticate.UserSession session, Main main)
        {
            InitializeComponent();
            InitializeHelpers();
            _session = session;
            _main = main;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            new Overview().ShowUserControl(pn_Body);
        }

        private void InitializeHelpers()
        {
            //EnableDoubleBuffering(pn_Body);
            RadiusControl(flp_Nav);
            btn_Logout.Radius(8, Color.FromArgb(30, 39, 46));
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
            panel.SuspendLayout();

            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Radius(8, Color.FromArgb(30, 39, 46));
                }
            }

            panel.ResumeLayout();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            //dgv_Servicing.DataSource = getAllServices();
            lb_User.Text = _session.FullName;
        }

        private void btn_Home_Click(object sender, EventArgs e) => WaitCursor(() => new Overview().ShowUserControl(pn_Body));

        private void btn_Services_Click(object sender, EventArgs e) => WaitCursor(() => new Servicing().ShowUserControl(pn_Body));

        private void btn_Stores_Click(object sender, EventArgs e) => WaitCursor(() => new Merchants().ShowUserControl(pn_Body));

        private void btn_Reports_Click(object sender, EventArgs e) => WaitCursor(() => new Reports().ShowUserControl(pn_Body));

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Sign out?", "Service Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new Login(_main).ShowUserControl(_main.BodyPanel);
            }
        }
    }
}
