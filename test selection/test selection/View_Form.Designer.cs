namespace ASCPR
{
    partial class View_Form
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
            this.button1 = new System.Windows.Forms.Button();
            this.TextBox_for_test = new System.Windows.Forms.TextBox();
            this.CheckBox_Header = new System.Windows.Forms.CheckBox();
            this.CheckBox_Result_tests = new System.Windows.Forms.CheckBox();
            this.CheckBox_Auto_Resume = new System.Windows.Forms.CheckBox();
            this.CheckBox_Scales = new System.Windows.Forms.CheckBox();
            this.CheckBox_Expression = new System.Windows.Forms.CheckBox();
            this.CheckBox_Answers = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button_save_file_Click);
            // 
            // TextBox_for_test
            // 
            this.TextBox_for_test.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_for_test.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TextBox_for_test.Font = new System.Drawing.Font("Arial", 13F);
            this.TextBox_for_test.Location = new System.Drawing.Point(15, 97);
            this.TextBox_for_test.Multiline = true;
            this.TextBox_for_test.Name = "TextBox_for_test";
            this.TextBox_for_test.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBox_for_test.Size = new System.Drawing.Size(757, 452);
            this.TextBox_for_test.TabIndex = 5;
            // 
            // CheckBox_Header
            // 
            this.CheckBox_Header.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBox_Header.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Header.Checked = true;
            this.CheckBox_Header.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Header.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckBox_Header.Location = new System.Drawing.Point(332, 7);
            this.CheckBox_Header.Name = "CheckBox_Header";
            this.CheckBox_Header.Size = new System.Drawing.Size(104, 22);
            this.CheckBox_Header.TabIndex = 6;
            this.CheckBox_Header.Text = "Заголовок";
            this.CheckBox_Header.UseVisualStyleBackColor = false;
            this.CheckBox_Header.Click += new System.EventHandler(this.CheckBox_Header_Click);
            // 
            // CheckBox_Result_tests
            // 
            this.CheckBox_Result_tests.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBox_Result_tests.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Result_tests.Checked = true;
            this.CheckBox_Result_tests.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Result_tests.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.CheckBox_Result_tests.Location = new System.Drawing.Point(332, 35);
            this.CheckBox_Result_tests.Name = "CheckBox_Result_tests";
            this.CheckBox_Result_tests.Size = new System.Drawing.Size(202, 22);
            this.CheckBox_Result_tests.TabIndex = 7;
            this.CheckBox_Result_tests.Text = "Результат тестирования";
            this.CheckBox_Result_tests.UseVisualStyleBackColor = false;
            this.CheckBox_Result_tests.Click += new System.EventHandler(this.CheckBox_Result_tests_Click);
            // 
            // CheckBox_Auto_Resume
            // 
            this.CheckBox_Auto_Resume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBox_Auto_Resume.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Auto_Resume.Checked = true;
            this.CheckBox_Auto_Resume.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Auto_Resume.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.CheckBox_Auto_Resume.Location = new System.Drawing.Point(332, 63);
            this.CheckBox_Auto_Resume.Name = "CheckBox_Auto_Resume";
            this.CheckBox_Auto_Resume.Size = new System.Drawing.Size(208, 22);
            this.CheckBox_Auto_Resume.TabIndex = 8;
            this.CheckBox_Auto_Resume.Text = "Автоматическое резюме";
            this.CheckBox_Auto_Resume.UseVisualStyleBackColor = false;
            this.CheckBox_Auto_Resume.Click += new System.EventHandler(this.CheckBox_Auto_Resume_Click);
            // 
            // CheckBox_Scales
            // 
            this.CheckBox_Scales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBox_Scales.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Scales.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.CheckBox_Scales.Location = new System.Drawing.Point(582, 35);
            this.CheckBox_Scales.Name = "CheckBox_Scales";
            this.CheckBox_Scales.Size = new System.Drawing.Size(80, 22);
            this.CheckBox_Scales.TabIndex = 9;
            this.CheckBox_Scales.Text = "Шкалы";
            this.CheckBox_Scales.UseVisualStyleBackColor = false;
            this.CheckBox_Scales.Click += new System.EventHandler(this.CheckBox_Scales_Click);
            // 
            // CheckBox_Expression
            // 
            this.CheckBox_Expression.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBox_Expression.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Expression.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.CheckBox_Expression.Location = new System.Drawing.Point(582, 7);
            this.CheckBox_Expression.Name = "CheckBox_Expression";
            this.CheckBox_Expression.Size = new System.Drawing.Size(190, 22);
            this.CheckBox_Expression.TabIndex = 10;
            this.CheckBox_Expression.Text = "Список характеристик";
            this.CheckBox_Expression.UseVisualStyleBackColor = false;
            this.CheckBox_Expression.Click += new System.EventHandler(this.CheckBox_Expression_Click);
            // 
            // CheckBox_Answers
            // 
            this.CheckBox_Answers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBox_Answers.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Answers.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.CheckBox_Answers.Location = new System.Drawing.Point(582, 63);
            this.CheckBox_Answers.Name = "CheckBox_Answers";
            this.CheckBox_Answers.Size = new System.Drawing.Size(82, 22);
            this.CheckBox_Answers.TabIndex = 11;
            this.CheckBox_Answers.Text = "Ответы";
            this.CheckBox_Answers.UseVisualStyleBackColor = false;
            this.CheckBox_Answers.CheckedChanged += new System.EventHandler(this.CheckBox_Answers_CheckedChanged);
            // 
            // View_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.CheckBox_Answers);
            this.Controls.Add(this.CheckBox_Expression);
            this.Controls.Add(this.CheckBox_Scales);
            this.Controls.Add(this.CheckBox_Auto_Resume);
            this.Controls.Add(this.CheckBox_Result_tests);
            this.Controls.Add(this.CheckBox_Header);
            this.Controls.Add(this.TextBox_for_test);
            this.Controls.Add(this.button1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "View_Form";
            this.Text = "View_Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TextBox_for_test;
        private System.Windows.Forms.CheckBox CheckBox_Header;
        private System.Windows.Forms.CheckBox CheckBox_Result_tests;
        private System.Windows.Forms.CheckBox CheckBox_Auto_Resume;
        private System.Windows.Forms.CheckBox CheckBox_Scales;
        private System.Windows.Forms.CheckBox CheckBox_Expression;
        private System.Windows.Forms.CheckBox CheckBox_Answers;
    }
}