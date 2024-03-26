namespace U2.Suite.Brandmeister.Win.UserControls
{
    partial class StatusBar
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
            statusStrip1 = new StatusStrip();
            lblConnectionStatus = new ToolStripStatusLabel();
            lblSeparator = new ToolStripStatusLabel();
            lblStatistics = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblConnectionStatus, lblSeparator, lblStatistics });
            statusStrip1.Location = new Point(0, -2);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 32);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblConnectionStatus
            // 
            lblConnectionStatus.Name = "lblConnectionStatus";
            lblConnectionStatus.Size = new Size(195, 25);
            lblConnectionStatus.Text = "Connection status: N/A";
            // 
            // lblSeparator
            // 
            lblSeparator.Name = "lblSeparator";
            lblSeparator.Size = new Size(102, 25);
            lblSeparator.Text = "                  ";
            // 
            // lblStatistics
            // 
            lblStatistics.Name = "lblStatistics";
            lblStatistics.Size = new Size(100, 25);
            lblStatistics.Text = "Received: 0";
            // 
            // StatusBar
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(statusStrip1);
            Name = "StatusBar";
            Size = new Size(800, 30);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblConnectionStatus;
        private ToolStripStatusLabel lblSeparator;
        private ToolStripStatusLabel lblStatistics;
    }
}
