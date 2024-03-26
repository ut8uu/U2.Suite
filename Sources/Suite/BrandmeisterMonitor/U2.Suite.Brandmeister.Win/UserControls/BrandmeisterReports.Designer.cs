namespace U2.Suite.Brandmeister.Win.UserControls
{
    partial class BrandmeisterReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrandmeisterReports));
            toolStripContainerReports = new ToolStripContainer();
            listView1 = new ListView();
            colTimestamp = new ColumnHeader();
            colCallsign = new ColumnHeader();
            colTalkGroup = new ColumnHeader();
            colDuration = new ColumnHeader();
            toolStrip1 = new ToolStrip();
            btnStart = new ToolStripButton();
            btnStop = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnFilter = new ToolStripButton();
            toolStripContainerReports.ContentPanel.SuspendLayout();
            toolStripContainerReports.TopToolStripPanel.SuspendLayout();
            toolStripContainerReports.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripContainerReports
            // 
            // 
            // toolStripContainerReports.ContentPanel
            // 
            toolStripContainerReports.ContentPanel.Controls.Add(listView1);
            toolStripContainerReports.ContentPanel.Margin = new Padding(2);
            toolStripContainerReports.ContentPanel.Size = new Size(802, 477);
            toolStripContainerReports.Dock = DockStyle.Fill;
            toolStripContainerReports.Location = new Point(0, 0);
            toolStripContainerReports.Margin = new Padding(2);
            toolStripContainerReports.Name = "toolStripContainerReports";
            toolStripContainerReports.Size = new Size(802, 516);
            toolStripContainerReports.TabIndex = 3;
            toolStripContainerReports.Text = "toolStripContainer1";
            // 
            // toolStripContainerReports.TopToolStripPanel
            // 
            toolStripContainerReports.TopToolStripPanel.Controls.Add(toolStrip1);
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { colTimestamp, colCallsign, colTalkGroup, colDuration });
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(0, 0);
            listView1.Margin = new Padding(2);
            listView1.Name = "listView1";
            listView1.Size = new Size(802, 477);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // colTimestamp
            // 
            colTimestamp.Text = "Timestamp";
            colTimestamp.Width = 150;
            // 
            // colCallsign
            // 
            colCallsign.Text = "Callsign";
            colCallsign.Width = 220;
            // 
            // colTalkGroup
            // 
            colTalkGroup.Text = "TG";
            // 
            // colDuration
            // 
            colDuration.Text = "Duration";
            colDuration.Width = 150;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnStart, btnStop, toolStripSeparator1, btnFilter });
            toolStrip1.Location = new Point(4, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(157, 39);
            toolStrip1.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnStart.Image = (Image)resources.GetObject("btnStart.Image");
            btnStart.ImageScaling = ToolStripItemImageScaling.None;
            btnStart.ImageTransparentColor = Color.Magenta;
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(36, 36);
            btnStart.Text = "Start";
            btnStart.ToolTipText = "Start the connection";
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnStop.Image = (Image)resources.GetObject("btnStop.Image");
            btnStop.ImageScaling = ToolStripItemImageScaling.None;
            btnStop.ImageTransparentColor = Color.Magenta;
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(36, 36);
            btnStop.Text = "Stop";
            btnStop.ToolTipText = "Stop the connection";
            btnStop.Click += btnStop_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // btnFilter
            // 
            btnFilter.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFilter.Image = (Image)resources.GetObject("btnFilter.Image");
            btnFilter.ImageScaling = ToolStripItemImageScaling.None;
            btnFilter.ImageTransparentColor = Color.Magenta;
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(36, 36);
            btnFilter.Text = "Filter";
            // 
            // BrandmeisterReports
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(toolStripContainerReports);
            Name = "BrandmeisterReports";
            Size = new Size(802, 516);
            toolStripContainerReports.ContentPanel.ResumeLayout(false);
            toolStripContainerReports.TopToolStripPanel.ResumeLayout(false);
            toolStripContainerReports.TopToolStripPanel.PerformLayout();
            toolStripContainerReports.ResumeLayout(false);
            toolStripContainerReports.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripContainer toolStripContainerReports;
        private ListView listView1;
        private ColumnHeader colTimestamp;
        private ColumnHeader colCallsign;
        private ColumnHeader colTalkGroup;
        private ColumnHeader colDuration;
        private ToolStrip toolStrip1;
        private ToolStripButton btnStart;
        private ToolStripButton btnStop;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnFilter;
    }
}
