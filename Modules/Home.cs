using Microsoft.Toolkit.Uwp.Notifications;
using MIS_Admin.Utilities.UI;
using static MIS_Admin.Utilities.Functions;

namespace MIS_Admin.Modules
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            InitializeHelpers();
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
            btn_Reports.Radius(8, Color.FromArgb(30, 39, 46));
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
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            WaitCursor(() => new Overview().ShowUserControl(pn_Body));
        }

        private void btn_Services_Click(object sender, EventArgs e)
        {
            WaitCursor(() => new Servicing().ShowUserControl(pn_Body));
        }

        private void btn_Stores_Click(object sender, EventArgs e)
        {
            WaitCursor(() => new Stores().ShowUserControl(pn_Body));
        }

        private void btn_Reports_Click(object sender, EventArgs e)
        {
            WaitCursor(() => new Reports().ShowUserControl(pn_Body));
        }
    }
}
