namespace ASCPR
{
    partial class Form_header
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
            this.test_name_label = new System.Windows.Forms.Label();
            this.description_label = new System.Windows.Forms.Label();
            this.test_name_textbox = new System.Windows.Forms.TextBox();
            this.description_textBox = new System.Windows.Forms.TextBox();
            this.limitation_label = new System.Windows.Forms.Label();
            this.OO_checkBox = new System.Windows.Forms.CheckBox();
            this.AO_checkBox = new System.Windows.Forms.CheckBox();
            this.NL_checkBox = new System.Windows.Forms.CheckBox();
            this.button_create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // test_name_label
            // 
            this.test_name_label.AutoSize = true;
            this.test_name_label.BackColor = System.Drawing.Color.Transparent;
            this.test_name_label.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.test_name_label.Location = new System.Drawing.Point(12, 9);
            this.test_name_label.Name = "test_name_label";
            this.test_name_label.Size = new System.Drawing.Size(92, 19);
            this.test_name_label.TabIndex = 0;
            this.test_name_label.Text = "Имя теста";
            // 
            // description_label
            // 
            this.description_label.AutoSize = true;
            this.description_label.BackColor = System.Drawing.Color.Transparent;
            this.description_label.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.description_label.Location = new System.Drawing.Point(12, 72);
            this.description_label.Name = "description_label";
            this.description_label.Size = new System.Drawing.Size(262, 19);
            this.description_label.TabIndex = 1;
            this.description_label.Text = "Дополнительная информация";
            // 
            // test_name_textbox
            // 
            this.test_name_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.test_name_textbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.test_name_textbox.Font = new System.Drawing.Font("Arial", 13F);
            this.test_name_textbox.Location = new System.Drawing.Point(12, 31);
            this.test_name_textbox.Name = "test_name_textbox";
            this.test_name_textbox.Size = new System.Drawing.Size(760, 27);
            this.test_name_textbox.TabIndex = 2;
            // 
            // description_textBox
            // 
            this.description_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.description_textBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.description_textBox.Font = new System.Drawing.Font("Arial", 13F);
            this.description_textBox.Location = new System.Drawing.Point(12, 94);
            this.description_textBox.Multiline = true;
            this.description_textBox.Name = "description_textBox";
            this.description_textBox.Size = new System.Drawing.Size(760, 292);
            this.description_textBox.TabIndex = 3;
            // 
            // limitation_label
            // 
            this.limitation_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.limitation_label.AutoSize = true;
            this.limitation_label.BackColor = System.Drawing.Color.Transparent;
            this.limitation_label.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.limitation_label.Location = new System.Drawing.Point(8, 405);
            this.limitation_label.Name = "limitation_label";
            this.limitation_label.Size = new System.Drawing.Size(180, 19);
            this.limitation_label.TabIndex = 4;
            this.limitation_label.Text = "Возможность ответа";
            // 
            // OO_checkBox
            // 
            this.OO_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OO_checkBox.AutoSize = true;
            this.OO_checkBox.BackColor = System.Drawing.Color.Transparent;
            this.OO_checkBox.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.OO_checkBox.Location = new System.Drawing.Point(12, 437);
            this.OO_checkBox.Name = "OO_checkBox";
            this.OO_checkBox.Size = new System.Drawing.Size(133, 23);
            this.OO_checkBox.TabIndex = 5;
            this.OO_checkBox.Text = "Только один";
            this.OO_checkBox.UseVisualStyleBackColor = false;
            // 
            // AO_checkBox
            // 
            this.AO_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AO_checkBox.AutoSize = true;
            this.AO_checkBox.BackColor = System.Drawing.Color.Transparent;
            this.AO_checkBox.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.AO_checkBox.Location = new System.Drawing.Point(12, 466);
            this.AO_checkBox.Name = "AO_checkBox";
            this.AO_checkBox.Size = new System.Drawing.Size(185, 23);
            this.AO_checkBox.TabIndex = 6;
            this.AO_checkBox.Text = "Как минимум один";
            this.AO_checkBox.UseVisualStyleBackColor = false;
            // 
            // NL_checkBox
            // 
            this.NL_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NL_checkBox.AutoSize = true;
            this.NL_checkBox.BackColor = System.Drawing.Color.Transparent;
            this.NL_checkBox.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.NL_checkBox.Location = new System.Drawing.Point(12, 495);
            this.NL_checkBox.Name = "NL_checkBox";
            this.NL_checkBox.Size = new System.Drawing.Size(167, 23);
            this.NL_checkBox.TabIndex = 7;
            this.NL_checkBox.Text = "Без ограничений";
            this.NL_checkBox.UseVisualStyleBackColor = false;
            // 
            // button_create
            // 
            this.button_create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_create.BackColor = System.Drawing.SystemColors.Control;
            this.button_create.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.button_create.Location = new System.Drawing.Point(652, 509);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(120, 40);
            this.button_create.TabIndex = 9;
            this.button_create.Text = "Создать";
            this.button_create.UseVisualStyleBackColor = false;
            // 
            // Form_header
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.NL_checkBox);
            this.Controls.Add(this.AO_checkBox);
            this.Controls.Add(this.OO_checkBox);
            this.Controls.Add(this.limitation_label);
            this.Controls.Add(this.description_textBox);
            this.Controls.Add(this.test_name_textbox);
            this.Controls.Add(this.description_label);
            this.Controls.Add(this.test_name_label);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form_header";
            this.Text = "Form_header";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label test_name_label;
        private System.Windows.Forms.Label description_label;
        private System.Windows.Forms.TextBox test_name_textbox;
        private System.Windows.Forms.TextBox description_textBox;
        private System.Windows.Forms.Label limitation_label;
        private System.Windows.Forms.CheckBox OO_checkBox;
        private System.Windows.Forms.CheckBox AO_checkBox;
        private System.Windows.Forms.CheckBox NL_checkBox;
        private System.Windows.Forms.Button button_create;
    }
}