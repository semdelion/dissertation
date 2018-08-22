namespace ASCPR
{
    partial class ASPD
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
            this.listBox_test_results = new System.Windows.Forms.ListBox();
            this.button_testing = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.button_new_test = new System.Windows.Forms.Button();
            this.button_Test_change = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_test_results
            // 
            this.listBox_test_results.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_test_results.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBox_test_results.Font = new System.Drawing.Font("Arial", 13F);
            this.listBox_test_results.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listBox_test_results.FormattingEnabled = true;
            this.listBox_test_results.ItemHeight = 19;
            this.listBox_test_results.Location = new System.Drawing.Point(12, 71);
            this.listBox_test_results.Name = "listBox_test_results";
            this.listBox_test_results.Size = new System.Drawing.Size(1160, 593);
            this.listBox_test_results.TabIndex = 0;
            this.listBox_test_results.SelectedIndexChanged += new System.EventHandler(this.ListBox_test_results_SelectedIndexChanged);
            // 
            // button_testing
            // 
            this.button_testing.AutoSize = true;
            this.button_testing.BackColor = System.Drawing.SystemColors.Control;
            this.button_testing.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_testing.Location = new System.Drawing.Point(12, 12);
            this.button_testing.Margin = new System.Windows.Forms.Padding(0);
            this.button_testing.Name = "button_testing";
            this.button_testing.Size = new System.Drawing.Size(167, 40);
            this.button_testing.TabIndex = 1;
            this.button_testing.Text = "Новое тестирование";
            this.button_testing.UseVisualStyleBackColor = false;
            this.button_testing.Click += new System.EventHandler(this.Button_testing_Click);
            // 
            // button_update
            // 
            this.button_update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_update.BackColor = System.Drawing.SystemColors.Control;
            this.button_update.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_update.Location = new System.Drawing.Point(1053, 12);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(120, 40);
            this.button_update.TabIndex = 3;
            this.button_update.Text = "Обновить";
            this.button_update.UseVisualStyleBackColor = false;
            this.button_update.Click += new System.EventHandler(this.Button_update_Click);
            // 
            // button_new_test
            // 
            this.button_new_test.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_new_test.AutoSize = true;
            this.button_new_test.BackColor = System.Drawing.SystemColors.Control;
            this.button_new_test.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_new_test.Location = new System.Drawing.Point(927, 12);
            this.button_new_test.Name = "button_new_test";
            this.button_new_test.Size = new System.Drawing.Size(120, 40);
            this.button_new_test.TabIndex = 4;
            this.button_new_test.Text = "Добавить тест";
            this.button_new_test.UseVisualStyleBackColor = false;
            this.button_new_test.Click += new System.EventHandler(this.Add_new_test_Click);
            // 
            // button_Test_change
            // 
            this.button_Test_change.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Test_change.AutoSize = true;
            this.button_Test_change.BackColor = System.Drawing.SystemColors.Control;
            this.button_Test_change.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_Test_change.Location = new System.Drawing.Point(791, 12);
            this.button_Test_change.Name = "button_Test_change";
            this.button_Test_change.Size = new System.Drawing.Size(130, 40);
            this.button_Test_change.TabIndex = 5;
            this.button_Test_change.Text = "Изменить тест";
            this.button_Test_change.UseVisualStyleBackColor = false;
            this.button_Test_change.Click += new System.EventHandler(this.Button_Test_change_Click);
            // 
            // ASPD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.button_Test_change);
            this.Controls.Add(this.button_new_test);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.button_testing);
            this.Controls.Add(this.listBox_test_results);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ASPD";
            this.Text = "ASPD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_testing;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_new_test;
        private System.Windows.Forms.ListBox listBox_test_results;
        private System.Windows.Forms.Button button_Test_change;
    }
}