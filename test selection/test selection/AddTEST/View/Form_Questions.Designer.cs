namespace ASCPR
{
    partial class Form_Questions
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
            this.button_next = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.CoQ_label = new System.Windows.Forms.Label();
            this.CoQ_textbox = new System.Windows.Forms.TextBox();
            this.button_create = new System.Windows.Forms.Button();
            this.button_left = new System.Windows.Forms.Button();
            this.Q_label = new System.Windows.Forms.Label();
            this.button_right = new System.Windows.Forms.Button();
            this.main_panel = new System.Windows.Forms.Panel();
            this.question_textBox = new System.Windows.Forms.TextBox();
            this.CA_label = new System.Windows.Forms.Label();
            this.button_remove_answer = new System.Windows.Forms.Button();
            this.button_add_answer = new System.Windows.Forms.Button();
            this.main_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_next
            // 
            this.button_next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_next.BackColor = System.Drawing.SystemColors.Control;
            this.button_next.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_next.Location = new System.Drawing.Point(652, 509);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(120, 40);
            this.button_next.TabIndex = 10;
            this.button_next.Text = "Далее";
            this.button_next.UseVisualStyleBackColor = false;
            // 
            // button_back
            // 
            this.button_back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_back.BackColor = System.Drawing.SystemColors.Control;
            this.button_back.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_back.Location = new System.Drawing.Point(12, 509);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(120, 40);
            this.button_back.TabIndex = 11;
            this.button_back.Text = "Назад";
            this.button_back.UseVisualStyleBackColor = false;
            // 
            // CoQ_label
            // 
            this.CoQ_label.AutoSize = true;
            this.CoQ_label.BackColor = System.Drawing.Color.Transparent;
            this.CoQ_label.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CoQ_label.Location = new System.Drawing.Point(12, 9);
            this.CoQ_label.Name = "CoQ_label";
            this.CoQ_label.Size = new System.Drawing.Size(190, 19);
            this.CoQ_label.TabIndex = 12;
            this.CoQ_label.Text = "Количество вопросов";
            // 
            // CoQ_textbox
            // 
            this.CoQ_textbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CoQ_textbox.Font = new System.Drawing.Font("Arial", 13F);
            this.CoQ_textbox.Location = new System.Drawing.Point(208, 6);
            this.CoQ_textbox.Name = "CoQ_textbox";
            this.CoQ_textbox.Size = new System.Drawing.Size(73, 27);
            this.CoQ_textbox.TabIndex = 13;
            // 
            // button_create
            // 
            this.button_create.BackColor = System.Drawing.SystemColors.Control;
            this.button_create.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_create.Location = new System.Drawing.Point(12, 47);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(269, 40);
            this.button_create.TabIndex = 14;
            this.button_create.Text = "Создать";
            this.button_create.UseVisualStyleBackColor = false;
            // 
            // button_left
            // 
            this.button_left.BackColor = System.Drawing.SystemColors.Control;
            this.button_left.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_left.Location = new System.Drawing.Point(357, 33);
            this.button_left.Name = "button_left";
            this.button_left.Size = new System.Drawing.Size(120, 40);
            this.button_left.TabIndex = 15;
            this.button_left.Text = "Предыдущий";
            this.button_left.UseVisualStyleBackColor = false;
            // 
            // Q_label
            // 
            this.Q_label.AutoSize = true;
            this.Q_label.BackColor = System.Drawing.Color.Transparent;
            this.Q_label.Font = new System.Drawing.Font("Arial", 20F);
            this.Q_label.Location = new System.Drawing.Point(492, 33);
            this.Q_label.Name = "Q_label";
            this.Q_label.Size = new System.Drawing.Size(54, 32);
            this.Q_label.TabIndex = 16;
            this.Q_label.Text = " Из";
            // 
            // button_right
            // 
            this.button_right.BackColor = System.Drawing.SystemColors.Control;
            this.button_right.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_right.Location = new System.Drawing.Point(552, 33);
            this.button_right.Name = "button_right";
            this.button_right.Size = new System.Drawing.Size(120, 40);
            this.button_right.TabIndex = 17;
            this.button_right.Text = "Следующий";
            this.button_right.UseVisualStyleBackColor = false;
            // 
            // main_panel
            // 
            this.main_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main_panel.AutoScroll = true;
            this.main_panel.BackColor = System.Drawing.Color.Transparent;
            this.main_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.main_panel.Controls.Add(this.question_textBox);
            this.main_panel.Controls.Add(this.CA_label);
            this.main_panel.Controls.Add(this.button_remove_answer);
            this.main_panel.Controls.Add(this.button_add_answer);
            this.main_panel.Location = new System.Drawing.Point(16, 107);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(756, 386);
            this.main_panel.TabIndex = 18;
            // 
            // question_textBox
            // 
            this.question_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.question_textBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.question_textBox.Font = new System.Drawing.Font("Arial", 13F);
            this.question_textBox.Location = new System.Drawing.Point(12, 12);
            this.question_textBox.Multiline = true;
            this.question_textBox.Name = "question_textBox";
            this.question_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.question_textBox.Size = new System.Drawing.Size(420, 50);
            this.question_textBox.TabIndex = 21;
            // 
            // CA_label
            // 
            this.CA_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CA_label.AutoSize = true;
            this.CA_label.BackColor = System.Drawing.Color.Transparent;
            this.CA_label.Font = new System.Drawing.Font("Arial", 13.75F, System.Drawing.FontStyle.Bold);
            this.CA_label.Location = new System.Drawing.Point(502, 30);
            this.CA_label.Name = "CA_label";
            this.CA_label.Size = new System.Drawing.Size(211, 22);
            this.CA_label.TabIndex = 19;
            this.CA_label.Text = "Количество ответов ";
            // 
            // button_remove_answer
            // 
            this.button_remove_answer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_remove_answer.BackColor = System.Drawing.Color.Transparent;
            this.button_remove_answer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_remove_answer.FlatAppearance.BorderSize = 0;
            this.button_remove_answer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))), ((int)(((byte)(30)))));
            this.button_remove_answer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))), ((int)(((byte)(30)))));
            this.button_remove_answer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_remove_answer.Location = new System.Drawing.Point(686, 55);
            this.button_remove_answer.Name = "button_remove_answer";
            this.button_remove_answer.Size = new System.Drawing.Size(50, 50);
            this.button_remove_answer.TabIndex = 20;
            this.button_remove_answer.UseVisualStyleBackColor = false;
            // 
            // button_add_answer
            // 
            this.button_add_answer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_add_answer.BackColor = System.Drawing.Color.Transparent;
            this.button_add_answer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_add_answer.FlatAppearance.BorderSize = 0;
            this.button_add_answer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))), ((int)(((byte)(30)))));
            this.button_add_answer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))), ((int)(((byte)(30)))));
            this.button_add_answer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_add_answer.Location = new System.Drawing.Point(506, 55);
            this.button_add_answer.Name = "button_add_answer";
            this.button_add_answer.Size = new System.Drawing.Size(50, 50);
            this.button_add_answer.TabIndex = 19;
            this.button_add_answer.UseVisualStyleBackColor = false;
            // 
            // Form_Questions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.main_panel);
            this.Controls.Add(this.button_right);
            this.Controls.Add(this.Q_label);
            this.Controls.Add(this.button_left);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.CoQ_textbox);
            this.Controls.Add(this.CoQ_label);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_next);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form_Questions";
            this.Text = "Form_Questions";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.main_panel.ResumeLayout(false);
            this.main_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Label CoQ_label;
        private System.Windows.Forms.TextBox CoQ_textbox;
        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.Button button_left;
        private System.Windows.Forms.Label Q_label;
        private System.Windows.Forms.Button button_right;
        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.Button button_add_answer;
        private System.Windows.Forms.Button button_remove_answer;
        private System.Windows.Forms.Label CA_label;
        private System.Windows.Forms.TextBox question_textBox;
    }
}