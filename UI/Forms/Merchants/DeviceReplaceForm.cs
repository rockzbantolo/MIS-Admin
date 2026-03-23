using MIS_Admin.Models;
using MIS_Admin.Services;
using System.Windows.Forms.Design;
using static MIS_Admin.Utilities.Functions.Theme;
using static Next.Controls.Extention.Radius;


namespace MIS_Admin.Forms
{
    public partial class DeviceReplaceForm : Form
    {
        private readonly MerchantServices _Merch;

        private readonly int _IrID;

        public DeviceReplaceForm(int IrID)
        {
            InitializeComponent();
            _IrID = IrID;
            _Merch = new MerchantServices();
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeHelpers();
            await InitializedData();
        }

        private void InitializeHelpers()
        {
            //this.Radius(8, Color.Black);
            //pn_TerminalBody.Radius(8, Color.White);
            //pn_SimBody.Radius(8, Color.White);
            //btn_Save.Radius(8, Color.White);

            this.BackColor = BgColor;

            new RadiusBatch()
             .Default(radius: 11, borderColor: BgColor, width: 1)
             .Add(this, pn_TerminalBody, pn_SimBody, btn_Save)
             .Add(pn_Sim_Header, radius: 8, borderColor: BodyColor )
             .Add(pn_Terminal_Header, radius: 8, borderColor: BodyColor)
             .Add(pn_Sim_To, radius: 8, borderColor: BodyColor)
             .Add(pn_Terminal_To, radius: 8, borderColor: BodyColor)
             .Apply();
        }

        private async Task InitializedData()
        {
            BindMerchantDataToLabel(await _Merch.GetInstallationRecordAsync(_IrID));
        }

        private void BindMerchantDataToLabel(MerchantModel details)
        {
            if (details is null) return;

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
            if (MessageBox.Show(
                    "Are you sure you want to save changes?",
                    "Confirm Save",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                var result = await _Merch.SetReplaceMerchantDeviceAsync(_IrID, tx_Terminal.Text, tx_Sim.Text);

                BindMessageToLabel(
                    string.IsNullOrWhiteSpace(result.Message)
                        ? (result.Success ? "Device replaced successfully" : "Operation failed")
                        : result.Message,
                    result.Success);

                if (!result.Success)
                    return;

                var RefreshDisplay = await _Merch.GetInstallationRecordAsync(_IrID);

                if (RefreshDisplay != null)
                    BindMerchantDataToLabel(RefreshDisplay);
            }
            catch (Exception ex)
            {
                BindMessageToLabel($"Error: {ex.Message}", false);
            }
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
