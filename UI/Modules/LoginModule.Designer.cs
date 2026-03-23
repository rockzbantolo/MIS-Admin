using Next.Controls;

namespace MIS_Admin.Modules
{
    partial class LoginModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginModule));
            pn_LoginBody = new Panel();
            checkBox1 = new CheckBox();
            lb_Message = new Label();
            btn_Login = new Button();
            lb_Password = new Label();
            lb_Username = new Label();
            pn_Password = new Panel();
            pictureBox2 = new PictureBox();
            tx_Pass = new TextBox();
            pn_Username = new Panel();
            pictureBox1 = new PictureBox();
            tx_Username = new TextBox();
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            pn_LoginBody.SuspendLayout();
            pn_Password.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pn_Username.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pn_LoginBody
            // 
            pn_LoginBody.Anchor = AnchorStyles.None;
            pn_LoginBody.BackColor = Color.WhiteSmoke;
            pn_LoginBody.Controls.Add(checkBox1);
            pn_LoginBody.Controls.Add(lb_Message);
            pn_LoginBody.Controls.Add(btn_Login);
            pn_LoginBody.Controls.Add(lb_Password);
            pn_LoginBody.Controls.Add(lb_Username);
            pn_LoginBody.Controls.Add(pn_Password);
            pn_LoginBody.Controls.Add(pn_Username);
            pn_LoginBody.Controls.Add(panel2);
            pn_LoginBody.Location = new Point(44, 39);
            pn_LoginBody.Name = "pn_LoginBody";
            pn_LoginBody.Size = new Size(703, 462);
            pn_LoginBody.TabIndex = 0;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox1.Location = new Point(392, 347);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(104, 19);
            checkBox1.TabIndex = 12;
            checkBox1.Text = "Remember Me";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // lb_Message
            // 
            lb_Message.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Message.ForeColor = Color.FromArgb(192, 0, 0);
            lb_Message.Location = new Point(377, 369);
            lb_Message.Name = "lb_Message";
            lb_Message.Size = new Size(300, 21);
            lb_Message.TabIndex = 11;
            lb_Message.Text = "-";
            lb_Message.TextAlign = ContentAlignment.MiddleRight;
            lb_Message.Visible = false;
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.Green;
            btn_Login.FlatAppearance.BorderColor = Color.Green;
            btn_Login.FlatAppearance.BorderSize = 0;
            btn_Login.FlatStyle = FlatStyle.Flat;
            btn_Login.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Login.ForeColor = Color.White;
            btn_Login.Location = new Point(378, 399);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(300, 46);
            btn_Login.TabIndex = 7;
            btn_Login.Text = "Sign In";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // lb_Password
            // 
            lb_Password.BackColor = Color.White;
            lb_Password.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lb_Password.Location = new Point(381, 250);
            lb_Password.Name = "lb_Password";
            lb_Password.Padding = new Padding(6, 0, 0, 0);
            lb_Password.Size = new Size(104, 26);
            lb_Password.TabIndex = 6;
            lb_Password.Text = "Password";
            lb_Password.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_Username
            // 
            lb_Username.BackColor = Color.White;
            lb_Username.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lb_Username.Location = new Point(377, 158);
            lb_Username.Name = "lb_Username";
            lb_Username.Padding = new Padding(6, 0, 0, 0);
            lb_Username.Size = new Size(108, 26);
            lb_Username.TabIndex = 5;
            lb_Username.Text = "Username";
            lb_Username.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pn_Password
            // 
            pn_Password.BackColor = Color.FromArgb(223, 228, 234);
            pn_Password.Controls.Add(pictureBox2);
            pn_Password.Controls.Add(tx_Pass);
            pn_Password.Location = new Point(377, 279);
            pn_Password.Name = "pn_Password";
            pn_Password.Size = new Size(300, 50);
            pn_Password.TabIndex = 4;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(14, 13);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(24, 24);
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // tx_Pass
            // 
            tx_Pass.BackColor = Color.FromArgb(223, 228, 234);
            tx_Pass.BorderStyle = BorderStyle.None;
            tx_Pass.CharacterCasing = CharacterCasing.Upper;
            tx_Pass.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            tx_Pass.Location = new Point(44, 15);
            tx_Pass.Name = "tx_Pass";
            tx_Pass.PlaceholderText = "Password";
            tx_Pass.Size = new Size(238, 20);
            tx_Pass.TabIndex = 1;
            tx_Pass.UseSystemPasswordChar = true;
            // 
            // pn_Username
            // 
            pn_Username.BackColor = Color.FromArgb(223, 228, 234);
            pn_Username.Controls.Add(pictureBox1);
            pn_Username.Controls.Add(tx_Username);
            pn_Username.Location = new Point(377, 187);
            pn_Username.Name = "pn_Username";
            pn_Username.Size = new Size(300, 50);
            pn_Username.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(14, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(24, 24);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // tx_Username
            // 
            tx_Username.BackColor = Color.FromArgb(223, 228, 234);
            tx_Username.BorderStyle = BorderStyle.None;
            tx_Username.CharacterCasing = CharacterCasing.Upper;
            tx_Username.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            tx_Username.Location = new Point(48, 15);
            tx_Username.Name = "tx_Username";
            tx_Username.PlaceholderText = "Username";
            tx_Username.Size = new Size(238, 20);
            tx_Username.TabIndex = 0;
            tx_Username.TextChanged += tx_Username_TextChanged;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(30, 39, 46);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(339, 462);
            panel2.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(49, 407);
            label2.Name = "label2";
            label2.Size = new Size(176, 30);
            label2.TabIndex = 1;
            label2.Text = "Develop By: Rocky John Bantolo\r\nAlrights Reserved @2025\r\n";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(49, 155);
            label1.Name = "label1";
            label1.Size = new Size(137, 50);
            label1.TabIndex = 0;
            label1.Text = "Service \r\nManagement";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 54, 64);
            Controls.Add(pn_LoginBody);
            DoubleBuffered = true;
            Name = "Login";
            Size = new Size(795, 537);
            pn_LoginBody.ResumeLayout(false);
            pn_LoginBody.PerformLayout();
            pn_Password.ResumeLayout(false);
            pn_Password.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pn_Username.ResumeLayout(false);
            pn_Username.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pn_LoginBody;
        private Label lb_Username;
        private Panel pn_Password;
        private Panel pn_Username;
        private TextBox tx_Username;
        private Panel panel2;
        private Label label2;
        private Label label1;
        private Button btn_Login;
        private Label lb_Password;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TextBox tx_Pass;
        private Label lb_Message;
        private CheckBox checkBox1;
    }
}
