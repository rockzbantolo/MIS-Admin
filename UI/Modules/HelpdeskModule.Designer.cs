namespace MIS_Admin.UI.Modules
{
    partial class HelpdeskModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpdeskModule));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pn_Nav = new Panel();
            btn_New = new Button();
            pb_Icon = new PictureBox();
            txt_Search = new TextBox();
            pn_GridBody = new Panel();
            dgv_Services = new DataGridView();
            ColID = new DataGridViewTextBoxColumn();
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
            pn_Nav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Icon).BeginInit();
            pn_GridBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Services).BeginInit();
            SuspendLayout();
            // 
            // pn_Nav
            // 
            pn_Nav.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pn_Nav.BackColor = Color.FromArgb(30, 39, 46);
            pn_Nav.Controls.Add(btn_New);
            pn_Nav.Controls.Add(pb_Icon);
            pn_Nav.Controls.Add(txt_Search);
            pn_Nav.Location = new Point(25, 232);
            pn_Nav.Name = "pn_Nav";
            pn_Nav.Size = new Size(1029, 55);
            pn_Nav.TabIndex = 11;
            // 
            // btn_New
            // 
            btn_New.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_New.BackColor = Color.FromArgb(39, 60, 117);
            btn_New.Enabled = false;
            btn_New.FlatAppearance.BorderSize = 0;
            btn_New.FlatStyle = FlatStyle.Flat;
            btn_New.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_New.ForeColor = Color.White;
            btn_New.Location = new Point(1752, 7);
            btn_New.Name = "btn_New";
            btn_New.Size = new Size(98, 40);
            btn_New.TabIndex = 11;
            btn_New.Text = "New";
            btn_New.UseVisualStyleBackColor = false;
            // 
            // pb_Icon
            // 
            pb_Icon.BackgroundImage = (Image)resources.GetObject("pb_Icon.BackgroundImage");
            pb_Icon.BackgroundImageLayout = ImageLayout.Center;
            pb_Icon.Location = new Point(13, 14);
            pb_Icon.Name = "pb_Icon";
            pb_Icon.Size = new Size(28, 29);
            pb_Icon.TabIndex = 10;
            pb_Icon.TabStop = false;
            // 
            // txt_Search
            // 
            txt_Search.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txt_Search.BackColor = Color.FromArgb(30, 39, 46);
            txt_Search.BorderStyle = BorderStyle.None;
            txt_Search.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_Search.ForeColor = Color.White;
            txt_Search.Location = new Point(54, 14);
            txt_Search.Name = "txt_Search";
            txt_Search.PlaceholderText = "Search";
            txt_Search.Size = new Size(1683, 25);
            txt_Search.TabIndex = 0;
            // 
            // pn_GridBody
            // 
            pn_GridBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pn_GridBody.BackColor = Color.FromArgb(30, 39, 46);
            pn_GridBody.Controls.Add(dgv_Services);
            pn_GridBody.Location = new Point(25, 306);
            pn_GridBody.Name = "pn_GridBody";
            pn_GridBody.Padding = new Padding(15);
            pn_GridBody.Size = new Size(1029, 471);
            pn_GridBody.TabIndex = 12;
            // 
            // dgv_Services
            // 
            dgv_Services.AllowUserToAddRows = false;
            dgv_Services.AllowUserToDeleteRows = false;
            dgv_Services.AllowUserToResizeRows = false;
            dgv_Services.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_Services.BackgroundColor = Color.FromArgb(30, 39, 46);
            dgv_Services.BorderStyle = BorderStyle.None;
            dgv_Services.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(30, 39, 46);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(47, 54, 64);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_Services.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgv_Services.ColumnHeadersHeight = 45;
            dgv_Services.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_Services.Columns.AddRange(new DataGridViewColumn[] { ColID, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9, Column10, Column11, Column12, Column13 });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(30, 39, 46);
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.Padding = new Padding(12, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(47, 54, 64);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgv_Services.DefaultCellStyle = dataGridViewCellStyle4;
            dgv_Services.Dock = DockStyle.Fill;
            dgv_Services.EnableHeadersVisualStyles = false;
            dgv_Services.GridColor = Color.FromArgb(30, 39, 46);
            dgv_Services.Location = new Point(15, 15);
            dgv_Services.Name = "dgv_Services";
            dgv_Services.ReadOnly = true;
            dgv_Services.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_Services.RowHeadersVisible = false;
            dgv_Services.RowTemplate.Height = 40;
            dgv_Services.RowTemplate.ReadOnly = true;
            dgv_Services.RowTemplate.Resizable = DataGridViewTriState.False;
            dgv_Services.Size = new Size(999, 441);
            dgv_Services.TabIndex = 0;
            // 
            // ColID
            // 
            ColID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColID.HeaderText = "Service ID";
            ColID.Name = "ColID";
            ColID.ReadOnly = true;
            ColID.Width = 90;
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
            // Helpdesk
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 54, 64);
            Controls.Add(pn_GridBody);
            Controls.Add(pn_Nav);
            Name = "Helpdesk";
            Size = new Size(1079, 805);
            pn_Nav.ResumeLayout(false);
            pn_Nav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Icon).EndInit();
            pn_GridBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_Services).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel pn_Nav;
        private Button btn_New;
        private PictureBox pb_Icon;
        private TextBox txt_Search;
        private Panel pn_GridBody;
        private DataGridView dgv_Services;
        private DataGridViewTextBoxColumn ColID;
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
