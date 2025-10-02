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
            label3 = new Label();
            pn_Nav = new Panel();
            pb_Icon = new PictureBox();
            txt_Search = new TextBox();
            dgv_Services = new DataGridView();
            pn_Body.SuspendLayout();
            pn_Nav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Icon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Services).BeginInit();
            SuspendLayout();
            // 
            // pn_Body
            // 
            pn_Body.BackColor = Color.FromArgb(39, 60, 117);
            pn_Body.Controls.Add(label3);
            pn_Body.Controls.Add(pn_Nav);
            pn_Body.Dock = DockStyle.Top;
            pn_Body.Location = new Point(10, 10);
            pn_Body.Name = "pn_Body";
            pn_Body.Padding = new Padding(20);
            pn_Body.Size = new Size(1060, 225);
            pn_Body.TabIndex = 8;
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
            pn_Nav.Controls.Add(pb_Icon);
            pn_Nav.Controls.Add(txt_Search);
            pn_Nav.Location = new Point(50, 101);
            pn_Nav.Name = "pn_Nav";
            pn_Nav.Size = new Size(966, 47);
            pn_Nav.TabIndex = 9;
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
            txt_Search.Size = new Size(904, 24);
            txt_Search.TabIndex = 0;
            // 
            // dgv_Services
            // 
            dgv_Services.AllowUserToAddRows = false;
            dgv_Services.AllowUserToDeleteRows = false;
            dgv_Services.AllowUserToOrderColumns = true;
            dgv_Services.AllowUserToResizeRows = false;
            dgv_Services.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_Services.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_Services.BackgroundColor = Color.White;
            dgv_Services.BorderStyle = BorderStyle.None;
            dgv_Services.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgv_Services.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_Services.ColumnHeadersHeight = 45;
            dgv_Services.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
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
            dgv_Services.ScrollBars = ScrollBars.Vertical;
            dgv_Services.Size = new Size(1054, 542);
            dgv_Services.TabIndex = 0;
            dgv_Services.CellDoubleClick += dgv_Services_CellDoubleClick;
            dgv_Services.CellFormatting += dgv_Services_CellFormatting;
            dgv_Services.DataBindingComplete += dgv_Services_DataBindingComplete;
            dgv_Services.Leave += dgv_Services_Leave;
            // 
            // Servicing
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(224, 224, 224);
            Controls.Add(dgv_Services);
            Controls.Add(pn_Body);
            DoubleBuffered = true;
            Name = "Servicing";
            Padding = new Padding(10);
            Size = new Size(1080, 800);
            Load += Servicing_Load;
            pn_Body.ResumeLayout(false);
            pn_Body.PerformLayout();
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
    }
}
