namespace MIS_Admin
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            pn_Body = new Panel();
            SuspendLayout();
            // 
            // pn_Body
            // 
            pn_Body.BackColor = Color.FromArgb(47, 54, 64);
            pn_Body.Dock = DockStyle.Fill;
            pn_Body.Location = new Point(0, 0);
            pn_Body.Name = "pn_Body";
            pn_Body.Size = new Size(1264, 861);
            pn_Body.TabIndex = 3;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(47, 54, 64);
            ClientSize = new Size(1264, 861);
            Controls.Add(pn_Body);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Management";
            WindowState = FormWindowState.Maximized;
            Load += Main_Load;
            KeyPress += Main_KeyPress;
            ResumeLayout(false);
        }

        #endregion

        private Panel pn_Body;
    }
}