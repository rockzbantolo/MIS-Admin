namespace MIS_Admin.Forms
{
    partial class MerchantDetailsForm
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
            label16 = new Label();
            label15 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label8 = new Label();
            label6 = new Label();
            label7 = new Label();
            panel1 = new Panel();
            label3 = new Label();
            button1 = new Button();
            btn_Save = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label16.Location = new Point(310, 374);
            label16.Name = "label16";
            label16.Size = new Size(32, 17);
            label16.TabIndex = 26;
            label16.Text = "City";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label15.Location = new Point(310, 316);
            label15.Name = "label15";
            label15.Size = new Size(42, 17);
            label15.TabIndex = 25;
            label15.Text = "Email";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label12.Location = new Point(48, 374);
            label12.Name = "label12";
            label12.Size = new Size(109, 17);
            label12.TabIndex = 24;
            label12.Text = "Contact Number";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label11.Location = new Point(48, 316);
            label11.Name = "label11";
            label11.Size = new Size(101, 17);
            label11.TabIndex = 23;
            label11.Text = "Contact Person";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label10.Location = new Point(310, 253);
            label10.Name = "label10";
            label10.Size = new Size(30, 17);
            label10.TabIndex = 22;
            label10.Text = "TID";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label8.Location = new Point(48, 253);
            label8.Name = "label8";
            label8.Size = new Size(34, 17);
            label8.TabIndex = 21;
            label8.Text = "MID";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label6.Location = new Point(48, 122);
            label6.Name = "label6";
            label6.Size = new Size(66, 17);
            label6.TabIndex = 19;
            label6.Text = "Merchant";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label7.Location = new Point(48, 190);
            label7.Name = "label7";
            label7.Size = new Size(57, 17);
            label7.TabIndex = 20;
            label7.Text = "Address";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(232, 65, 24);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(620, 63);
            panel1.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(21, 19);
            label3.Name = "label3";
            label3.Size = new Size(165, 20);
            label3.TabIndex = 11;
            label3.Text = "Merchant Information";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(1707, 16);
            button1.Name = "button1";
            button1.Size = new Size(35, 28);
            button1.TabIndex = 1;
            button1.Text = "x";
            button1.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            btn_Save.BackColor = Color.Green;
            btn_Save.FlatAppearance.BorderSize = 0;
            btn_Save.FlatStyle = FlatStyle.Flat;
            btn_Save.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Save.ForeColor = Color.White;
            btn_Save.Location = new Point(417, 460);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(191, 46);
            btn_Save.TabIndex = 29;
            btn_Save.Text = "Save";
            btn_Save.UseVisualStyleBackColor = false;
            // 
            // MerchantDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(223, 228, 234);
            ClientSize = new Size(620, 518);
            Controls.Add(label10);
            Controls.Add(btn_Save);
            Controls.Add(label7);
            Controls.Add(label16);
            Controls.Add(panel1);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label15);
            Controls.Add(label12);
            Controls.Add(label11);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "MerchantDetailsForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Merchant Information";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label16;
        private Label label15;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label8;
        private Label label6;
        private Label label7;
        private Panel panel1;
        private Label label3;
        private Button button1;
        private Button btn_Save;
    }
}