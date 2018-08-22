namespace ASCPR
{
    partial class Form2
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
            this.LABEL_TEST_NAME = new System.Windows.Forms.Label();
            this.LABEL_TEST_DESCRIPTION = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LABEL_TEST_NAME
            // 
            this.LABEL_TEST_NAME.AutoSize = true;
            this.LABEL_TEST_NAME.BackColor = System.Drawing.Color.Transparent;
            this.LABEL_TEST_NAME.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.LABEL_TEST_NAME.Location = new System.Drawing.Point(484, 9);
            this.LABEL_TEST_NAME.Name = "LABEL_TEST_NAME";
            this.LABEL_TEST_NAME.Size = new System.Drawing.Size(151, 32);
            this.LABEL_TEST_NAME.TabIndex = 0;
            this.LABEL_TEST_NAME.Text = "Test name";
            // 
            // LABEL_TEST_DESCRIPTION
            // 
            this.LABEL_TEST_DESCRIPTION.AutoSize = true;
            this.LABEL_TEST_DESCRIPTION.BackColor = System.Drawing.Color.Transparent;
            this.LABEL_TEST_DESCRIPTION.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Italic);
            this.LABEL_TEST_DESCRIPTION.Location = new System.Drawing.Point(8, 59);
            this.LABEL_TEST_DESCRIPTION.Name = "LABEL_TEST_DESCRIPTION";
            this.LABEL_TEST_DESCRIPTION.Size = new System.Drawing.Size(106, 23);
            this.LABEL_TEST_DESCRIPTION.TabIndex = 1;
            this.LABEL_TEST_DESCRIPTION.Text = "description";
            // 
            // Form2
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.LABEL_TEST_DESCRIPTION);
            this.Controls.Add(this.LABEL_TEST_NAME);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "Form2";
            this.Text = "Test";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LABEL_TEST_NAME;
        private System.Windows.Forms.Label LABEL_TEST_DESCRIPTION;
    }
}