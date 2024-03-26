namespace U2.Suite.Brandmeister.Win
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ucStatusBar = new UserControls.StatusBar();
            tabControl1 = new TabControl();
            tpReports = new TabPage();
            ucReports = new UserControls.BrandmeisterReports();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            tpReports.SuspendLayout();
            SuspendLayout();
            // 
            // ucStatusBar
            // 
            ucStatusBar.Dock = DockStyle.Bottom;
            ucStatusBar.Location = new Point(0, 472);
            ucStatusBar.Margin = new Padding(1);
            ucStatusBar.Name = "ucStatusBar";
            ucStatusBar.Size = new Size(1056, 20);
            ucStatusBar.TabIndex = 2;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpReports);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1056, 472);
            tabControl1.TabIndex = 1;
            // 
            // tpReports
            // 
            tpReports.Controls.Add(ucReports);
            tpReports.Location = new Point(4, 24);
            tpReports.Margin = new Padding(2);
            tpReports.Name = "tpReports";
            tpReports.Padding = new Padding(2);
            tpReports.Size = new Size(1048, 444);
            tpReports.TabIndex = 0;
            tpReports.Text = "Reports";
            tpReports.UseVisualStyleBackColor = true;
            // 
            // ucReports
            // 
            ucReports.Dock = DockStyle.Fill;
            ucReports.Location = new Point(2, 2);
            ucReports.Name = "ucReports";
            ucReports.OnNewCall = null;
            ucReports.OnNewReport = null;
            ucReports.OnNewTalkGroup = null;
            ucReports.OnStatusChanged = null;
            ucReports.Size = new Size(1044, 440);
            ucReports.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2);
            tabPage2.Size = new Size(1048, 444);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Unique Calls";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 492);
            Controls.Add(tabControl1);
            Controls.Add(ucStatusBar);
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "Brandmeister Monitor";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            tabControl1.ResumeLayout(false);
            tpReports.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private UserControls.StatusBar ucStatusBar;
        private TabControl tabControl1;
        private TabPage tpReports;
        private TabPage tabPage2;
        private UserControls.BrandmeisterReports ucReports;
    }
}
