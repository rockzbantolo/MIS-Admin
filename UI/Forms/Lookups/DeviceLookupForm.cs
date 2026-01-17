using MIS_Admin.Services;
using MIS_Admin.UI.Dto.Lookup;
using Next.Controls.Extention;
using static Next.Controls.Extention.Radius;
using static MIS_Admin.Utilities.Functions.Theme;

namespace MIS_Admin.UI.Forms
{
    public partial class DeviceLookupForm : Form
    {
        private readonly TerminalService _terminal;
        private readonly SimService _sim;

        public DeviceLookupDto SelectedTerminal { get; private set; }
        public DeviceLookupDto SelectedSim { get; private set; }

        private int _type { get; set; }


        public DeviceLookupForm(int type)
        {
            InitializeComponent();
            _type = type;
            _sim = new SimService();
            _terminal = new TerminalService();
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeHelpers();
            await InitializedData();
        }

        public void InitializeHelpers()
        {
            this.BackColor = BackColor;

            // Apply Radius to Controls
            new RadiusBatch()
                .Default(radius: 11, borderColor: BodyColor, width: 1)
                .Add(pn_GridBody, pn_Nav)
                .Apply();
        }

        private async Task InitializedData()
        {
            switch (_type)
            {
                case 1:

                    await dgv_Device.BindDataWithLoaderAsync(
                            _terminal.GetTerminalAsync(),
                            "Loading Terminals ...",
                            "No Terminal Found.");
                    break;

                case 2:
                    await dgv_Device.BindDataWithLoaderAsync(
                        _sim.GetSimCardsAsync(),
                        "Loading Sim cards ...",
                        "No Sim card Found.");
                    break;
            }
        }

        private void dgv_Device_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            switch (_type)
            {
                case 1: // Terminal
                    SelectedTerminal = new DeviceLookupDto();

                    SelectedTerminal.Id =
                        dgv_Device.GetValue<int>(e.RowIndex, "Id", 0);

                    SelectedTerminal.Serial =
                        dgv_Device.GetValue<string>(e.RowIndex, "Serial", string.Empty);
                    break;

                case 2: // Sim
                    SelectedSim = new DeviceLookupDto();

                    SelectedSim.Id =
                      dgv_Device.GetValue<int>(e.RowIndex, "Id", 0);

                    SelectedSim.Serial =
                        dgv_Device.GetValue<string>(e.RowIndex, "Serial", string.Empty);
                    break;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void DeviceForm_KeyDown(object sender, KeyEventArgs e)
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
    }
}
