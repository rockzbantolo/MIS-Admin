using MIS_Admin.Modules;
using MIS_Admin.Utilities.UI;
using MIS_Admin.Utilities.Handler;
using static MIS_Admin.Utilities.Functions;

namespace MIS_Admin
{
    public partial class Main : Form
    {
        public Panel BodyPanel => pn_Body;

        public Main()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializedDisplay();
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

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
