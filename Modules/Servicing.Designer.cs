namespace MIS_Admin.Modules
{
    partial class Servicing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Servicing));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pn_Body = new Panel();
            pn_Prov = new Panel();
            lb_Province = new Label();
            label5 = new Label();
            pn_MM = new Panel();
            lb_Manila = new Label();
            label1 = new Label();
            label3 = new Label();
            pn_Nav = new Panel();
            btn_New = new Button();
            pb_Icon = new PictureBox();
            txt_Search = new TextBox();
            dgv_Services = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            Column11 = new DataGridViewTextBoxColumn();
            Column12 = new DataGridViewTextBoxColumn();
            Column13 = new DataGridViewTextBoxColumn();
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
            pn_Body.BackColor = Color.FromArgb(39, 60, 117);
            pn_Body.Controls.Add(pn_Prov);
            pn_Body.Controls.Add(pn_MM);
            pn_Body.Controls.Add(label3);
            pn_Body.Controls.Add(pn_Nav);
            pn_Body.Dock = DockStyle.Top;
            pn_Body.Location = new Point(10, 10);
            pn_Body.Name = "pn_Body";
            pn_Body.Padding = new Padding(20);
            pn_Body.Size = new Size(810, 225);
            pn_Body.TabIndex = 8;
            // 
            // pn_Prov
            // 
            pn_Prov.BackColor = Color.White;
            pn_Prov.Controls.Add(lb_Province);
            pn_Prov.Controls.Add(label5);
            pn_Prov.Location = new Point(217, 66);
            pn_Prov.Name = "pn_Prov";
            pn_Prov.Size = new Size(150, 60);
            pn_Prov.TabIndex = 15;
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
            pn_MM.TabIndex = 14;
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
            label3.Size = new Size(176, 21);
            label3.TabIndex = 1;
            label3.Text = "Services Informations";
            // 
            // pn_Nav
            // 
            pn_Nav.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pn_Nav.BackColor = Color.White;
            pn_Nav.Controls.Add(btn_New);
            pn_Nav.Controls.Add(pb_Icon);
            pn_Nav.Controls.Add(txt_Search);
            pn_Nav.Location = new Point(50, 144);
            pn_Nav.Name = "pn_Nav";
            pn_Nav.Size = new Size(716, 47);
            pn_Nav.TabIndex = 9;
            // 
            // btn_New
            // 
            btn_New.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_New.BackColor = Color.FromArgb(39, 60, 117);
            btn_New.FlatAppearance.BorderSize = 0;
            btn_New.FlatStyle = FlatStyle.Flat;
            btn_New.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_New.ForeColor = Color.White;
            btn_New.Location = new Point(614, 4);
            btn_New.Name = "btn_New";
            btn_New.Size = new Size(98, 40);
            btn_New.TabIndex = 11;
            btn_New.Text = "New";
            btn_New.UseVisualStyleBackColor = false;
            btn_New.Click += btn_New_Click;
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
            txt_Search.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_Search.Location = new Point(46, 13);
            txt_Search.Name = "txt_Search";
            txt_Search.Size = new Size(558, 24);
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
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgv_Services.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_Services.ColumnHeadersHeight = 45;
            dgv_Services.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_Services.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9, Column10, Column11, Column12, Column13 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Padding = new Padding(12, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv_Services.DefaultCellStyle = dataGridViewCellStyle2;
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
            dgv_Services.Size = new Size(804, 436);
            dgv_Services.TabIndex = 0;
            dgv_Services.CellDoubleClick += dgv_Services_CellDoubleClick;
            dgv_Services.CellFormatting += dgv_Services_CellFormatting;
            dgv_Services.DataBindingComplete += dgv_Services_DataBindingComplete;
            dgv_Services.Paint += dgv_Services_Paint;
            dgv_Services.Leave += dgv_Services_Leave;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column1.HeaderText = "Service ID";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 90;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column2.HeaderText = "Request No.";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 130;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column3.HeaderText = "Merchant";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 250;
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column4.HeaderText = "Service";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 110;
            // 
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column5.HeaderText = "Priority";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column6.HeaderText = "Status";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 111;
            // 
            // Column7
            // 
            Column7.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column7.HeaderText = "Result";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            // 
            // Column8
            // 
            Column8.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column8.HeaderText = "Terminal";
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            Column8.Width = 110;
            // 
            // Column9
            // 
            Column9.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column9.HeaderText = "Sim";
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            Column9.Width = 170;
            // 
            // Column10
            // 
            Column10.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column10.HeaderText = "Region";
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            // 
            // Column11
            // 
            Column11.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column11.HeaderText = "SLA";
            Column11.Name = "Column11";
            Column11.ReadOnly = true;
            Column11.Width = 60;
            // 
            // Column12
            // 
            Column12.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column12.HeaderText = "Request Date";
            Column12.Name = "Column12";
            Column12.ReadOnly = true;
            Column12.Width = 115;
            // 
            // Column13
            // 
            Column13.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column13.HeaderText = "Dispatch Date";
            Column13.Name = "Column13";
            Column13.ReadOnly = true;
            // 
            // Servicing
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(223, 228, 234);
            Controls.Add(dgv_Services);
            Controls.Add(pn_Body);
            DoubleBuffered = true;
            Name = "Servicing";
            Padding = new Padding(10);
            Size = new Size(830, 694);
            Load += Servicing_Load;
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
        private Label label3;
        private DataGridView dgv_Services;
        private Panel pn_Nav;
        private TextBox txt_Search;
        private PictureBox pb_Icon;
        private Button btn_New;
        private Panel pn_Prov;
        private Panel pn_MM;
        private Label lb_Manila;
        private Label label1;
        private Label lb_Province;
        private Label label5;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column13;
    }
}
