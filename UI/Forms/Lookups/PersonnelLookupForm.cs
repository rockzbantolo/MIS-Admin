using MIS_Admin.Services;
using MIS_Admin.UI.Dto.Lookup;
using Next.Controls.Extention;
using static MIS_Admin.Utilities.Functions.Theme;
using static Next.Controls.Extention.Radius;

namespace MIS_Admin.UI.Forms
{
    public partial class PersonnelLookupForm : Form
    {

        public PersonLookupDto SelectedFieldEngineer { get; private set; }
        public PersonLookupDto SelectedDispatcher { get; private set; }

        private readonly UserService _service;

        private int _type { get; set; }

        public PersonnelLookupForm(int type)
        {
            InitializeComponent();
            _type = type;
            _service = new UserService();
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeHelpers();
            await InitializedData();
        }

        public void InitializeHelpers()
        {
            this.BackColor = BgColor;

            new RadiusBatch()
             .Default(radius: 8, borderColor: BgColor, width: 1)
             .Add(pn_GridBody, pn_Nav)
             .Apply();
        }

        private async Task InitializedData()
        {
            switch (_type)
            {
                case 1:

                    await dgv_User.BindDataWithLoaderAsync(
                            _service.GetSelectedFieldEngineersAsync(),
                            "Loading Terminals ...",
                            "No Field Engineer Found.");
                    break;

                case 2:
                    await dgv_User.BindDataWithLoaderAsync(
                        _service.GetSelectedDispatchersAsync(),
                        "Loading Sim cards ...",
                        "No Dispatcher Found.");
                    break;
            }
        }

        private void PersonnelLookupForm_KeyDown(object sender, KeyEventArgs e)
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

        private void dgv_User_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            switch (_type)
            {
                case 1: // Terminal
                    SelectedFieldEngineer = new PersonLookupDto();

                    SelectedFieldEngineer.Id =
                        dgv_User.GetValue<int>(e.RowIndex, "Id", 0);

                    SelectedFieldEngineer.Personel =
                        dgv_User.GetValue<string>(e.RowIndex, "Personel", string.Empty);
                    break;

                case 2: // Sim
                    SelectedDispatcher = new PersonLookupDto();

                    SelectedDispatcher.Id =
                      dgv_User.GetValue<int>(e.RowIndex, "Id", 0);

                    SelectedDispatcher.Personel =
                        dgv_User.GetValue<string>(e.RowIndex, "Personel", string.Empty);
                    break;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
