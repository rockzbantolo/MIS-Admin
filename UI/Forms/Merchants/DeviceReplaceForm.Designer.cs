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
            pn_Sim_To = new Panel();
            tx_Sim = new TextBox();
            label13 = new Label();
            lb_Sim = new Label();
            label14 = new Label();
            pn_Sim_Header = new Panel();
            label4 = new Label();
            pn_TerminalBody = new Panel();
            lb_AppCrc = new Label();
            lb_AppVersion = new Label();
            lb_Model = new Label();
            pn_Terminal_To = new Panel();
            tx_Terminal = new TextBox();
            label9 = new Label();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            lb_Terminal = new Label();
            label5 = new Label();
            pn_Terminal_Header = new Panel();
            label2 = new Label();
            btn_Save = new Button();
            panel1.SuspendLayout();
            pn_SimBody.SuspendLayout();
            pn_Sim_To.SuspendLayout();
            pn_Sim_Header.SuspendLayout();
            pn_TerminalBody.SuspendLayout();
            pn_Terminal_To.SuspendLayout();
            pn_Terminal_Header.SuspendLayout();
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
            pn_SimBody.BackColor = Color.FromArgb(30, 39, 46);
            pn_SimBody.Controls.Add(lb_Carrier);
            pn_SimBody.Controls.Add(label20);
            pn_SimBody.Controls.Add(pn_Sim_To);
            pn_SimBody.Controls.Add(lb_Sim);
            pn_SimBody.Controls.Add(label14);
            pn_SimBody.Controls.Add(pn_Sim_Header);
            pn_SimBody.Location = new Point(335, 81);
            pn_SimBody.Name = "pn_SimBody";
            pn_SimBody.Size = new Size(290, 230);
            pn_SimBody.TabIndex = 2;
            // 
            // lb_Carrier
            // 
            lb_Carrier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lb_Carrier.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lb_Carrier.ForeColor = Color.White;
            lb_Carrier.Location = new Point(20, 82);
            lb_Carrier.Name = "lb_Carrier";
            lb_Carrier.Size = new Size(252, 25);
            lb_Carrier.TabIndex = 19;
            lb_Carrier.Text = "-";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label20.ForeColor = Color.White;
            label20.Location = new Point(20, 58);
            label20.Name = "label20";
            label20.Size = new Size(54, 17);
            label20.TabIndex = 18;
            label20.Text = "Carrier:";
            // 
            // pn_Sim_To
            // 
            pn_Sim_To.BackColor = Color.FromArgb(47, 54, 64);
            pn_Sim_To.Controls.Add(tx_Sim);
            pn_Sim_To.Controls.Add(label13);
            pn_Sim_To.Location = new Point(6, 181);
            pn_Sim_To.Name = "pn_Sim_To";
            pn_Sim_To.Size = new Size(277, 40);
            pn_Sim_To.TabIndex = 17;
            // 
            // tx_Sim
            // 
            tx_Sim.BackColor = Color.FromArgb(47, 54, 64);
            tx_Sim.BorderStyle = BorderStyle.FixedSingle;
            tx_Sim.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            tx_Sim.ForeColor = Color.White;
            tx_Sim.Location = new Point(49, 7);
            tx_Sim.Name = "tx_Sim";
            tx_Sim.Size = new Size(219, 27);
            tx_Sim.TabIndex = 16;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label13.ForeColor = Color.White;
            label13.Location = new Point(16, 12);
            label13.Name = "label13";
            label13.Size = new Size(27, 17);
            label13.TabIndex = 5;
            label13.Text = "To:";
            // 
            // lb_Sim
            // 
            lb_Sim.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lb_Sim.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lb_Sim.ForeColor = Color.White;
            lb_Sim.Location = new Point(20, 139);
            lb_Sim.Name = "lb_Sim";
            lb_Sim.Size = new Size(252, 27);
            lb_Sim.TabIndex = 15;
            lb_Sim.Text = "-";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label14.ForeColor = Color.White;
            label14.Location = new Point(20, 116);
            label14.Name = "label14";
            label14.Size = new Size(46, 17);
            label14.TabIndex = 4;
            label14.Text = "Serial:";
            // 
            // pn_Sim_Header
            // 
            pn_Sim_Header.BackColor = Color.FromArgb(47, 54, 64);
            pn_Sim_Header.Controls.Add(label4);
            pn_Sim_Header.Location = new Point(6, 8);
            pn_Sim_Header.Name = "pn_Sim_Header";
            pn_Sim_Header.Size = new Size(277, 35);
            pn_Sim_Header.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(6, 7);
            label4.Name = "label4";
            label4.Size = new Size(124, 20);
            label4.TabIndex = 0;
            label4.Text = "Sim Information";
            // 
            // pn_TerminalBody
            // 
            pn_TerminalBody.BackColor = Color.FromArgb(30, 39, 46);
            pn_TerminalBody.Controls.Add(lb_AppCrc);
            pn_TerminalBody.Controls.Add(lb_AppVersion);
            pn_TerminalBody.Controls.Add(lb_Model);
            pn_TerminalBody.Controls.Add(pn_Terminal_To);
            pn_TerminalBody.Controls.Add(label19);
            pn_TerminalBody.Controls.Add(label18);
            pn_TerminalBody.Controls.Add(label17);
            pn_TerminalBody.Controls.Add(lb_Terminal);
            pn_TerminalBody.Controls.Add(label5);
            pn_TerminalBody.Controls.Add(pn_Terminal_Header);
            pn_TerminalBody.Location = new Point(21, 81);
            pn_TerminalBody.Name = "pn_TerminalBody";
            pn_TerminalBody.Size = new Size(300, 230);
            pn_TerminalBody.TabIndex = 3;
            // 
            // lb_AppCrc
            // 
            lb_AppCrc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lb_AppCrc.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lb_AppCrc.ForeColor = Color.White;
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
            lb_AppVersion.ForeColor = Color.White;
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
            lb_Model.ForeColor = Color.White;
            lb_Model.Location = new Point(82, 54);
            lb_Model.Name = "lb_Model";
            lb_Model.Size = new Size(200, 23);
            lb_Model.TabIndex = 21;
            lb_Model.Text = "-";
            // 
            // pn_Terminal_To
            // 
            pn_Terminal_To.BackColor = Color.FromArgb(47, 54, 64);
            pn_Terminal_To.Controls.Add(tx_Terminal);
            pn_Terminal_To.Controls.Add(label9);
            pn_Terminal_To.Location = new Point(7, 181);
            pn_Terminal_To.Name = "pn_Terminal_To";
            pn_Terminal_To.Size = new Size(285, 40);
            pn_Terminal_To.TabIndex = 20;
            // 
            // tx_Terminal
            // 
            tx_Terminal.BackColor = Color.FromArgb(47, 54, 64);
            tx_Terminal.BorderStyle = BorderStyle.FixedSingle;
            tx_Terminal.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            tx_Terminal.ForeColor = Color.White;
            tx_Terminal.Location = new Point(43, 7);
            tx_Terminal.Name = "tx_Terminal";
            tx_Terminal.Size = new Size(230, 27);
            tx_Terminal.TabIndex = 16;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(10, 12);
            label9.Name = "label9";
            label9.Size = new Size(27, 17);
            label9.TabIndex = 3;
            label9.Text = "To:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label19.ForeColor = Color.White;
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
            label18.ForeColor = Color.White;
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
            label17.ForeColor = Color.White;
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
            lb_Terminal.ForeColor = Color.White;
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
            label5.ForeColor = Color.White;
            label5.Location = new Point(17, 115);
            label5.Name = "label5";
            label5.Size = new Size(58, 17);
            label5.TabIndex = 2;
            label5.Text = "Version:";
            // 
            // pn_Terminal_Header
            // 
            pn_Terminal_Header.BackColor = Color.FromArgb(47, 54, 64);
            pn_Terminal_Header.Controls.Add(label2);
            pn_Terminal_Header.Location = new Point(7, 8);
            pn_Terminal_Header.Name = "pn_Terminal_Header";
            pn_Terminal_Header.Size = new Size(285, 35);
            pn_Terminal_Header.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(8, 7);
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
            // DeviceReplaceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 54, 64);
            ClientSize = new Size(643, 383);
            Controls.Add(lb_Message);
            Controls.Add(btn_Save);
            Controls.Add(pn_TerminalBody);
            Controls.Add(pn_SimBody);
            Controls.Add(panel1);
            DoubleBuffered = true;
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "DeviceReplaceForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Device Replacement";
            KeyDown += DeviceReplacementForm_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pn_SimBody.ResumeLayout(false);
            pn_SimBody.PerformLayout();
            pn_Sim_To.ResumeLayout(false);
            pn_Sim_To.PerformLayout();
            pn_Sim_Header.ResumeLayout(false);
            pn_Sim_Header.PerformLayout();
            pn_TerminalBody.ResumeLayout(false);
            pn_TerminalBody.PerformLayout();
            pn_Terminal_To.ResumeLayout(false);
            pn_Terminal_To.PerformLayout();
            pn_Terminal_Header.ResumeLayout(false);
            pn_Terminal_Header.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Label label3;
        private Panel pn_SimBody;
        private Panel pn_TerminalBody;
        private Panel pn_Sim_Header;
        private Label label4;
        private Label label5;
        private Panel pn_Terminal_Header;
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
        private Panel pn_Sim_To;
        private Panel pn_Terminal_To;
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