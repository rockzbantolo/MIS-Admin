namespace MIS_Admin.Forms
{
    partial class ServiceDetailsForm
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
            button1 = new Button();
            panel2 = new Panel();
            cmb_Terminals = new ComboBox();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(39, 60, 117);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(692, 63);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(462, 636);
            button1.Name = "button1";
            button1.Size = new Size(205, 43);
            button1.TabIndex = 1;
            button1.Text = "Dispatch";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(cmb_Terminals);
            panel2.Location = new Point(21, 86);
            panel2.Name = "panel2";
            panel2.Size = new Size(382, 159);
            panel2.TabIndex = 1;
            // 
            // cmb_Terminals
            // 
            cmb_Terminals.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmb_Terminals.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmb_Terminals.Font = new Font("Segoe UI", 12F);
            cmb_Terminals.FormattingEnabled = true;
            cmb_Terminals.Location = new Point(187, 16);
            cmb_Terminals.Name = "cmb_Terminals";
            cmb_Terminals.Size = new Size(172, 29);
            cmb_Terminals.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Location = new Point(21, 268);
            panel3.Name = "panel3";
            panel3.Size = new Size(646, 176);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Location = new Point(421, 86);
            panel4.Name = "panel4";
            panel4.Size = new Size(246, 159);
            panel4.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Location = new Point(21, 465);
            panel5.Name = "panel5";
            panel5.Size = new Size(646, 151);
            panel5.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(21, 19);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 12;
            label3.Text = "Job Order";
            // 
            // ServiceDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(692, 703);
            Controls.Add(button1);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "ServiceDetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Service Information";
            KeyDown += ServiceDetailsForm_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private ComboBox cmb_Terminals;
        private Label label3;
    }
}