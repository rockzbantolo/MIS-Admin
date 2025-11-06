using MIS_Admin.Model;
using MIS_Admin.Modules;
using MIS_Admin.Utilities.UI;
using static MIS_Admin.Controller.OperationsCtrl;
using static MIS_Admin.Utilities.Functions;

namespace MIS_Admin.Forms
{
    public partial class DeviceReplaceForm : Form
    {
        private readonly int _IrID;

        public DeviceReplaceForm(int IrID)
        {
            InitializeComponent();
            _IrID = IrID;
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeHelpers();
            await InitializedData();
        }

        private void InitializeHelpers()
        {
            EnableDoubleBuffering(this);
            this.Radius(8, Color.Black);
            pn_TerminalBody.Radius(8, Color.White);
            pn_SimBody.Radius(8, Color.White);
            btn_Save.Radius(8, Color.White);
        }

        private async Task InitializedData()
        {
            BindMerchantDataToLabel(await getInstallationDetails(_IrID));
        }

        private void BindMerchantDataToLabel(InstallationDetails details)
        {
            if (details is null) return;

            //lb_RequestNo.Text = details.RequestNo;
            //lb_MerchantName.Text = details.Merchant;
            //lb_Address.Text = details.Address;
            //lb_City.Text = details.Region;
            //lb_MID.Text = details.MID;
            //lb_TID.Text = details.TID;
            //lb_Person.Text = details.ContactPerson;
            //lb_Contact.Text = details.ContactNo;
            //lb_Email.Text = details.Email;
            lb_Terminal.Text = details.TerminalSN;
            lb_Model.Text = details.ModelName;
            lb_AppVersion.Text = details.AppVersion;
            lb_AppCrc.Text = details.AppCrc;
            lb_Carrier.Text = details.Carrier;
            lb_Sim.Text = details.SimSN;
        }

        private void BindMessageToLabel(string msg, bool isSuccess)
        {
            tx_Terminal.Clear();
            tx_Sim.Clear();
            lb_Message.ForeColor = isSuccess ? Color.Green : Color.Red;
            lb_Message.Text = msg;
            lb_Message.Visible = true;
        }

        private async Task SaveChanges()
        {
            var resp = MessageBox.Show("Are you sure you want to save changes?",
                   "Confirm Save",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);

            if (resp != DialogResult.Yes)
                return;

            var result = ReplaceDevice(_IrID, tx_Terminal.Text, tx_Sim.Text);

            bool success = result.Result == 1;

            BindMessageToLabel(result.Message, success);

            if (success)
                BindMerchantDataToLabel(await getInstallationDetails(_IrID));
        }

        private void DeviceReplacementForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private async void btn_Save_Click(object sender, EventArgs e)
        {
           await SaveChanges();
        }
    }
}
