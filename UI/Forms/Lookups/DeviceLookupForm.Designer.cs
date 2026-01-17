namespace MIS_Admin.UI.Forms
{
    partial class DeviceLookupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceLookupForm));
            dgv_Device = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            Serial = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            pn_Nav = new Panel();
            pb_Icon = new PictureBox();
            txt_Search = new TextBox();
            pn_GridBody = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgv_Device).BeginInit();
            pn_Nav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Icon).BeginInit();
            pn_GridBody.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_Device
            // 
            dgv_Device.AllowUserToAddRows = false;
            dgv_Device.AllowUserToDeleteRows = false;
            dgv_Device.AllowUserToResizeRows = false;
            dgv_Device.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_Device.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_Device.BackgroundColor = Color.FromArgb(30, 39, 46);
            dgv_Device.BorderStyle = BorderStyle.None;
            dgv_Device.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(30, 39, 46);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(30, 39, 46);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgv_Device.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_Device.ColumnHeadersHeight = 55;
            dgv_Device.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_Device.Columns.AddRange(new DataGridViewColumn[] { Id, Description, Serial, Status });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(30, 39, 46);
            dataGridViewCellStyle6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.Padding = new Padding(12, 0, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(47, 54, 64);
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgv_Device.DefaultCellStyle = dataGridViewCellStyle6;
            dgv_Device.EnableHeadersVisualStyles = false;
            dgv_Device.GridColor = Color.FromArgb(30, 39, 46);
            dgv_Device.Location = new Point(19, 19);
            dgv_Device.Name = "dgv_Device";
            dgv_Device.ReadOnly = true;
            dgv_Device.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_Device.RowHeadersVisible = false;
            dgv_Device.RowTemplate.Height = 40;
            dgv_Device.RowTemplate.ReadOnly = true;
            dgv_Device.RowTemplate.Resizable = DataGridViewTriState.False;
            dgv_Device.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Device.Size = new Size(699, 347);
            dgv_Device.TabIndex = 1;
            dgv_Device.CellDoubleClick += dgv_Device_CellDoubleClick;
            // 
            // Id
            // 
            Id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Padding = new Padding(10, 0, 0, 0);
            Id.DefaultCellStyle = dataGridViewCellStyle2;
            Id.HeaderText = "ID";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 90;
            // 
            // Description
            // 
            Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Padding = new Padding(10, 0, 0, 0);
            Description.DefaultCellStyle = dataGridViewCellStyle3;
            Description.HeaderText = "Description";
            Description.Name = "Description";
            Description.ReadOnly = true;
            Description.Width = 230;
            // 
            // Serial
            // 
            Serial.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Padding = new Padding(10, 0, 0, 0);
            Serial.DefaultCellStyle = dataGridViewCellStyle4;
            Serial.HeaderText = "Serial";
            Serial.Name = "Serial";
            Serial.ReadOnly = true;
            // 
            // Status
            // 
            Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Padding = new Padding(10, 0, 0, 0);
            Status.DefaultCellStyle = dataGridViewCellStyle5;
            Status.HeaderText = "Status";
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Resizable = DataGridViewTriState.False;
            Status.Width = 120;
            // 
            // pn_Nav
            // 
            pn_Nav.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pn_Nav.BackColor = Color.FromArgb(30, 39, 46);
            pn_Nav.Controls.Add(pb_Icon);
            pn_Nav.Controls.Add(txt_Search);
            pn_Nav.Location = new Point(21, 27);
            pn_Nav.Name = "pn_Nav";
            pn_Nav.Size = new Size(736, 55);
            pn_Nav.TabIndex = 12;
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
            txt_Search.Size = new Size(668, 25);
            txt_Search.TabIndex = 0;
            // 
            // pn_GridBody
            // 
            pn_GridBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pn_GridBody.BackColor = Color.FromArgb(30, 39, 46);
            pn_GridBody.Controls.Add(dgv_Device);
            pn_GridBody.Location = new Point(21, 101);
            pn_GridBody.Name = "pn_GridBody";
            pn_GridBody.Size = new Size(736, 385);
            pn_GridBody.TabIndex = 13;
            // 
            // DeviceLookupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 54, 64);
            ClientSize = new Size(781, 508);
            Controls.Add(pn_GridBody);
            Controls.Add(pn_Nav);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DeviceLookupForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Device Information";
            KeyDown += DeviceForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgv_Device).EndInit();
            pn_Nav.ResumeLayout(false);
            pn_Nav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Icon).EndInit();
            pn_GridBody.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_Device;
        private Panel pn_Nav;
        private PictureBox pb_Icon;
        private TextBox txt_Search;
        private Panel pn_GridBody;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Serial;
        private DataGridViewTextBoxColumn Status;
    }
}