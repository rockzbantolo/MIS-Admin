namespace MIS_Admin.Modules
{
    partial class Login
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
            pn_Body = new Panel();
            btn_Login = new Button();
            label4 = new Label();
            label3 = new Label();
            panel4 = new Panel();
            checkBox1 = new CheckBox();
            panel3 = new Panel();
            textBox1 = new TextBox();
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            pn_Body.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pn_Body
            // 
            pn_Body.Anchor = AnchorStyles.None;
            pn_Body.BackColor = Color.WhiteSmoke;
            pn_Body.Controls.Add(btn_Login);
            pn_Body.Controls.Add(label4);
            pn_Body.Controls.Add(label3);
            pn_Body.Controls.Add(panel4);
            pn_Body.Controls.Add(checkBox1);
            pn_Body.Controls.Add(panel3);
            pn_Body.Controls.Add(panel2);
            pn_Body.Location = new Point(32, 30);
            pn_Body.Name = "pn_Body";
            pn_Body.Size = new Size(703, 462);
            pn_Body.TabIndex = 0;
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.Green;
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
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label4.Location = new Point(392, 287);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 6;
            label4.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label3.Location = new Point(392, 212);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 5;
            label3.Text = "Username";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(224, 224, 224);
            panel4.Location = new Point(378, 299);
            panel4.Name = "panel4";
            panel4.Size = new Size(300, 55);
            panel4.TabIndex = 4;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(378, 360);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(104, 19);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Remember Me";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(224, 224, 224);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(textBox1);
            panel3.Location = new Point(378, 224);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 55);
            panel3.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(224, 224, 224);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(48, 17);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(238, 24);
            textBox1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(30, 39, 46);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(339, 456);
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
            // pictureBox1
            // 
            pictureBox1.Location = new Point(14, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(24, 24);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pn_Body);
            Name = "Login";
            Size = new Size(771, 518);
            pn_Body.ResumeLayout(false);
            pn_Body.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pn_Body;
        private Label label3;
        private Panel panel4;
        private CheckBox checkBox1;
        private Panel panel3;
        private TextBox textBox1;
        private Panel panel2;
        private Label label2;
        private Label label1;
        private Button btn_Login;
        private Label label4;
        private PictureBox pictureBox1;
    }
}
