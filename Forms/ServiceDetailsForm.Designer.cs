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
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(39, 60, 117);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(892, 63);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(844, 16);
            button1.Name = "button1";
            button1.Size = new Size(35, 28);
            button1.TabIndex = 1;
            button1.Text = "x";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(cmb_Terminals);
            panel2.Location = new Point(28, 86);
            panel2.Name = "panel2";
            panel2.Size = new Size(375, 159);
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
            panel3.Location = new Point(28, 268);
            panel3.Name = "panel3";
            panel3.Size = new Size(839, 176);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Location = new Point(421, 86);
            panel4.Name = "panel4";
            panel4.Size = new Size(446, 159);
            panel4.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Location = new Point(28, 465);
            panel5.Name = "panel5";
            panel5.Size = new Size(839, 159);
            panel5.TabIndex = 4;
            // 
            // ServiceDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(892, 648);
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
    }
}