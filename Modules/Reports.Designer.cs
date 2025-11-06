namespace MIS_Admin.Modules
{
    partial class Reports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reports));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pn_Nav = new Panel();
            txt_Search = new TextBox();
            btn_Export = new Button();
            cmb_Reports = new ComboBox();
            pb_Icon = new PictureBox();
            label3 = new Label();
            pn_Body = new Panel();
            dgv_Reports = new DataGridView();
            pn_Nav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Icon).BeginInit();
            pn_Body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Reports).BeginInit();
            SuspendLayout();
            // 
            // pn_Nav
            // 
            pn_Nav.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pn_Nav.BackColor = Color.White;
            pn_Nav.Controls.Add(txt_Search);
            pn_Nav.Controls.Add(btn_Export);
            pn_Nav.Controls.Add(cmb_Reports);
            pn_Nav.Controls.Add(pb_Icon);
            pn_Nav.Location = new Point(50, 101);
            pn_Nav.Name = "pn_Nav";
            pn_Nav.Size = new Size(951, 47);
            pn_Nav.TabIndex = 14;
            // 
            // txt_Search
            // 
            txt_Search.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txt_Search.BorderStyle = BorderStyle.FixedSingle;
            txt_Search.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_Search.Location = new Point(231, 8);
            txt_Search.Name = "txt_Search";
            txt_Search.Size = new Size(604, 29);
            txt_Search.TabIndex = 12;
            // 
            // btn_Export
            // 
            btn_Export.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Export.BackColor = Color.FromArgb(53, 59, 72);
            btn_Export.FlatAppearance.BorderSize = 0;
            btn_Export.FlatStyle = FlatStyle.Flat;
            btn_Export.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Export.ForeColor = Color.White;
            btn_Export.Location = new Point(841, 8);
            btn_Export.Name = "btn_Export";
            btn_Export.Size = new Size(98, 30);
            btn_Export.TabIndex = 0;
            btn_Export.Text = "Export";
            btn_Export.UseVisualStyleBackColor = false;
            // 
            // cmb_Reports
            // 
            cmb_Reports.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Reports.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmb_Reports.FormattingEnabled = true;
            cmb_Reports.Items.AddRange(new object[] { "  Terminal", "  Sim" });
            cmb_Reports.Location = new Point(46, 8);
            cmb_Reports.Margin = new Padding(20, 10, 10, 10);
            cmb_Reports.Name = "cmb_Reports";
            cmb_Reports.Size = new Size(179, 29);
            cmb_Reports.TabIndex = 11;
            cmb_Reports.SelectedIndexChanged += cmb_Reports_SelectedIndexChanged;
            // 
            // pb_Icon
            // 
            pb_Icon.BackgroundImage = (Image)resources.GetObject("pb_Icon.BackgroundImage");
            pb_Icon.BackgroundImageLayout = ImageLayout.Center;
            pb_Icon.Location = new Point(12, 9);
            pb_Icon.Name = "pb_Icon";
            pb_Icon.Size = new Size(28, 29);
            pb_Icon.TabIndex = 10;
            pb_Icon.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(23, 20);
            label3.Name = "label3";
            label3.Size = new Size(68, 21);
            label3.TabIndex = 13;
            label3.Text = "Reports";
            // 
            // pn_Body
            // 
            pn_Body.BackColor = Color.FromArgb(53, 59, 72);
            pn_Body.Controls.Add(label3);
            pn_Body.Controls.Add(pn_Nav);
            pn_Body.Dock = DockStyle.Top;
            pn_Body.Location = new Point(10, 10);
            pn_Body.Name = "pn_Body";
            pn_Body.Padding = new Padding(20);
            pn_Body.Size = new Size(1060, 225);
            pn_Body.TabIndex = 12;
            // 
            // dgv_Reports
            // 
            dgv_Reports.AllowUserToAddRows = false;
            dgv_Reports.AllowUserToDeleteRows = false;
            dgv_Reports.AllowUserToOrderColumns = true;
            dgv_Reports.AllowUserToResizeColumns = false;
            dgv_Reports.AllowUserToResizeRows = false;
            dgv_Reports.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_Reports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_Reports.BackgroundColor = Color.White;
            dgv_Reports.BorderStyle = BorderStyle.None;
            dgv_Reports.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgv_Reports.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_Reports.ColumnHeadersHeight = 45;
            dgv_Reports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Padding = new Padding(12, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv_Reports.DefaultCellStyle = dataGridViewCellStyle2;
            dgv_Reports.EnableHeadersVisualStyles = false;
            dgv_Reports.GridColor = Color.White;
            dgv_Reports.Location = new Point(13, 245);
            dgv_Reports.Name = "dgv_Reports";
            dgv_Reports.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_Reports.RowHeadersVisible = false;
            dgv_Reports.RowTemplate.Height = 40;
            dgv_Reports.RowTemplate.ReadOnly = true;
            dgv_Reports.RowTemplate.Resizable = DataGridViewTriState.False;
            dgv_Reports.ScrollBars = ScrollBars.Vertical;
            dgv_Reports.Size = new Size(1054, 542);
            dgv_Reports.TabIndex = 0;
            dgv_Reports.DataBindingComplete += dgv_Reports_DataBindingComplete;
            dgv_Reports.Leave += dgv_Reports_Leave;
            // 
            // Reports
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(223, 228, 234);
            Controls.Add(dgv_Reports);
            Controls.Add(pn_Body);
            DoubleBuffered = true;
            Name = "Reports";
            Padding = new Padding(10);
            Size = new Size(1080, 800);
            pn_Nav.ResumeLayout(false);
            pn_Nav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Icon).EndInit();
            pn_Body.ResumeLayout(false);
            pn_Body.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Reports).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pn_Nav;
        private Label label3;
        private Panel pn_Body;
        private DataGridView dgv_Reports;
        private ComboBox cmb_Reports;
        private Button btn_Export;
        private PictureBox pb_Icon;
        private TextBox txt_Search;
    }
}
