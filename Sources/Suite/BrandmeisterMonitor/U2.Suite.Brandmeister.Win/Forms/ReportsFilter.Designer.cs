namespace U2.Suite.Brandmeister.Win.Forms
{
    partial class ReportsFilter
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
            cbFilterTarget = new ComboBox();
            comboBox2 = new ComboBox();
            textBox1 = new TextBox();
            btnAdd = new Button();
            cbAndOr = new ComboBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(cbAndOr);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(cbFilterTarget);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 47);
            panel1.TabIndex = 0;
            // 
            // cbFilterTarget
            // 
            cbFilterTarget.FormattingEnabled = true;
            cbFilterTarget.Location = new Point(120, 13);
            cbFilterTarget.Name = "cbFilterTarget";
            cbFilterTarget.Size = new Size(168, 23);
            cbFilterTarget.TabIndex = 0;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(294, 13);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(159, 23);
            comboBox2.TabIndex = 1;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(459, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(196, 23);
            textBox1.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(661, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 23);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // cbAndOr
            // 
            cbAndOr.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAndOr.FormattingEnabled = true;
            cbAndOr.Items.AddRange(new object[] { "Or", "And" });
            cbAndOr.Location = new Point(12, 13);
            cbAndOr.Name = "cbAndOr";
            cbAndOr.Size = new Size(102, 23);
            cbAndOr.TabIndex = 0;
            // 
            // ReportsFilter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ReportsFilter";
            Text = "Reports Filter";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnAdd;
        private TextBox textBox1;
        private ComboBox comboBox2;
        private ComboBox cbFilterTarget;
        private ComboBox cbAndOr;
    }
}