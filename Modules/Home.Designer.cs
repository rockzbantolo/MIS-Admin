namespace MIS_Admin.Modules
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            flowLayoutPanel1 = new FlowLayoutPanel();
            pn_Nav = new Panel();
            btn_Logout = new Button();
            flp_Nav = new FlowLayoutPanel();
            btn_Home = new Button();
            btn_Services = new Button();
            btn_Stores = new Button();
            btn_Admin = new Button();
            button1 = new Button();
            btn_Reports = new Button();
            pictureBox1 = new PictureBox();
            pn_Header = new Panel();
            lb_Role = new Label();
            pictureBox2 = new PictureBox();
            lb_User = new Label();
            pn_Body = new Panel();
            pn_Nav.SuspendLayout();
            flp_Nav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pn_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(20, 98);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(200, 563);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // pn_Nav
            // 
            pn_Nav.BackColor = Color.FromArgb(30, 39, 46);
            pn_Nav.Controls.Add(btn_Logout);
            pn_Nav.Controls.Add(flp_Nav);
            pn_Nav.Controls.Add(pictureBox1);
            pn_Nav.Dock = DockStyle.Left;
            pn_Nav.Location = new Point(0, 0);
            pn_Nav.Name = "pn_Nav";
            pn_Nav.Size = new Size(264, 846);
            pn_Nav.TabIndex = 0;
            // 
            // btn_Logout
            // 
            btn_Logout.Anchor = AnchorStyles.Bottom;
            btn_Logout.FlatAppearance.BorderSize = 0;
            btn_Logout.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 60, 75);
            btn_Logout.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 60, 75);
            btn_Logout.FlatStyle = FlatStyle.Flat;
            btn_Logout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Logout.ForeColor = Color.White;
            btn_Logout.Image = (Image)resources.GetObject("btn_Logout.Image");
            btn_Logout.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Logout.Location = new Point(32, 766);
            btn_Logout.Margin = new Padding(5, 5, 3, 10);
            btn_Logout.Name = "btn_Logout";
            btn_Logout.Padding = new Padding(25, 0, 0, 0);
            btn_Logout.Size = new Size(191, 54);
            btn_Logout.TabIndex = 2;
            btn_Logout.Text = "     Logout";
            btn_Logout.TextAlign = ContentAlignment.MiddleLeft;
            btn_Logout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_Logout.UseVisualStyleBackColor = true;
            btn_Logout.Click += btn_Logout_Click;
            // 
            // flp_Nav
            // 
            flp_Nav.Controls.Add(btn_Home);
            flp_Nav.Controls.Add(btn_Services);
            flp_Nav.Controls.Add(btn_Stores);
            flp_Nav.Controls.Add(btn_Admin);
            flp_Nav.Controls.Add(button1);
            flp_Nav.Controls.Add(btn_Reports);
            flp_Nav.Location = new Point(27, 131);
            flp_Nav.Name = "flp_Nav";
            flp_Nav.Size = new Size(202, 582);
            flp_Nav.TabIndex = 0;
            // 
            // btn_Home
            // 
            btn_Home.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btn_Home.FlatAppearance.BorderSize = 0;
            btn_Home.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 60, 75);
            btn_Home.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 60, 75);
            btn_Home.FlatStyle = FlatStyle.Flat;
            btn_Home.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Home.ForeColor = Color.White;
            btn_Home.Image = (Image)resources.GetObject("btn_Home.Image");
            btn_Home.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Home.Location = new Point(5, 5);
            btn_Home.Margin = new Padding(5, 5, 3, 10);
            btn_Home.Name = "btn_Home";
            btn_Home.Padding = new Padding(25, 0, 0, 0);
            btn_Home.Size = new Size(191, 54);
            btn_Home.TabIndex = 0;
            btn_Home.Text = "     Home";
            btn_Home.TextAlign = ContentAlignment.MiddleLeft;
            btn_Home.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_Home.UseVisualStyleBackColor = true;
            btn_Home.Click += btn_Home_Click;
            // 
            // btn_Services
            // 
            btn_Services.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btn_Services.FlatAppearance.BorderSize = 0;
            btn_Services.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 60, 75);
            btn_Services.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 60, 75);
            btn_Services.FlatStyle = FlatStyle.Flat;
            btn_Services.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Services.ForeColor = Color.White;
            btn_Services.Image = (Image)resources.GetObject("btn_Services.Image");
            btn_Services.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Services.Location = new Point(5, 72);
            btn_Services.Margin = new Padding(5, 3, 3, 10);
            btn_Services.Name = "btn_Services";
            btn_Services.Padding = new Padding(25, 0, 0, 0);
            btn_Services.Size = new Size(191, 54);
            btn_Services.TabIndex = 1;
            btn_Services.Text = "     Services";
            btn_Services.TextAlign = ContentAlignment.MiddleLeft;
            btn_Services.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_Services.UseVisualStyleBackColor = true;
            btn_Services.Click += btn_Services_Click;
            // 
            // btn_Stores
            // 
            btn_Stores.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btn_Stores.FlatAppearance.BorderSize = 0;
            btn_Stores.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 60, 75);
            btn_Stores.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 60, 75);
            btn_Stores.FlatStyle = FlatStyle.Flat;
            btn_Stores.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Stores.ForeColor = Color.White;
            btn_Stores.Image = (Image)resources.GetObject("btn_Stores.Image");
            btn_Stores.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Stores.Location = new Point(5, 139);
            btn_Stores.Margin = new Padding(5, 3, 3, 10);
            btn_Stores.Name = "btn_Stores";
            btn_Stores.Padding = new Padding(25, 0, 0, 0);
            btn_Stores.Size = new Size(191, 54);
            btn_Stores.TabIndex = 2;
            btn_Stores.Text = "     Merchants";
            btn_Stores.TextAlign = ContentAlignment.MiddleLeft;
            btn_Stores.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_Stores.UseVisualStyleBackColor = true;
            btn_Stores.Click += btn_Stores_Click;
            // 
            // btn_Admin
            // 
            btn_Admin.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_Admin.FlatAppearance.BorderSize = 0;
            btn_Admin.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 60, 75);
            btn_Admin.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 60, 75);
            btn_Admin.FlatStyle = FlatStyle.Flat;
            btn_Admin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Admin.ForeColor = Color.White;
            btn_Admin.Image = (Image)resources.GetObject("btn_Admin.Image");
            btn_Admin.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Admin.Location = new Point(5, 208);
            btn_Admin.Margin = new Padding(5, 5, 3, 10);
            btn_Admin.Name = "btn_Admin";
            btn_Admin.Padding = new Padding(25, 0, 0, 0);
            btn_Admin.Size = new Size(191, 54);
            btn_Admin.TabIndex = 3;
            btn_Admin.Text = "     Inventory";
            btn_Admin.TextAlign = ContentAlignment.MiddleLeft;
            btn_Admin.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_Admin.UseVisualStyleBackColor = true;
            btn_Admin.Visible = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 60, 75);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 60, 75);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(5, 277);
            button1.Margin = new Padding(5, 5, 3, 10);
            button1.Name = "button1";
            button1.Padding = new Padding(25, 0, 0, 0);
            button1.Size = new Size(191, 54);
            button1.TabIndex = 4;
            button1.Text = "     Admin";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            // 
            // btn_Reports
            // 
            btn_Reports.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_Reports.FlatAppearance.BorderSize = 0;
            btn_Reports.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 60, 75);
            btn_Reports.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 60, 75);
            btn_Reports.FlatStyle = FlatStyle.Flat;
            btn_Reports.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Reports.ForeColor = Color.White;
            btn_Reports.Image = (Image)resources.GetObject("btn_Reports.Image");
            btn_Reports.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Reports.Location = new Point(5, 346);
            btn_Reports.Margin = new Padding(5, 5, 3, 10);
            btn_Reports.Name = "btn_Reports";
            btn_Reports.Padding = new Padding(25, 0, 0, 0);
            btn_Reports.Size = new Size(191, 54);
            btn_Reports.TabIndex = 1;
            btn_Reports.Text = "     Reports";
            btn_Reports.TextAlign = ContentAlignment.MiddleLeft;
            btn_Reports.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_Reports.UseVisualStyleBackColor = true;
            btn_Reports.Click += btn_Reports_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(36, -15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(184, 172);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pn_Header
            // 
            pn_Header.BackColor = Color.White;
            pn_Header.Controls.Add(lb_Role);
            pn_Header.Controls.Add(pictureBox2);
            pn_Header.Controls.Add(lb_User);
            pn_Header.Dock = DockStyle.Top;
            pn_Header.Location = new Point(264, 0);
            pn_Header.Name = "pn_Header";
            pn_Header.Size = new Size(847, 60);
            pn_Header.TabIndex = 1;
            // 
            // lb_Role
            // 
            lb_Role.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lb_Role.Font = new Font("Segoe UI", 5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Role.Location = new Point(629, 33);
            lb_Role.Name = "lb_Role";
            lb_Role.Size = new Size(170, 10);
            lb_Role.TabIndex = 10;
            lb_Role.Text = "-";
            lb_Role.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(808, 18);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(27, 27);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // lb_User
            // 
            lb_User.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lb_User.Font = new Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_User.Location = new Point(629, 19);
            lb_User.Name = "lb_User";
            lb_User.Size = new Size(170, 13);
            lb_User.TabIndex = 0;
            lb_User.Text = "-";
            lb_User.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pn_Body
            // 
            pn_Body.BackColor = Color.FromArgb(206, 214, 224);
            pn_Body.Dock = DockStyle.Fill;
            pn_Body.Location = new Point(264, 60);
            pn_Body.Name = "pn_Body";
            pn_Body.Size = new Size(847, 786);
            pn_Body.TabIndex = 2;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(220, 221, 225);
            Controls.Add(pn_Body);
            Controls.Add(pn_Header);
            Controls.Add(pn_Nav);
            DoubleBuffered = true;
            Name = "Home";
            Size = new Size(1111, 846);
            Load += Home_Load;
            pn_Nav.ResumeLayout(false);
            flp_Nav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pn_Header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel pn_Nav;
        private Panel pn_Header;
        private Panel pn_Body;
        private FlowLayoutPanel flp_Nav;
        private Button btn_Home;
        private Button btn_Services;
        private Button btn_Stores;
        private PictureBox pictureBox1;
        private Button btn_Reports;
        private Button btn_Admin;
        private Button button1;
        private Label lb_User;
        private PictureBox pictureBox2;
        private Button btn_Logout;
        private Label lb_Role;
    }
}
