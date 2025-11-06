namespace MIS_Admin.Forms
{
    partial class DeviceReplaceForm
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
            panel1 = new Panel();
            label3 = new Label();
            button1 = new Button();
            lb_Message = new Label();
            pn_SimBody = new Panel();
            lb_Carrier = new Label();
            label20 = new Label();
            panel3 = new Panel();
            tx_Sim = new TextBox();
            label13 = new Label();
            lb_Sim = new Label();
            label14 = new Label();
            panel6 = new Panel();
            label4 = new Label();
            pn_TerminalBody = new Panel();
            lb_AppCrc = new Label();
            lb_AppVersion = new Label();
            lb_Model = new Label();
            panel2 = new Panel();
            tx_Terminal = new TextBox();
            label9 = new Label();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            lb_Terminal = new Label();
            label5 = new Label();
            panel4 = new Panel();
            label2 = new Label();
            btn_Save = new Button();
            panel1.SuspendLayout();
            pn_SimBody.SuspendLayout();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            pn_TerminalBody.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(232, 65, 24);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(643, 63);
            panel1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(21, 19);
            label3.Name = "label3";
            label3.Size = new Size(150, 20);
            label3.TabIndex = 11;
            label3.Text = "Device Replacement";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(1287, 16);
            button1.Name = "button1";
            button1.Size = new Size(35, 28);
            button1.TabIndex = 1;
            button1.Text = "x";
            button1.UseVisualStyleBackColor = true;
            // 
            // lb_Message
            // 
            lb_Message.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Message.ForeColor = Color.FromArgb(64, 64, 64);
            lb_Message.Location = new Point(21, 321);
            lb_Message.Name = "lb_Message";
            lb_Message.Size = new Size(367, 46);
            lb_Message.TabIndex = 12;
            lb_Message.Text = "-";
            lb_Message.TextAlign = ContentAlignment.MiddleLeft;
            lb_Message.Visible = false;
            // 
            // pn_SimBody
            // 
            pn_SimBody.BackColor = Color.White;
            pn_SimBody.Controls.Add(lb_Carrier);
            pn_SimBody.Controls.Add(label20);
            pn_SimBody.Controls.Add(panel3);
            pn_SimBody.Controls.Add(lb_Sim);
            pn_SimBody.Controls.Add(label14);
            pn_SimBody.Controls.Add(panel6);
            pn_SimBody.Location = new Point(335, 81);
            pn_SimBody.Name = "pn_SimBody";
            pn_SimBody.Size = new Size(290, 230);
            pn_SimBody.TabIndex = 2;
            // 
            // lb_Carrier
            // 
            lb_Carrier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lb_Carrier.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lb_Carrier.ForeColor = Color.FromArgb(64, 64, 64);
            lb_Carrier.Location = new Point(20, 76);
            lb_Carrier.Name = "lb_Carrier";
            lb_Carrier.Size = new Size(252, 25);
            lb_Carrier.TabIndex = 19;
            lb_Carrier.Text = "-";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label20.ForeColor = Color.FromArgb(64, 64, 64);
            label20.Location = new Point(20, 52);
            label20.Name = "label20";
            label20.Size = new Size(54, 17);
            label20.TabIndex = 18;
            label20.Text = "Carrier:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.WhiteSmoke;
            panel3.Controls.Add(tx_Sim);
            panel3.Controls.Add(label13);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 178);
            panel3.Name = "panel3";
            panel3.Size = new Size(290, 52);
            panel3.TabIndex = 17;
            // 
            // tx_Sim
            // 
            tx_Sim.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            tx_Sim.Location = new Point(53, 13);
            tx_Sim.Name = "tx_Sim";
            tx_Sim.Size = new Size(219, 27);
            tx_Sim.TabIndex = 16;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label13.ForeColor = Color.FromArgb(64, 64, 64);
            label13.Location = new Point(20, 18);
            label13.Name = "label13";
            label13.Size = new Size(27, 17);
            label13.TabIndex = 5;
            label13.Text = "To:";
            // 
            // lb_Sim
            // 
            lb_Sim.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lb_Sim.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lb_Sim.ForeColor = Color.FromArgb(64, 64, 64);
            lb_Sim.Location = new Point(20, 133);
            lb_Sim.Name = "lb_Sim";
            lb_Sim.Size = new Size(252, 27);
            lb_Sim.TabIndex = 15;
            lb_Sim.Text = "-";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label14.ForeColor = Color.FromArgb(64, 64, 64);
            label14.Location = new Point(20, 110);
            label14.Name = "label14";
            label14.Size = new Size(46, 17);
            label14.TabIndex = 4;
            label14.Text = "Serial:";
            // 
            // panel6
            // 
            panel6.BackColor = Color.WhiteSmoke;
            panel6.Controls.Add(label4);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(290, 43);
            panel6.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(13, 12);
            label4.Name = "label4";
            label4.Size = new Size(124, 20);
            label4.TabIndex = 0;
            label4.Text = "Sim Information";
            // 
            // pn_TerminalBody
            // 
            pn_TerminalBody.BackColor = Color.White;
            pn_TerminalBody.Controls.Add(lb_AppCrc);
            pn_TerminalBody.Controls.Add(lb_AppVersion);
            pn_TerminalBody.Controls.Add(lb_Model);
            pn_TerminalBody.Controls.Add(panel2);
            pn_TerminalBody.Controls.Add(label19);
            pn_TerminalBody.Controls.Add(label18);
            pn_TerminalBody.Controls.Add(label17);
            pn_TerminalBody.Controls.Add(lb_Terminal);
            pn_TerminalBody.Controls.Add(label5);
            pn_TerminalBody.Controls.Add(panel4);
            pn_TerminalBody.Location = new Point(21, 81);
            pn_TerminalBody.Name = "pn_TerminalBody";
            pn_TerminalBody.Size = new Size(300, 230);
            pn_TerminalBody.TabIndex = 3;
            // 
            // lb_AppCrc
            // 
            lb_AppCrc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lb_AppCrc.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lb_AppCrc.ForeColor = Color.FromArgb(64, 64, 64);
            lb_AppCrc.Location = new Point(82, 146);
            lb_AppCrc.Name = "lb_AppCrc";
            lb_AppCrc.Size = new Size(200, 23);
            lb_AppCrc.TabIndex = 23;
            lb_AppCrc.Text = "-";
            // 
            // lb_AppVersion
            // 
            lb_AppVersion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lb_AppVersion.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lb_AppVersion.ForeColor = Color.FromArgb(64, 64, 64);
            lb_AppVersion.Location = new Point(82, 115);
            lb_AppVersion.Name = "lb_AppVersion";
            lb_AppVersion.Size = new Size(200, 23);
            lb_AppVersion.TabIndex = 22;
            lb_AppVersion.Text = "-";
            // 
            // lb_Model
            // 
            lb_Model.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lb_Model.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lb_Model.ForeColor = Color.FromArgb(64, 64, 64);
            lb_Model.Location = new Point(82, 54);
            lb_Model.Name = "lb_Model";
            lb_Model.Size = new Size(200, 23);
            lb_Model.TabIndex = 21;
            lb_Model.Text = "-";
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(tx_Terminal);
            panel2.Controls.Add(label9);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 178);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 52);
            panel2.TabIndex = 20;
            // 
            // tx_Terminal
            // 
            tx_Terminal.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            tx_Terminal.Location = new Point(50, 13);
            tx_Terminal.Name = "tx_Terminal";
            tx_Terminal.Size = new Size(230, 27);
            tx_Terminal.TabIndex = 16;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(64, 64, 64);
            label9.Location = new Point(17, 18);
            label9.Name = "label9";
            label9.Size = new Size(27, 17);
            label9.TabIndex = 3;
            label9.Text = "To:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label19.ForeColor = Color.FromArgb(64, 64, 64);
            label19.Location = new Point(17, 146);
            label19.Name = "label19";
            label19.Size = new Size(31, 17);
            label19.TabIndex = 19;
            label19.Text = "Crc:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label18.ForeColor = Color.FromArgb(64, 64, 64);
            label18.Location = new Point(17, 85);
            label18.Name = "label18";
            label18.Size = new Size(46, 17);
            label18.TabIndex = 18;
            label18.Text = "Serial:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label17.ForeColor = Color.FromArgb(64, 64, 64);
            label17.Location = new Point(17, 54);
            label17.Name = "label17";
            label17.Size = new Size(51, 17);
            label17.TabIndex = 17;
            label17.Text = "Model:";
            // 
            // lb_Terminal
            // 
            lb_Terminal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lb_Terminal.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lb_Terminal.ForeColor = Color.FromArgb(64, 64, 64);
            lb_Terminal.Location = new Point(82, 85);
            lb_Terminal.Name = "lb_Terminal";
            lb_Terminal.Size = new Size(200, 23);
            lb_Terminal.TabIndex = 15;
            lb_Terminal.Text = "-";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(64, 64, 64);
            label5.Location = new Point(17, 115);
            label5.Name = "label5";
            label5.Size = new Size(58, 17);
            label5.TabIndex = 2;
            label5.Text = "Version:";
            // 
            // panel4
            // 
            panel4.BackColor = Color.WhiteSmoke;
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(300, 43);
            panel4.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(13, 12);
            label2.Name = "label2";
            label2.Size = new Size(153, 20);
            label2.TabIndex = 0;
            label2.Text = "Teminal Information";
            // 
            // btn_Save
            // 
            btn_Save.BackColor = Color.Green;
            btn_Save.FlatAppearance.BorderSize = 0;
            btn_Save.FlatStyle = FlatStyle.Flat;
            btn_Save.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Save.ForeColor = Color.White;
            btn_Save.Location = new Point(394, 321);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(231, 46);
            btn_Save.TabIndex = 5;
            btn_Save.Text = "Save";
            btn_Save.UseVisualStyleBackColor = false;
            btn_Save.Click += btn_Save_Click;
            // 
            // DeviceReplacementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(223, 228, 234);
            ClientSize = new Size(643, 383);
            Controls.Add(lb_Message);
            Controls.Add(btn_Save);
            Controls.Add(pn_TerminalBody);
            Controls.Add(pn_SimBody);
            Controls.Add(panel1);
            DoubleBuffered = true;
            ForeColor = Color.FromArgb(64, 64, 64);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "DeviceReplacementForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Device Replacement";
            KeyDown += DeviceReplacementForm_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pn_SimBody.ResumeLayout(false);
            pn_SimBody.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            pn_TerminalBody.ResumeLayout(false);
            pn_TerminalBody.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Label label3;
        private Panel pn_SimBody;
        private Panel pn_TerminalBody;
        private Panel panel6;
        private Label label4;
        private Label label5;
        private Panel panel4;
        private Label label2;
        private TextBox tx_Sim;
        private Label lb_Sim;
        private Label label13;
        private Label label14;
        private TextBox tx_Terminal;
        private Label lb_Terminal;
        private Label label9;
        private Button btn_Save;
        private Label lb_Message;
        private Panel panel3;
        private Panel panel2;
        private Label label19;
        private Label label18;
        private Label label17;
        private Label label20;
        private Label lb_Carrier;
        private Label lb_AppCrc;
        private Label lb_AppVersion;
        private Label lb_Model;
    }
}