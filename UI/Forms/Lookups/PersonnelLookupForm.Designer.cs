namespace MIS_Admin.UI.Forms
{
    partial class PersonnelLookupForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonnelLookupForm));
            pn_GridBody = new Panel();
            dgv_User = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Personel = new DataGridViewTextBoxColumn();
            ContactNo = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            pn_Nav = new Panel();
            pb_Icon = new PictureBox();
            txt_Search = new TextBox();
            pn_GridBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_User).BeginInit();
            pn_Nav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Icon).BeginInit();
            SuspendLayout();
            // 
            // pn_GridBody
            // 
            pn_GridBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pn_GridBody.BackColor = Color.FromArgb(30, 39, 46);
            pn_GridBody.Controls.Add(dgv_User);
            pn_GridBody.Location = new Point(22, 99);
            pn_GridBody.Name = "pn_GridBody";
            pn_GridBody.Size = new Size(736, 385);
            pn_GridBody.TabIndex = 15;
            // 
            // dgv_User
            // 
            dgv_User.AllowUserToAddRows = false;
            dgv_User.AllowUserToDeleteRows = false;
            dgv_User.AllowUserToResizeRows = false;
            dgv_User.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_User.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_User.BackgroundColor = Color.FromArgb(30, 39, 46);
            dgv_User.BorderStyle = BorderStyle.None;
            dgv_User.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(30, 39, 46);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(30, 39, 46);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgv_User.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_User.ColumnHeadersHeight = 55;
            dgv_User.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_User.Columns.AddRange(new DataGridViewColumn[] { Id, Personel, ContactNo, Email });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(30, 39, 46);
            dataGridViewCellStyle6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.Padding = new Padding(12, 0, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(47, 54, 64);
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgv_User.DefaultCellStyle = dataGridViewCellStyle6;
            dgv_User.EnableHeadersVisualStyles = false;
            dgv_User.GridColor = Color.FromArgb(30, 39, 46);
            dgv_User.Location = new Point(19, 19);
            dgv_User.Name = "dgv_User";
            dgv_User.ReadOnly = true;
            dgv_User.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_User.RowHeadersVisible = false;
            dgv_User.RowTemplate.Height = 45;
            dgv_User.RowTemplate.ReadOnly = true;
            dgv_User.RowTemplate.Resizable = DataGridViewTriState.False;
            dgv_User.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_User.Size = new Size(697, 342);
            dgv_User.TabIndex = 1;
            dgv_User.CellDoubleClick += dgv_User_CellDoubleClick;
            // 
            // Id
            // 
            Id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Padding = new Padding(10, 0, 0, 0);
            Id.DefaultCellStyle = dataGridViewCellStyle2;
            Id.HeaderText = "User ID";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 90;
            // 
            // Personel
            // 
            Personel.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Padding = new Padding(10, 0, 0, 0);
            Personel.DefaultCellStyle = dataGridViewCellStyle3;
            Personel.HeaderText = "Name";
            Personel.Name = "Personel";
            Personel.ReadOnly = true;
            Personel.Width = 200;
            // 
            // ContactNo
            // 
            ContactNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Padding = new Padding(10, 0, 0, 0);
            ContactNo.DefaultCellStyle = dataGridViewCellStyle4;
            ContactNo.HeaderText = "Contact";
            ContactNo.Name = "ContactNo";
            ContactNo.ReadOnly = true;
            ContactNo.Width = 150;
            // 
            // Email
            // 
            Email.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Padding = new Padding(10, 0, 0, 0);
            Email.DefaultCellStyle = dataGridViewCellStyle5;
            Email.HeaderText = "Email";
            Email.Name = "Email";
            Email.ReadOnly = true;
            Email.Resizable = DataGridViewTriState.False;
            // 
            // pn_Nav
            // 
            pn_Nav.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pn_Nav.BackColor = Color.FromArgb(30, 39, 46);
            pn_Nav.Controls.Add(pb_Icon);
            pn_Nav.Controls.Add(txt_Search);
            pn_Nav.Location = new Point(22, 25);
            pn_Nav.Name = "pn_Nav";
            pn_Nav.Size = new Size(736, 55);
            pn_Nav.TabIndex = 14;
            // 
            // pb_Icon
            // 
            pb_Icon.BackgroundImage = (Image)resources.GetObject("pb_Icon.BackgroundImage");
            pb_Icon.BackgroundImageLayout = ImageLayout.Center;
            pb_Icon.Cursor = Cursors.Hand;
            pb_Icon.Location = new Point(12, 14);
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
            txt_Search.Size = new Size(662, 25);
            txt_Search.TabIndex = 0;
            // 
            // PersonnelLookupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 39, 46);
            ClientSize = new Size(781, 508);
            Controls.Add(pn_GridBody);
            Controls.Add(pn_Nav);
            DoubleBuffered = true;
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PersonnelLookupForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User Information";
            KeyDown += PersonnelLookupForm_KeyDown;
            pn_GridBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_User).EndInit();
            pn_Nav.ResumeLayout(false);
            pn_Nav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Icon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pn_GridBody;
        private DataGridView dgv_User;
        private Panel pn_Nav;
        private PictureBox pb_Icon;
        private TextBox txt_Search;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Personel;
        private DataGridViewTextBoxColumn ContactNo;
        private DataGridViewTextBoxColumn Email;
    }
}