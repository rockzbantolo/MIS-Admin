using MIS_Admin.Models;
using MIS_Admin.Services;
using MIS_Admin.UI.Dto.Lookup;
using MIS_Admin.UI.Forms;
using Next.Controls.Extention;
using static MIS_Admin.Utilities.Functions.Theme;
using static Next.Controls.Extention.Radius;

namespace MIS_Admin.Forms
{
    public partial class JobOrderDetailsForm : Form
    {
        private readonly JobOrderServices _jobService;
        private readonly MerchantServices _merchantService;

        private JobOrderModel jobModel { get; set; }
        public DeviceLookupDto SelectedTerminal { get; private set; }
        public DeviceLookupDto SelectedSim { get; private set; }
        public PersonLookupDto SelectedFieldEngineer { get; private set; }
        public PersonLookupDto SelectedDispatcher { get; private set; }
        private int jobId { get; set; }


        public JobOrderDetailsForm(int Id)
        {
            InitializeComponent();
            jobId = Id;
            _jobService = new JobOrderServices();
            _merchantService = new MerchantServices();
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeHelpers();
            await InitializedData();
        }

        private async void InitializeHelpers()
        {
            this.BackColor = BackColor;

            // Apply Radius to Controls
            new RadiusBatch()
                .Default(radius: 8, borderColor: BodyColor, width: 1)
                //.Add(lb_RequestCount, lb_HelpdeskCount, lb_TicketCount)
                .AddToAllChildren(this, c => c is Panel, borderColor: BackColor)
                .AddToAllChildren(this, c => c is Label, radius: 6, borderColor: BackColor)
                .AddToAllChildren(this, c => c is Button, radius: 6, borderColor: BackColor)
                .Apply();
        }

        private async Task InitializedData()
        {
            //cmb_ServiceTypes.BindData(await _jobService.GetServiceTypes(), "Description", "Id");
            //cmb_ServiceResults.BindData(await _service.GetServiceResults(), "Description", "Id");
            await BindInfo(jobId);
        }

        private async Task BindInfo(int Id)
        {
            jobModel = new JobOrderModel();
            jobModel = await _jobService.GetJobOrderInfoAsync(jobId);

            if (jobModel == null) return;

            lb_ServiceType.Text     = jobModel.JobTypeDesc;
            lb_MerchantName.Text    = jobModel.MerchantName;
            lb_RequestNo.Text       = jobModel.RequestNo;
            lb_FieldEngineer.Text   = jobModel.FEName;
            lb_Dispatcher.Text      = jobModel.DispatchBy;
            lb_TerminalSerial.Text  = jobModel.TerminalSerial;
            lb_SimSerial.Text       = jobModel.SIMSerial;
            richTextBox1.Text       = jobModel.Remarks;

            await LoadJobOrderHistory(jobModel.MerchantId);

        }

        private async Task LoadJobOrderHistory(int merchantId)
        {
            await Task.WhenAll(
                dgv_ServiceHistory.BindDataWithLoaderAsync(
                    _jobService.GetJobOrderHistory(merchantId),
                    "Loading History ...",
                    "No History Found"
                ),
                dgv_MultiMerchant.BindDataWithLoaderAsync(
                    _merchantService.GetMultiMerchant(merchantId),
                    "Loading Multi Merchant ...",
                    "No Multi Merchant Found"
                )
            );
        }

        private void ServiceDetailsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            /*
            else if (e.KeyCode == Keys.Enter)
            {
                BindToComboBox(cmb_Terminals, await getAllAvailableTerminals(), "Serial", "ID");
            }
            */
        }

        private void btn_SelectTerminal_Click(object sender, EventArgs e)
        {
            using (var device = new DeviceLookupForm(1))
            {
                if (device.ShowDialog() == DialogResult.OK)
                {
                    SelectedTerminal = device.SelectedTerminal;
                    lb_TerminalSerial.Text = SelectedTerminal.Serial.ToString();
                }
            }
        }

        private void btn_SelectSim_Click(object sender, EventArgs e)
        {
            using (var device = new DeviceLookupForm(2))
            {
                if (device.ShowDialog() == DialogResult.OK)
                {
                    SelectedSim = device.SelectedSim;
                    lb_SimSerial.Text = SelectedSim.Serial.ToString();
                }
            }
        }

        private void btn_SelectFe_Click(object sender, EventArgs e)
        {
            using (var Person = new PersonnelLookupForm(1))
            {
                if (Person.ShowDialog() == DialogResult.OK)
                {
                    SelectedFieldEngineer = Person.SelectedFieldEngineer;

                    lb_FieldEngineer.Text = SelectedFieldEngineer.Personel.ToString();
                }
            }
        }

        private void btn_SelectDispatcher_Click(object sender, EventArgs e)
        {
            using (var Person = new PersonnelLookupForm(2))
            {
                if (Person.ShowDialog() == DialogResult.OK)
                {
                    SelectedDispatcher = Person.SelectedDispatcher;

                    lb_FieldEngineer.Text = SelectedDispatcher.Personel.ToString();
                }
            }
        }
    }
}
