using MIS_Admin.Modules;
using MIS_Admin.Utilities.Handler;
using MIS_Admin.Utilities.UI;
using static MIS_Admin.Controller.AuthCtrl;

namespace MIS_Admin
{
    public partial class Main : Form
    {
        public Panel BodyPanel => pn_Body;
        public int UserId { get; set; }

        public Main()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializedDisplay();
        }

        private async void SignOutAccount(FormClosingEventArgs e)
        {
            // ignore automatic shutdown (like Application.Exit)
            if (e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.TaskManagerClosing)
                return;

            // skip validation if no user logged in
            if (UserId == 0)
                return;

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to close the application?",
                "Service Management",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.No)
            {
                e.Cancel = true; // prevent closing
                return;
            }

            bool isLoggedOut = await SignOutUserAsync(UserId).ConfigureAwait(true);

            if (!isLoggedOut)
            {
                e.Cancel = true; // cancel if logout failed
            }
        }


        private IKeyHandler FindKeyHandler(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is IKeyHandler handler)
                    return handler;

                var child = FindKeyHandler(c);
                if (child != null)
                    return child;
            }
            return null;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var handler = FindKeyHandler(pn_Body);
            if (handler != null)
            {
                switch (keyData)
                {
                    case Keys.Enter:
                        handler.OnEnterPressed();
                        return true;
                    case Keys.Escape:
                        handler.OnEscapePressed();
                        return true;
                    case Keys.F1:
                        handler.OnF1Pressed();
                        return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void InitializedDisplay()
        {
            //EnableDoubleBuffering(pn_Body);
            new Login(this).ShowUserControl(pn_Body);
        }

        private async void Main_Load(object sender, EventArgs e)
        {

        }

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            SignOutAccount(e);
        }
    }
}
