namespace MIS_Admin.Forms
{
    partial class JobOrderDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobOrderDetailsForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            btn_SelectTerminal = new Button();
            btn_SelectSim = new Button();
            panel2 = new Panel();
            richTextBox1 = new RichTextBox();
            panel1 = new Panel();
            label10 = new Label();
            lb_MerchantName = new Label();
            pn_CurrentDevice = new Panel();
            label4 = new Label();
            label2 = new Label();
            lb_SimSerial = new Label();
            lb_TerminalSerial = new Label();
            panel6 = new Panel();
            label1 = new Label();
            pn_Header = new Panel();
            lb_ServiceType = new Label();
            lb_RequestNo = new Label();
            label11 = new Label();
            pn_GeneralInfo = new Panel();
            label3 = new Label();
            label6 = new Label();
            lb_Dispatcher = new Label();
            lb_FieldEngineer = new Label();
            panel11 = new Panel();
            dateTimePicker2 = new DateTimePicker();
            label8 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label7 = new Label();
            btn_SelectDispatcher = new Button();
            btn_SelectFe = new Button();
            panel9 = new Panel();
            pn_ReplaceDevice = new Panel();
            label5 = new Label();
            label9 = new Label();
            lb_ReplaceSim = new Label();
            lb_ReplaceTerminal = new Label();
            panel8 = new Panel();
            label14 = new Label();
            button1 = new Button();
            button2 = new Button();
            panel12 = new Panel();
            pn_GridBody = new Panel();
            dgv_ServiceHistory = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            JobType = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            panel14 = new Panel();
            label12 = new Label();
            panel13 = new Panel();
            panel16 = new Panel();
            dgv_MultiMerchant = new DataGridView();
            TID = new DataGridViewTextBoxColumn();
            Terminal = new DataGridViewTextBoxColumn();
            Sim = new DataGridViewTextBoxColumn();
            panel15 = new Panel();
            label13 = new Label();
            richTextBox2 = new RichTextBox();
            label15 = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            pn_CurrentDevice.SuspendLayout();
            panel6.SuspendLayout();
            pn_Header.SuspendLayout();
            pn_GeneralInfo.SuspendLayout();
            panel11.SuspendLayout();
            panel9.SuspendLayout();
            pn_ReplaceDevice.SuspendLayout();
            panel8.SuspendLayout();
            panel12.SuspendLayout();
            pn_GridBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ServiceHistory).BeginInit();
            panel14.SuspendLayout();
            panel13.SuspendLayout();
            panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_MultiMerchant).BeginInit();
            panel15.SuspendLayout();
            SuspendLayout();
            // 
            // btn_SelectTerminal
            // 
            btn_SelectTerminal.BackgroundImage = (Image)resources.GetObject("btn_SelectTerminal.BackgroundImage");
            btn_SelectTerminal.BackgroundImageLayout = ImageLayout.Center;
            btn_SelectTerminal.FlatAppearance.BorderColor = Color.FromArgb(47, 54, 64);
            btn_SelectTerminal.FlatAppearance.BorderSize = 0;
            btn_SelectTerminal.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 60, 75);
            btn_SelectTerminal.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 60, 75);
            btn_SelectTerminal.FlatStyle = FlatStyle.Flat;
            btn_SelectTerminal.ForeColor = Color.White;
            btn_SelectTerminal.Location = new Point(259, 74);
            btn_SelectTerminal.Name = "btn_SelectTerminal";
            btn_SelectTerminal.Size = new Size(36, 30);
            btn_SelectTerminal.TabIndex = 7;
            btn_SelectTerminal.UseVisualStyleBackColor = false;
            btn_SelectTerminal.Click += btn_SelectTerminal_Click;
            // 
            // btn_SelectSim
            // 
            btn_SelectSim.BackgroundImage = (Image)resources.GetObject("btn_SelectSim.BackgroundImage");
            btn_SelectSim.BackgroundImageLayout = ImageLayout.Center;
            btn_SelectSim.FlatAppearance.BorderColor = Color.FromArgb(47, 54, 64);
            btn_SelectSim.FlatAppearance.BorderSize = 0;
            btn_SelectSim.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 60, 75);
            btn_SelectSim.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 60, 75);
            btn_SelectSim.FlatStyle = FlatStyle.Flat;
            btn_SelectSim.ForeColor = Color.White;
            btn_SelectSim.Location = new Point(259, 132);
            btn_SelectSim.Name = "btn_SelectSim";
            btn_SelectSim.Size = new Size(36, 30);
            btn_SelectSim.TabIndex = 8;
            btn_SelectSim.UseVisualStyleBackColor = false;
            btn_SelectSim.Click += btn_SelectSim_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(30, 39, 46);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(richTextBox2);
            panel2.Controls.Add(richTextBox1);
            panel2.Controls.Add(panel1);
            panel2.Location = new Point(15, 477);
            panel2.Name = "panel2";
            panel2.Size = new Size(764, 232);
            panel2.TabIndex = 10;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(47, 54, 64);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.ForeColor = Color.White;
            richTextBox1.Location = new Point(21, 84);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(283, 131);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(47, 54, 64);
            panel1.Controls.Add(label10);
            panel1.Location = new Point(12, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(741, 33);
            panel1.TabIndex = 8;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(9, 8);
            label10.Name = "label10";
            label10.Size = new Size(76, 19);
            label10.TabIndex = 1;
            label10.Text = "Comments";
            // 
            // lb_MerchantName
            // 
            lb_MerchantName.AutoSize = true;
            lb_MerchantName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lb_MerchantName.Location = new Point(13, 9);
            lb_MerchantName.Name = "lb_MerchantName";
            lb_MerchantName.Size = new Size(19, 25);
            lb_MerchantName.TabIndex = 4;
            lb_MerchantName.Text = "-";
            lb_MerchantName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pn_CurrentDevice
            // 
            pn_CurrentDevice.BackColor = Color.FromArgb(30, 39, 46);
            pn_CurrentDevice.Controls.Add(label4);
            pn_CurrentDevice.Controls.Add(label2);
            pn_CurrentDevice.Controls.Add(lb_SimSerial);
            pn_CurrentDevice.Controls.Add(lb_TerminalSerial);
            pn_CurrentDevice.Controls.Add(panel6);
            pn_CurrentDevice.Controls.Add(btn_SelectTerminal);
            pn_CurrentDevice.Controls.Add(btn_SelectSim);
            pn_CurrentDevice.Location = new Point(15, 109);
            pn_CurrentDevice.Name = "pn_CurrentDevice";
            pn_CurrentDevice.Size = new Size(313, 174);
            pn_CurrentDevice.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.Location = new Point(15, 113);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 13;
            label4.Text = "Sim Card";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.Location = new Point(17, 55);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 12;
            label2.Text = "Terminal";
            // 
            // lb_SimSerial
            // 
            lb_SimSerial.BackColor = Color.FromArgb(47, 54, 64);
            lb_SimSerial.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lb_SimSerial.Location = new Point(19, 132);
            lb_SimSerial.Name = "lb_SimSerial";
            lb_SimSerial.Padding = new Padding(9, 0, 0, 0);
            lb_SimSerial.Size = new Size(234, 30);
            lb_SimSerial.TabIndex = 11;
            lb_SimSerial.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_TerminalSerial
            // 
            lb_TerminalSerial.BackColor = Color.FromArgb(47, 54, 64);
            lb_TerminalSerial.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lb_TerminalSerial.Location = new Point(19, 74);
            lb_TerminalSerial.Name = "lb_TerminalSerial";
            lb_TerminalSerial.Padding = new Padding(9, 0, 0, 0);
            lb_TerminalSerial.Size = new Size(234, 30);
            lb_TerminalSerial.TabIndex = 10;
            lb_TerminalSerial.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(47, 54, 64);
            panel6.Controls.Add(label1);
            panel6.Location = new Point(11, 11);
            panel6.Name = "panel6";
            panel6.Size = new Size(292, 33);
            panel6.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 7);
            label1.Name = "label1";
            label1.Size = new Size(102, 19);
            label1.TabIndex = 1;
            label1.Text = "Current Device";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pn_Header
            // 
            pn_Header.BackColor = Color.FromArgb(30, 39, 46);
            pn_Header.Controls.Add(lb_ServiceType);
            pn_Header.Controls.Add(lb_MerchantName);
            pn_Header.Controls.Add(lb_RequestNo);
            pn_Header.Location = new Point(15, 14);
            pn_Header.Name = "pn_Header";
            pn_Header.Size = new Size(764, 85);
            pn_Header.TabIndex = 12;
            // 
            // lb_ServiceType
            // 
            lb_ServiceType.AutoSize = true;
            lb_ServiceType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lb_ServiceType.Location = new Point(19, 60);
            lb_ServiceType.Name = "lb_ServiceType";
            lb_ServiceType.Size = new Size(12, 15);
            lb_ServiceType.TabIndex = 19;
            lb_ServiceType.Text = "-";
            lb_ServiceType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_RequestNo
            // 
            lb_RequestNo.AutoSize = true;
            lb_RequestNo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lb_RequestNo.Location = new Point(19, 40);
            lb_RequestNo.Name = "lb_RequestNo";
            lb_RequestNo.Size = new Size(12, 15);
            lb_RequestNo.TabIndex = 1;
            lb_RequestNo.Text = "-";
            lb_RequestNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(7, 7);
            label11.Name = "label11";
            label11.Size = new Size(135, 19);
            label11.TabIndex = 5;
            label11.Text = "General Information";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pn_GeneralInfo
            // 
            pn_GeneralInfo.BackColor = Color.FromArgb(30, 39, 46);
            pn_GeneralInfo.Controls.Add(label3);
            pn_GeneralInfo.Controls.Add(label6);
            pn_GeneralInfo.Controls.Add(lb_Dispatcher);
            pn_GeneralInfo.Controls.Add(lb_FieldEngineer);
            pn_GeneralInfo.Controls.Add(panel11);
            pn_GeneralInfo.Controls.Add(btn_SelectDispatcher);
            pn_GeneralInfo.Controls.Add(btn_SelectFe);
            pn_GeneralInfo.Controls.Add(panel9);
            pn_GeneralInfo.Location = new Point(337, 109);
            pn_GeneralInfo.Name = "pn_GeneralInfo";
            pn_GeneralInfo.Size = new Size(443, 358);
            pn_GeneralInfo.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 126);
            label3.Name = "label3";
            label3.Size = new Size(76, 19);
            label3.TabIndex = 1;
            label3.Text = "Dispatcher";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 57);
            label6.Name = "label6";
            label6.Size = new Size(97, 19);
            label6.TabIndex = 1;
            label6.Text = "Field Engineer";
            // 
            // lb_Dispatcher
            // 
            lb_Dispatcher.BackColor = Color.FromArgb(47, 54, 64);
            lb_Dispatcher.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lb_Dispatcher.Location = new Point(19, 153);
            lb_Dispatcher.Name = "lb_Dispatcher";
            lb_Dispatcher.Padding = new Padding(9, 0, 0, 0);
            lb_Dispatcher.Size = new Size(361, 30);
            lb_Dispatcher.TabIndex = 18;
            lb_Dispatcher.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_FieldEngineer
            // 
            lb_FieldEngineer.BackColor = Color.FromArgb(47, 54, 64);
            lb_FieldEngineer.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lb_FieldEngineer.Location = new Point(20, 83);
            lb_FieldEngineer.Name = "lb_FieldEngineer";
            lb_FieldEngineer.Padding = new Padding(9, 0, 0, 0);
            lb_FieldEngineer.Size = new Size(361, 30);
            lb_FieldEngineer.TabIndex = 17;
            lb_FieldEngineer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel11
            // 
            panel11.BackColor = Color.FromArgb(47, 54, 64);
            panel11.Controls.Add(dateTimePicker2);
            panel11.Controls.Add(label8);
            panel11.Controls.Add(dateTimePicker1);
            panel11.Controls.Add(label7);
            panel11.Location = new Point(13, 201);
            panel11.Name = "panel11";
            panel11.Size = new Size(413, 143);
            panel11.TabIndex = 16;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CalendarForeColor = Color.White;
            dateTimePicker2.CalendarMonthBackground = Color.FromArgb(30, 39, 46);
            dateTimePicker2.CalendarTitleBackColor = Color.FromArgb(47, 54, 64);
            dateTimePicker2.CalendarTitleForeColor = Color.White;
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(221, 40);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(177, 25);
            dateTimePicker2.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(219, 13);
            label8.Name = "label8";
            label8.Size = new Size(99, 19);
            label8.TabIndex = 4;
            label8.Text = "Schedule Date";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarForeColor = Color.White;
            dateTimePicker1.CalendarMonthBackground = Color.FromArgb(30, 39, 46);
            dateTimePicker1.CalendarTitleBackColor = Color.FromArgb(47, 54, 64);
            dateTimePicker1.CalendarTitleForeColor = Color.White;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(15, 40);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(177, 25);
            dateTimePicker1.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 13);
            label7.Name = "label7";
            label7.Size = new Size(92, 19);
            label7.TabIndex = 2;
            label7.Text = "Request Date";
            // 
            // btn_SelectDispatcher
            // 
            btn_SelectDispatcher.BackgroundImage = (Image)resources.GetObject("btn_SelectDispatcher.BackgroundImage");
            btn_SelectDispatcher.BackgroundImageLayout = ImageLayout.Center;
            btn_SelectDispatcher.FlatAppearance.BorderColor = Color.FromArgb(47, 54, 64);
            btn_SelectDispatcher.FlatAppearance.BorderSize = 0;
            btn_SelectDispatcher.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 60, 75);
            btn_SelectDispatcher.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 60, 75);
            btn_SelectDispatcher.FlatStyle = FlatStyle.Flat;
            btn_SelectDispatcher.ForeColor = Color.White;
            btn_SelectDispatcher.Location = new Point(386, 153);
            btn_SelectDispatcher.Name = "btn_SelectDispatcher";
            btn_SelectDispatcher.Size = new Size(36, 30);
            btn_SelectDispatcher.TabIndex = 15;
            btn_SelectDispatcher.UseVisualStyleBackColor = false;
            btn_SelectDispatcher.Click += btn_SelectDispatcher_Click;
            // 
            // btn_SelectFe
            // 
            btn_SelectFe.BackgroundImage = (Image)resources.GetObject("btn_SelectFe.BackgroundImage");
            btn_SelectFe.BackgroundImageLayout = ImageLayout.Center;
            btn_SelectFe.FlatAppearance.BorderColor = Color.FromArgb(47, 54, 64);
            btn_SelectFe.FlatAppearance.BorderSize = 0;
            btn_SelectFe.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 60, 75);
            btn_SelectFe.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 60, 75);
            btn_SelectFe.FlatStyle = FlatStyle.Flat;
            btn_SelectFe.ForeColor = Color.White;
            btn_SelectFe.Location = new Point(387, 83);
            btn_SelectFe.Name = "btn_SelectFe";
            btn_SelectFe.Size = new Size(36, 30);
            btn_SelectFe.TabIndex = 13;
            btn_SelectFe.UseVisualStyleBackColor = false;
            btn_SelectFe.Click += btn_SelectFe_Click;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(47, 54, 64);
            panel9.Controls.Add(label11);
            panel9.Location = new Point(13, 11);
            panel9.Name = "panel9";
            panel9.Size = new Size(413, 33);
            panel9.TabIndex = 10;
            // 
            // pn_ReplaceDevice
            // 
            pn_ReplaceDevice.BackColor = Color.FromArgb(30, 39, 46);
            pn_ReplaceDevice.Controls.Add(label5);
            pn_ReplaceDevice.Controls.Add(label9);
            pn_ReplaceDevice.Controls.Add(lb_ReplaceSim);
            pn_ReplaceDevice.Controls.Add(lb_ReplaceTerminal);
            pn_ReplaceDevice.Controls.Add(panel8);
            pn_ReplaceDevice.Controls.Add(button1);
            pn_ReplaceDevice.Controls.Add(button2);
            pn_ReplaceDevice.Location = new Point(15, 292);
            pn_ReplaceDevice.Name = "pn_ReplaceDevice";
            pn_ReplaceDevice.Size = new Size(313, 174);
            pn_ReplaceDevice.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.Location = new Point(15, 112);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 13;
            label5.Text = "Sim Card";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label9.Location = new Point(17, 54);
            label9.Name = "label9";
            label9.Size = new Size(53, 15);
            label9.TabIndex = 12;
            label9.Text = "Terminal";
            // 
            // lb_ReplaceSim
            // 
            lb_ReplaceSim.BackColor = Color.FromArgb(47, 54, 64);
            lb_ReplaceSim.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lb_ReplaceSim.Location = new Point(19, 131);
            lb_ReplaceSim.Name = "lb_ReplaceSim";
            lb_ReplaceSim.Padding = new Padding(9, 0, 0, 0);
            lb_ReplaceSim.Size = new Size(234, 30);
            lb_ReplaceSim.TabIndex = 11;
            lb_ReplaceSim.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_ReplaceTerminal
            // 
            lb_ReplaceTerminal.BackColor = Color.FromArgb(47, 54, 64);
            lb_ReplaceTerminal.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lb_ReplaceTerminal.Location = new Point(19, 73);
            lb_ReplaceTerminal.Name = "lb_ReplaceTerminal";
            lb_ReplaceTerminal.Padding = new Padding(9, 0, 0, 0);
            lb_ReplaceTerminal.Size = new Size(234, 30);
            lb_ReplaceTerminal.TabIndex = 10;
            lb_ReplaceTerminal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(47, 54, 64);
            panel8.Controls.Add(label14);
            panel8.Location = new Point(11, 11);
            panel8.Name = "panel8";
            panel8.Size = new Size(292, 33);
            panel8.TabIndex = 9;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(9, 7);
            label14.Name = "label14";
            label14.Size = new Size(136, 19);
            label14.TabIndex = 1;
            label14.Text = "Replacement Device";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(47, 54, 64);
            button1.BackgroundImageLayout = ImageLayout.Center;
            button1.FlatAppearance.BorderColor = Color.FromArgb(47, 54, 64);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(259, 73);
            button1.Name = "button1";
            button1.Size = new Size(36, 30);
            button1.TabIndex = 7;
            button1.Text = "T";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(47, 54, 64);
            button2.BackgroundImageLayout = ImageLayout.Center;
            button2.FlatAppearance.BorderColor = Color.FromArgb(47, 54, 64);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(259, 131);
            button2.Name = "button2";
            button2.Size = new Size(36, 30);
            button2.TabIndex = 8;
            button2.Text = "S";
            button2.UseVisualStyleBackColor = false;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(30, 39, 46);
            panel12.Controls.Add(pn_GridBody);
            panel12.Controls.Add(panel14);
            panel12.Location = new Point(792, 14);
            panel12.Name = "panel12";
            panel12.Size = new Size(482, 333);
            panel12.TabIndex = 15;
            // 
            // pn_GridBody
            // 
            pn_GridBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pn_GridBody.BackColor = Color.FromArgb(30, 39, 46);
            pn_GridBody.Controls.Add(dgv_ServiceHistory);
            pn_GridBody.Location = new Point(11, 50);
            pn_GridBody.Name = "pn_GridBody";
            pn_GridBody.Padding = new Padding(8);
            pn_GridBody.Size = new Size(458, 269);
            pn_GridBody.TabIndex = 14;
            // 
            // dgv_ServiceHistory
            // 
            dgv_ServiceHistory.AllowUserToAddRows = false;
            dgv_ServiceHistory.AllowUserToDeleteRows = false;
            dgv_ServiceHistory.AllowUserToResizeRows = false;
            dgv_ServiceHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_ServiceHistory.BackgroundColor = Color.FromArgb(30, 39, 46);
            dgv_ServiceHistory.BorderStyle = BorderStyle.None;
            dgv_ServiceHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(30, 39, 46);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(30, 39, 46);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgv_ServiceHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_ServiceHistory.ColumnHeadersHeight = 30;
            dgv_ServiceHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_ServiceHistory.Columns.AddRange(new DataGridViewColumn[] { Id, JobType, Status, Date });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(30, 39, 46);
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.Padding = new Padding(12, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(47, 54, 64);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_ServiceHistory.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_ServiceHistory.Dock = DockStyle.Fill;
            dgv_ServiceHistory.EnableHeadersVisualStyles = false;
            dgv_ServiceHistory.GridColor = Color.FromArgb(30, 39, 46);
            dgv_ServiceHistory.Location = new Point(8, 8);
            dgv_ServiceHistory.Name = "dgv_ServiceHistory";
            dgv_ServiceHistory.ReadOnly = true;
            dgv_ServiceHistory.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_ServiceHistory.RowHeadersVisible = false;
            dgv_ServiceHistory.RowTemplate.Height = 40;
            dgv_ServiceHistory.RowTemplate.ReadOnly = true;
            dgv_ServiceHistory.RowTemplate.Resizable = DataGridViewTriState.False;
            dgv_ServiceHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ServiceHistory.Size = new Size(442, 253);
            dgv_ServiceHistory.TabIndex = 1;
            // 
            // Id
            // 
            Id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Padding = new Padding(10, 0, 0, 0);
            Id.DefaultCellStyle = dataGridViewCellStyle2;
            Id.HeaderText = "ID";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Resizable = DataGridViewTriState.False;
            Id.Width = 80;
            // 
            // JobType
            // 
            JobType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            JobType.HeaderText = "Service";
            JobType.Name = "JobType";
            JobType.ReadOnly = true;
            // 
            // Status
            // 
            Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Status.HeaderText = "Status";
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // Date
            // 
            Date.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Date.HeaderText = "Date";
            Date.Name = "Date";
            Date.ReadOnly = true;
            Date.Width = 115;
            // 
            // panel14
            // 
            panel14.BackColor = Color.FromArgb(47, 54, 64);
            panel14.Controls.Add(label12);
            panel14.Location = new Point(11, 11);
            panel14.Name = "panel14";
            panel14.Size = new Size(458, 33);
            panel14.TabIndex = 11;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(9, 7);
            label12.Name = "label12";
            label12.Size = new Size(105, 19);
            label12.TabIndex = 1;
            label12.Text = "Service History";
            // 
            // panel13
            // 
            panel13.BackColor = Color.FromArgb(30, 39, 46);
            panel13.Controls.Add(panel16);
            panel13.Controls.Add(panel15);
            panel13.Location = new Point(792, 360);
            panel13.Name = "panel13";
            panel13.Size = new Size(482, 349);
            panel13.TabIndex = 16;
            // 
            // panel16
            // 
            panel16.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel16.BackColor = Color.FromArgb(30, 39, 46);
            panel16.Controls.Add(dgv_MultiMerchant);
            panel16.Location = new Point(11, 52);
            panel16.Name = "panel16";
            panel16.Padding = new Padding(8);
            panel16.Size = new Size(458, 285);
            panel16.TabIndex = 15;
            // 
            // dgv_MultiMerchant
            // 
            dgv_MultiMerchant.AllowUserToAddRows = false;
            dgv_MultiMerchant.AllowUserToDeleteRows = false;
            dgv_MultiMerchant.AllowUserToResizeRows = false;
            dgv_MultiMerchant.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_MultiMerchant.BackgroundColor = Color.FromArgb(30, 39, 46);
            dgv_MultiMerchant.BorderStyle = BorderStyle.None;
            dgv_MultiMerchant.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(30, 39, 46);
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(30, 39, 46);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgv_MultiMerchant.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgv_MultiMerchant.ColumnHeadersHeight = 30;
            dgv_MultiMerchant.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_MultiMerchant.Columns.AddRange(new DataGridViewColumn[] { TID, Terminal, Sim });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(30, 39, 46);
            dataGridViewCellStyle6.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.Padding = new Padding(12, 0, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(47, 54, 64);
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgv_MultiMerchant.DefaultCellStyle = dataGridViewCellStyle6;
            dgv_MultiMerchant.Dock = DockStyle.Fill;
            dgv_MultiMerchant.EnableHeadersVisualStyles = false;
            dgv_MultiMerchant.GridColor = Color.FromArgb(30, 39, 46);
            dgv_MultiMerchant.Location = new Point(8, 8);
            dgv_MultiMerchant.Name = "dgv_MultiMerchant";
            dgv_MultiMerchant.ReadOnly = true;
            dgv_MultiMerchant.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_MultiMerchant.RowHeadersVisible = false;
            dgv_MultiMerchant.RowTemplate.Height = 40;
            dgv_MultiMerchant.RowTemplate.ReadOnly = true;
            dgv_MultiMerchant.RowTemplate.Resizable = DataGridViewTriState.False;
            dgv_MultiMerchant.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_MultiMerchant.Size = new Size(442, 269);
            dgv_MultiMerchant.TabIndex = 1;
            // 
            // TID
            // 
            TID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Padding = new Padding(10, 0, 0, 0);
            TID.DefaultCellStyle = dataGridViewCellStyle5;
            TID.HeaderText = "TID";
            TID.Name = "TID";
            TID.ReadOnly = true;
            TID.Resizable = DataGridViewTriState.False;
            // 
            // Terminal
            // 
            Terminal.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Terminal.HeaderText = "Terminal";
            Terminal.Name = "Terminal";
            Terminal.ReadOnly = true;
            Terminal.Width = 120;
            // 
            // Sim
            // 
            Sim.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Sim.HeaderText = "Sim";
            Sim.Name = "Sim";
            Sim.ReadOnly = true;
            // 
            // panel15
            // 
            panel15.BackColor = Color.FromArgb(47, 54, 64);
            panel15.Controls.Add(label13);
            panel15.Location = new Point(11, 13);
            panel15.Name = "panel15";
            panel15.Size = new Size(458, 33);
            panel15.TabIndex = 12;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(9, 7);
            label13.Name = "label13";
            label13.Size = new Size(107, 19);
            label13.TabIndex = 1;
            label13.Text = "Multi Merchant";
            // 
            // richTextBox2
            // 
            richTextBox2.BackColor = Color.FromArgb(47, 54, 64);
            richTextBox2.BorderStyle = BorderStyle.None;
            richTextBox2.ForeColor = Color.White;
            richTextBox2.Location = new Point(322, 84);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(283, 131);
            richTextBox2.TabIndex = 10;
            richTextBox2.Text = "";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(21, 57);
            label15.Name = "label15";
            label15.Size = new Size(62, 19);
            label15.TabIndex = 11;
            label15.Text = "Remarks";
            // 
            // JobOrderDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 54, 64);
            ClientSize = new Size(1286, 723);
            Controls.Add(panel13);
            Controls.Add(panel12);
            Controls.Add(pn_ReplaceDevice);
            Controls.Add(pn_GeneralInfo);
            Controls.Add(pn_Header);
            Controls.Add(pn_CurrentDevice);
            Controls.Add(panel2);
            DoubleBuffered = true;
            Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "JobOrderDetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Service Information";
            KeyDown += ServiceDetailsForm_KeyDown;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pn_CurrentDevice.ResumeLayout(false);
            pn_CurrentDevice.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            pn_Header.ResumeLayout(false);
            pn_Header.PerformLayout();
            pn_GeneralInfo.ResumeLayout(false);
            pn_GeneralInfo.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            pn_ReplaceDevice.ResumeLayout(false);
            pn_ReplaceDevice.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel12.ResumeLayout(false);
            pn_GridBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_ServiceHistory).EndInit();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel13.ResumeLayout(false);
            panel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_MultiMerchant).EndInit();
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btn_SelectTerminal;
        private Button btn_SelectSim;
        private Panel panel2;
        private Label label5;
        private Label lb_FieldEngineer;
        private Panel pn_CurrentDevice;
        private Panel panel1;
        private Label lb_MerchantName;
        private Label label10;
        private Panel pn_Header;
        private Label lb_RequestNo;
        private Panel pn_GeneralInfo;
        private Label label11;
        private Panel panel6;
        private Label label1;
        private RichTextBox richTextBox1;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button2;
        private Panel panel9;
        private Label label6;
        private Button btn_SelectDispatcher;
        private TextBox txt_Dispatcher;
        private Button btn_SelectFe;
        private TextBox txt_FieldEngineer;
        private Label label3;
        private Panel panel11;
        private DateTimePicker dateTimePicker1;
        private Label label7;
        private DateTimePicker dateTimePicker2;
        private Label label8;
        private Label lb_ReplaceSim;
        private Label label9;
        private Label lb_SimSerial;
        private Label lb_TerminalSerial;
        private Label lb_Dispatcher;
        private Label label4;
        private Label label2;
        private Panel pn_ReplaceDevice;
        private Label lb_ReplaceTerminal;
        private Panel panel8;
        private Label label14;
        private Panel panel12;
        private Panel panel13;
        private Panel panel14;
        private Label label12;
        private Panel panel15;
        private Label label13;
        private Panel pn_GridBody;
        private DataGridView dgv_ServiceHistory;
        private Panel panel16;
        private DataGridView dgv_MultiMerchant;
        private DataGridViewTextBoxColumn TID;
        private DataGridViewTextBoxColumn Terminal;
        private DataGridViewTextBoxColumn Sim;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn JobType;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn Date;
        private Label lb_ServiceType;
        private Label label15;
        private RichTextBox richTextBox2;
    }
}