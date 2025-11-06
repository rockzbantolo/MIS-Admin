namespace MIS_Admin.Modules
{
    partial class Merchants
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Merchants));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pn_Body = new Panel();
            pn_Prov = new Panel();
            lb_Province = new Label();
            label5 = new Label();
            pn_MM = new Panel();
            lb_Manila = new Label();
            label1 = new Label();
            label3 = new Label();
            pn_Nav = new Panel();
            pb_Icon = new PictureBox();
            txt_Search = new TextBox();
            dgv_Services = new DataGridView();
            ColID = new DataGridViewTextBoxColumn();
            ColMerchantID = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            ColMerchantName = new DataGridViewTextBoxColumn();
            ColTID = new DataGridViewTextBoxColumn();
            ColMID = new DataGridViewTextBoxColumn();
            ColTerminal = new DataGridViewTextBoxColumn();
            ColSim = new DataGridViewTextBoxColumn();
            ColRegion = new DataGridViewTextBoxColumn();
            ColContactPerson = new DataGridViewTextBoxColumn();
            ColContactNo = new DataGridViewTextBoxColumn();
            ColEmail = new DataGridViewTextBoxColumn();
            ColBtnUpdate = new DataGridViewImageColumn();
            ColBtnReplace = new DataGridViewImageColumn();
            ColBtnDelete = new DataGridViewImageColumn();
            pn_Body.SuspendLayout();
            pn_Prov.SuspendLayout();
            pn_MM.SuspendLayout();
            pn_Nav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Icon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Services).BeginInit();
            SuspendLayout();
            // 
            // pn_Body
            // 
            pn_Body.BackColor = Color.FromArgb(232, 65, 24);
            pn_Body.Controls.Add(pn_Prov);
            pn_Body.Controls.Add(pn_MM);
            pn_Body.Controls.Add(label3);
            pn_Body.Controls.Add(pn_Nav);
            pn_Body.Dock = DockStyle.Top;
            pn_Body.Location = new Point(10, 10);
            pn_Body.Name = "pn_Body";
            pn_Body.Padding = new Padding(20);
            pn_Body.Size = new Size(819, 225);
            pn_Body.TabIndex = 9;
            // 
            // pn_Prov
            // 
            pn_Prov.BackColor = Color.White;
            pn_Prov.Controls.Add(lb_Province);
            pn_Prov.Controls.Add(label5);
            pn_Prov.Location = new Point(217, 66);
            pn_Prov.Name = "pn_Prov";
            pn_Prov.Size = new Size(150, 60);
            pn_Prov.TabIndex = 17;
            // 
            // lb_Province
            // 
            lb_Province.AutoSize = true;
            lb_Province.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Province.ForeColor = Color.FromArgb(64, 64, 64);
            lb_Province.Location = new Point(32, 28);
            lb_Province.Name = "lb_Province";
            lb_Province.Size = new Size(19, 25);
            lb_Province.TabIndex = 3;
            lb_Province.Text = "-";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(64, 64, 64);
            label5.Location = new Point(12, 8);
            label5.Name = "label5";
            label5.Size = new Size(52, 13);
            label5.TabIndex = 2;
            label5.Text = "Province";
            // 
            // pn_MM
            // 
            pn_MM.BackColor = Color.White;
            pn_MM.Controls.Add(lb_Manila);
            pn_MM.Controls.Add(label1);
            pn_MM.Location = new Point(50, 66);
            pn_MM.Name = "pn_MM";
            pn_MM.Size = new Size(150, 60);
            pn_MM.TabIndex = 16;
            // 
            // lb_Manila
            // 
            lb_Manila.AutoSize = true;
            lb_Manila.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Manila.ForeColor = Color.FromArgb(64, 64, 64);
            lb_Manila.Location = new Point(32, 28);
            lb_Manila.Name = "lb_Manila";
            lb_Manila.Size = new Size(19, 25);
            lb_Manila.TabIndex = 1;
            lb_Manila.Text = "-";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(78, 13);
            label1.TabIndex = 0;
            label1.Text = "Metro Manila";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(23, 20);
            label3.Name = "label3";
            label3.Size = new Size(197, 21);
            label3.TabIndex = 10;
            label3.Text = "Merchant's Informations";
            // 
            // pn_Nav
            // 
            pn_Nav.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pn_Nav.BackColor = Color.White;
            pn_Nav.Controls.Add(pb_Icon);
            pn_Nav.Controls.Add(txt_Search);
            pn_Nav.Location = new Point(50, 144);
            pn_Nav.Name = "pn_Nav";
            pn_Nav.Size = new Size(725, 47);
            pn_Nav.TabIndex = 11;
            // 
            // pb_Icon
            // 
            pb_Icon.BackgroundImage = (Image)resources.GetObject("pb_Icon.BackgroundImage");
            pb_Icon.BackgroundImageLayout = ImageLayout.Center;
            pb_Icon.Location = new Point(12, 10);
            pb_Icon.Name = "pb_Icon";
            pb_Icon.Size = new Size(28, 29);
            pb_Icon.TabIndex = 10;
            pb_Icon.TabStop = false;
            // 
            // txt_Search
            // 
            txt_Search.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txt_Search.BorderStyle = BorderStyle.None;
            txt_Search.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_Search.Location = new Point(46, 14);
            txt_Search.Name = "txt_Search";
            txt_Search.Size = new Size(663, 22);
            txt_Search.TabIndex = 0;
            // 
            // dgv_Services
            // 
            dgv_Services.AllowUserToAddRows = false;
            dgv_Services.AllowUserToDeleteRows = false;
            dgv_Services.AllowUserToResizeRows = false;
            dgv_Services.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_Services.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_Services.BackgroundColor = Color.White;
            dgv_Services.BorderStyle = BorderStyle.None;
            dgv_Services.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgv_Services.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_Services.ColumnHeadersHeight = 45;
            dgv_Services.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_Services.Columns.AddRange(new DataGridViewColumn[] { ColID, ColMerchantID, Status, ColMerchantName, ColTID, ColMID, ColTerminal, ColSim, ColRegion, ColContactPerson, ColContactNo, ColEmail, ColBtnUpdate, ColBtnReplace, ColBtnDelete });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle5.Padding = new Padding(12, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgv_Services.DefaultCellStyle = dataGridViewCellStyle5;
            dgv_Services.EnableHeadersVisualStyles = false;
            dgv_Services.GridColor = Color.White;
            dgv_Services.Location = new Point(13, 245);
            dgv_Services.Name = "dgv_Services";
            dgv_Services.ReadOnly = true;
            dgv_Services.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_Services.RowHeadersVisible = false;
            dgv_Services.RowTemplate.Height = 40;
            dgv_Services.RowTemplate.ReadOnly = true;
            dgv_Services.RowTemplate.Resizable = DataGridViewTriState.False;
            dgv_Services.Size = new Size(813, 416);
            dgv_Services.TabIndex = 0;
            dgv_Services.CellContentClick += dgv_Services_CellContentClick;
            dgv_Services.CellFormatting += dgv_Services_CellFormatting;
            dgv_Services.DataBindingComplete += dgv_Services_DataBindingComplete;
            dgv_Services.Paint += dgv_Services_Paint;
            dgv_Services.Leave += dgv_Services_Leave;
            // 
            // ColID
            // 
            ColID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColID.HeaderText = "ID";
            ColID.Name = "ColID";
            ColID.ReadOnly = true;
            ColID.Width = 65;
            // 
            // ColMerchantID
            // 
            ColMerchantID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColMerchantID.HeaderText = "Code";
            ColMerchantID.Name = "ColMerchantID";
            ColMerchantID.ReadOnly = true;
            ColMerchantID.Width = 65;
            // 
            // Status
            // 
            Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Status.HeaderText = "Status";
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 80;
            // 
            // ColMerchantName
            // 
            ColMerchantName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColMerchantName.HeaderText = "Merchant";
            ColMerchantName.Name = "ColMerchantName";
            ColMerchantName.ReadOnly = true;
            ColMerchantName.Width = 220;
            // 
            // ColTID
            // 
            ColTID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColTID.HeaderText = "TID";
            ColTID.Name = "ColTID";
            ColTID.ReadOnly = true;
            ColTID.Width = 90;
            // 
            // ColMID
            // 
            ColMID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColMID.HeaderText = "MID";
            ColMID.Name = "ColMID";
            ColMID.ReadOnly = true;
            ColMID.Width = 135;
            // 
            // ColTerminal
            // 
            ColTerminal.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColTerminal.HeaderText = "Terminal";
            ColTerminal.Name = "ColTerminal";
            ColTerminal.ReadOnly = true;
            ColTerminal.Width = 105;
            // 
            // ColSim
            // 
            ColSim.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColSim.HeaderText = "Sim";
            ColSim.Name = "ColSim";
            ColSim.ReadOnly = true;
            ColSim.Width = 165;
            // 
            // ColRegion
            // 
            ColRegion.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColRegion.HeaderText = "City";
            ColRegion.Name = "ColRegion";
            ColRegion.ReadOnly = true;
            ColRegion.Width = 115;
            // 
            // ColContactPerson
            // 
            ColContactPerson.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColContactPerson.HeaderText = "Contact Person";
            ColContactPerson.Name = "ColContactPerson";
            ColContactPerson.ReadOnly = true;
            ColContactPerson.Width = 150;
            // 
            // ColContactNo
            // 
            ColContactNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColContactNo.HeaderText = "Contact No.";
            ColContactNo.Name = "ColContactNo";
            ColContactNo.ReadOnly = true;
            ColContactNo.Width = 120;
            // 
            // ColEmail
            // 
            ColEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColEmail.HeaderText = "Email";
            ColEmail.Name = "ColEmail";
            ColEmail.ReadOnly = true;
            // 
            // ColBtnUpdate
            // 
            ColBtnUpdate.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.RoyalBlue;
            dataGridViewCellStyle2.NullValue = resources.GetObject("dataGridViewCellStyle2.NullValue");
            dataGridViewCellStyle2.Padding = new Padding(1, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.RoyalBlue;
            ColBtnUpdate.DefaultCellStyle = dataGridViewCellStyle2;
            ColBtnUpdate.Description = "Update Merchant";
            ColBtnUpdate.HeaderText = "";
            ColBtnUpdate.Image = (Image)resources.GetObject("ColBtnUpdate.Image");
            ColBtnUpdate.Name = "ColBtnUpdate";
            ColBtnUpdate.ReadOnly = true;
            ColBtnUpdate.Width = 40;
            // 
            // ColBtnReplace
            // 
            ColBtnReplace.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.RoyalBlue;
            dataGridViewCellStyle3.NullValue = resources.GetObject("dataGridViewCellStyle3.NullValue");
            dataGridViewCellStyle3.Padding = new Padding(1, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = Color.RoyalBlue;
            ColBtnReplace.DefaultCellStyle = dataGridViewCellStyle3;
            ColBtnReplace.Description = "Replace Device";
            ColBtnReplace.HeaderText = "";
            ColBtnReplace.Image = (Image)resources.GetObject("ColBtnReplace.Image");
            ColBtnReplace.Name = "ColBtnReplace";
            ColBtnReplace.ReadOnly = true;
            ColBtnReplace.Resizable = DataGridViewTriState.False;
            ColBtnReplace.ToolTipText = "Replace Device";
            ColBtnReplace.Width = 40;
            // 
            // ColBtnDelete
            // 
            ColBtnDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(192, 0, 0);
            dataGridViewCellStyle4.NullValue = resources.GetObject("dataGridViewCellStyle4.NullValue");
            dataGridViewCellStyle4.Padding = new Padding(0, 0, 8, 0);
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(192, 0, 0);
            ColBtnDelete.DefaultCellStyle = dataGridViewCellStyle4;
            ColBtnDelete.HeaderText = "";
            ColBtnDelete.Image = (Image)resources.GetObject("ColBtnDelete.Image");
            ColBtnDelete.Name = "ColBtnDelete";
            ColBtnDelete.ReadOnly = true;
            ColBtnDelete.Resizable = DataGridViewTriState.False;
            ColBtnDelete.ToolTipText = "Uninstall Device";
            ColBtnDelete.Width = 40;
            // 
            // Merchants
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(223, 228, 234);
            Controls.Add(dgv_Services);
            Controls.Add(pn_Body);
            DoubleBuffered = true;
            Name = "Merchants";
            Padding = new Padding(10);
            Size = new Size(839, 674);
            pn_Body.ResumeLayout(false);
            pn_Body.PerformLayout();
            pn_Prov.ResumeLayout(false);
            pn_Prov.PerformLayout();
            pn_MM.ResumeLayout(false);
            pn_MM.PerformLayout();
            pn_Nav.ResumeLayout(false);
            pn_Nav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Icon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Services).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pn_Body;
        private DataGridView dgv_Services;
        private Label label3;
        private Panel pn_Nav;
        private PictureBox pb_Icon;
        private TextBox txt_Search;
        private Panel pn_Prov;
        private Label lb_Province;
        private Label label5;
        private Panel pn_MM;
        private Label lb_Manila;
        private Label label1;
        private DataGridViewTextBoxColumn ColID;
        private DataGridViewTextBoxColumn ColMerchantID;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn ColMerchantName;
        private DataGridViewTextBoxColumn ColTID;
        private DataGridViewTextBoxColumn ColMID;
        private DataGridViewTextBoxColumn ColTerminal;
        private DataGridViewTextBoxColumn ColSim;
        private DataGridViewTextBoxColumn ColRegion;
        private DataGridViewTextBoxColumn ColContactPerson;
        private DataGridViewTextBoxColumn ColContactNo;
        private DataGridViewTextBoxColumn ColEmail;
        private DataGridViewImageColumn ColBtnUpdate;
        private DataGridViewImageColumn ColBtnReplace;
        private DataGridViewImageColumn ColBtnDelete;
    }
}
