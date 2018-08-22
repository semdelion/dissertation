namespace ASCPR
{
    partial class Form_Keys
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
            this.main_panel = new System.Windows.Forms.Panel();
            this.P_label = new System.Windows.Forms.Label();
            this.A_label = new System.Windows.Forms.Label();
            this.Q_label = new System.Windows.Forms.Label();
            this.C_Row_label = new System.Windows.Forms.Label();
            this.button_remove_row = new System.Windows.Forms.Button();
            this.button_add_row = new System.Windows.Forms.Button();
            this.button_create = new System.Windows.Forms.Button();
            this.button_right = new System.Windows.Forms.Button();
            this.button_left = new System.Windows.Forms.Button();
            this.Key_label = new System.Windows.Forms.Label();
            this.CoKey_label = new System.Windows.Forms.Label();
            this.CoKey_textbox = new System.Windows.Forms.TextBox();
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
            this.button_next.TabIndex = 11;
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
            this.button_back.TabIndex = 12;
            this.button_back.Text = "Назад";
            this.button_back.UseVisualStyleBackColor = false;
            // 
            // main_panel
            // 
            this.main_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main_panel.AutoScroll = true;
            this.main_panel.BackColor = System.Drawing.Color.Transparent;
            this.main_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.main_panel.Controls.Add(this.P_label);
            this.main_panel.Controls.Add(this.A_label);
            this.main_panel.Controls.Add(this.Q_label);
            this.main_panel.Controls.Add(this.C_Row_label);
            this.main_panel.Controls.Add(this.button_remove_row);
            this.main_panel.Controls.Add(this.button_add_row);
            this.main_panel.Location = new System.Drawing.Point(12, 104);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(760, 389);
            this.main_panel.TabIndex = 19;
            // 
            // P_label
            // 
            this.P_label.AutoSize = true;
            this.P_label.BackColor = System.Drawing.Color.Transparent;
            this.P_label.Font = new System.Drawing.Font("Arial", 13.75F, System.Drawing.FontStyle.Bold);
            this.P_label.Location = new System.Drawing.Point(245, 15);
            this.P_label.Name = "P_label";
            this.P_label.Size = new System.Drawing.Size(59, 22);
            this.P_label.TabIndex = 24;
            this.P_label.Text = "Балл";
            // 
            // A_label
            // 
            this.A_label.AutoSize = true;
            this.A_label.BackColor = System.Drawing.Color.Transparent;
            this.A_label.Font = new System.Drawing.Font("Arial", 13.75F, System.Drawing.FontStyle.Bold);
            this.A_label.Location = new System.Drawing.Point(130, 15);
            this.A_label.Name = "A_label";
            this.A_label.Size = new System.Drawing.Size(71, 22);
            this.A_label.TabIndex = 23;
            this.A_label.Text = "Ответ ";
            // 
            // Q_label
            // 
            this.Q_label.AutoSize = true;
            this.Q_label.BackColor = System.Drawing.Color.Transparent;
            this.Q_label.Font = new System.Drawing.Font("Arial", 13.75F, System.Drawing.FontStyle.Bold);
            this.Q_label.Location = new System.Drawing.Point(15, 15);
            this.Q_label.Name = "Q_label";
            this.Q_label.Size = new System.Drawing.Size(87, 22);
            this.Q_label.TabIndex = 22;
            this.Q_label.Text = "Вопрос ";
            // 
            // C_Row_label
            // 
            this.C_Row_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.C_Row_label.AutoSize = true;
            this.C_Row_label.BackColor = System.Drawing.Color.Transparent;
            this.C_Row_label.Font = new System.Drawing.Font("Arial", 13.75F, System.Drawing.FontStyle.Bold);
            this.C_Row_label.Location = new System.Drawing.Point(516, 14);
            this.C_Row_label.Name = "C_Row_label";
            this.C_Row_label.Size = new System.Drawing.Size(188, 22);
            this.C_Row_label.TabIndex = 21;
            this.C_Row_label.Text = "Количество строк ";
            // 
            // button_remove_row
            // 
            this.button_remove_row.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_remove_row.BackColor = System.Drawing.Color.Transparent;
            this.button_remove_row.BackgroundImage = global::test_selection.Properties.Resources.remove;
            this.button_remove_row.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_remove_row.FlatAppearance.BorderSize = 0;
            this.button_remove_row.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))), ((int)(((byte)(30)))));
            this.button_remove_row.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))), ((int)(((byte)(30)))));
            this.button_remove_row.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_remove_row.Location = new System.Drawing.Point(690, 55);
            this.button_remove_row.Name = "button_remove_row";
            this.button_remove_row.Size = new System.Drawing.Size(50, 50);
            this.button_remove_row.TabIndex = 20;
            this.button_remove_row.UseVisualStyleBackColor = false;
            // 
            // button_add_row
            // 
            this.button_add_row.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_add_row.BackColor = System.Drawing.Color.Transparent;
            this.button_add_row.BackgroundImage = global::test_selection.Properties.Resources.add;
            this.button_add_row.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_add_row.FlatAppearance.BorderSize = 0;
            this.button_add_row.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))), ((int)(((byte)(30)))));
            this.button_add_row.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))), ((int)(((byte)(30)))));
            this.button_add_row.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_add_row.Location = new System.Drawing.Point(510, 55);
            this.button_add_row.Name = "button_add_row";
            this.button_add_row.Size = new System.Drawing.Size(50, 50);
            this.button_add_row.TabIndex = 19;
            this.button_add_row.UseVisualStyleBackColor = false;
            // 
            // button_create
            // 
            this.button_create.BackColor = System.Drawing.SystemColors.Control;
            this.button_create.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_create.Location = new System.Drawing.Point(12, 39);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(269, 40);
            this.button_create.TabIndex = 22;
            this.button_create.Text = "Создать";
            this.button_create.UseVisualStyleBackColor = false;
            // 
            // button_right
            // 
            this.button_right.BackColor = System.Drawing.SystemColors.Control;
            this.button_right.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_right.Location = new System.Drawing.Point(562, 23);
            this.button_right.Name = "button_right";
            this.button_right.Size = new System.Drawing.Size(120, 40);
            this.button_right.TabIndex = 25;
            this.button_right.Text = "Следующий";
            this.button_right.UseVisualStyleBackColor = false;
            // 
            // button_left
            // 
            this.button_left.BackColor = System.Drawing.SystemColors.Control;
            this.button_left.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_left.Location = new System.Drawing.Point(367, 23);
            this.button_left.Name = "button_left";
            this.button_left.Size = new System.Drawing.Size(120, 40);
            this.button_left.TabIndex = 23;
            this.button_left.Text = "Предыдущий";
            this.button_left.UseVisualStyleBackColor = false;
            // 
            // Key_label
            // 
            this.Key_label.AutoSize = true;
            this.Key_label.BackColor = System.Drawing.Color.Transparent;
            this.Key_label.Font = new System.Drawing.Font("Arial", 20F);
            this.Key_label.Location = new System.Drawing.Point(493, 23);
            this.Key_label.Name = "Key_label";
            this.Key_label.Size = new System.Drawing.Size(23, 32);
            this.Key_label.TabIndex = 26;
            this.Key_label.Text = "/";
            // 
            // CoKey_label
            // 
            this.CoKey_label.AutoSize = true;
            this.CoKey_label.BackColor = System.Drawing.Color.Transparent;
            this.CoKey_label.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CoKey_label.Location = new System.Drawing.Point(12, 9);
            this.CoKey_label.Name = "CoKey_label";
            this.CoKey_label.Size = new System.Drawing.Size(174, 19);
            this.CoKey_label.TabIndex = 27;
            this.CoKey_label.Text = "Количество ключей";
            // 
            // CoKey_textbox
            // 
            this.CoKey_textbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CoKey_textbox.Font = new System.Drawing.Font("Arial", 13F);
            this.CoKey_textbox.Location = new System.Drawing.Point(208, 6);
            this.CoKey_textbox.Name = "CoKey_textbox";
            this.CoKey_textbox.Size = new System.Drawing.Size(73, 27);
            this.CoKey_textbox.TabIndex = 28;
            // 
            // Form_Keys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.CoKey_textbox);
            this.Controls.Add(this.CoKey_label);
            this.Controls.Add(this.Key_label);
            this.Controls.Add(this.button_right);
            this.Controls.Add(this.button_left);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.main_panel);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_next);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form_Keys";
            this.Text = "Form_Keys";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.main_panel.ResumeLayout(false);
            this.main_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.Button button_remove_row;
        private System.Windows.Forms.Button button_add_row;
        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.Button button_right;
        private System.Windows.Forms.Button button_left;
        private System.Windows.Forms.Label C_Row_label;
        private System.Windows.Forms.Label Key_label;
        private System.Windows.Forms.Label CoKey_label;
        private System.Windows.Forms.TextBox CoKey_textbox;
        private System.Windows.Forms.Label P_label;
        private System.Windows.Forms.Label A_label;
        private System.Windows.Forms.Label Q_label;
    }
}