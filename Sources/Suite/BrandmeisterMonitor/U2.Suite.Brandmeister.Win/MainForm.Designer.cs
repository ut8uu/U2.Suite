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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripContainer1 = new ToolStripContainer();
            toolStrip1 = new ToolStrip();
            btnStart = new ToolStripButton();
            listView1 = new ListView();
            colTimestamp = new ColumnHeader();
            colCallsign = new ColumnHeader();
            colTalkGroup = new ColumnHeader();
            colDuration = new ColumnHeader();
            btnStop = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnFilter = new ToolStripButton();
            statusStrip1.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 788);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1573, 32);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(195, 25);
            toolStripStatusLabel1.Text = "Connection status: N/A";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(listView1);
            toolStripContainer1.ContentPanel.Size = new Size(1573, 747);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.Location = new Point(0, 0);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.Size = new Size(1573, 788);
            toolStripContainer1.TabIndex = 1;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip1);
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnStart, btnStop, toolStripSeparator1, btnFilter });
            toolStrip1.Location = new Point(4, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(178, 41);
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
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { colTimestamp, colCallsign, colTalkGroup, colDuration });
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(1573, 747);
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
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 41);
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1573, 820);
            Controls.Add(toolStripContainer1);
            Controls.Add(statusStrip1);
            Name = "MainForm";
            Text = "Brandmeister Monitor";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripContainer toolStripContainer1;
        private ToolStrip toolStrip1;
        private ToolStripButton btnStart;
        private ListView listView1;
        private ColumnHeader colTimestamp;
        private ColumnHeader colCallsign;
        private ColumnHeader colTalkGroup;
        private ColumnHeader colDuration;
        private ToolStripButton btnStop;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnFilter;
    }
}
