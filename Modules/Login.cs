using MIS_Admin.Utilities.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIS_Admin.Modules
{
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeHelpers();
        }

        private void InitializeHelpers()
        {
            //EnableDoubleBuffering(pn_Body);
            this.Radius(11, Color.Black);
        }
    }
}
