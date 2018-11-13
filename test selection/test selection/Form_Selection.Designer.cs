namespace ASCPR
{
    partial class Form3
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
            this.listBox_tests = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox_tests
            // 
            this.listBox_tests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_tests.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBox_tests.Font = new System.Drawing.Font("Arial", 13F);
            this.listBox_tests.FormattingEnabled = true;
            this.listBox_tests.ItemHeight = 19;
            this.listBox_tests.Location = new System.Drawing.Point(12, 17);
            this.listBox_tests.Name = "listBox_tests";
            this.listBox_tests.ScrollAlwaysVisible = true;
            this.listBox_tests.Size = new System.Drawing.Size(944, 574);
            this.listBox_tests.TabIndex = 0;
            this.listBox_tests.SelectedIndexChanged += new System.EventHandler(this.ListBox_tests_SelectedIndexChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(968, 611);
            this.Controls.Add(this.listBox_tests);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "Form3";
            this.Text = "Выбор тестов";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_tests;
    }
}