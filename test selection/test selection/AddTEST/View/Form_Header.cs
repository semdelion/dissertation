using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASCPR
{
    public partial class Form_header : Form
    {
        private void Design_for_Form_header()
        {
            BackgroundImage = Design.Background;
            Design.Design_for_label(test_name_label);
            Design.Design_for_label(description_label);
            Design.Design_for_label(limitation_label);
            Design.Design_for_button(button_create);
            Design.Design_for_checkbox(NL_checkBox);
            Design.Design_for_checkbox(OO_checkBox);
            Design.Design_for_checkbox(AO_checkBox);
        }

        internal Form_header(Test TEST)
        {
            
            InitializeComponent();
            Design_for_Form_header();
            button_create.Click += new EventHandler(Button_create_Click);
            Show();

            test_name_textbox.Text = TEST._Header.Name;
            description_textBox.Text = TEST._Header.Description;

            if (TEST._Header.Verifier == VerificationDescriptors._NO_LIMITS)
                NL_checkBox.Checked = true;
            else if (TEST._Header.Verifier == VerificationDescriptors._AT_LEAST_ONE)
                AO_checkBox.Checked = true;
            else if (TEST._Header.Verifier == VerificationDescriptors._ONLY_ONE)
                OO_checkBox.Checked = true;

            void Button_create_Click(object sender, EventArgs e)
            {
                if (test_name_textbox.Text.Trim() != "" && !test_name_textbox.Text.Contains('<') && !test_name_textbox.Text.Contains('>'))
                    TEST._Header.Name = test_name_textbox.Text.Trim();
                else { MessageBox.Show("Ошибка: имя пусто или содержит символы \"<>\""); return; }
                if (!description_textBox.Text.Contains('<') && !description_textBox.Text.Contains('>'))
                    TEST._Header.Description = description_textBox.Text.Trim();
                else { MessageBox.Show("Ошибка: описание содержит символы \"<>\""); return; }
               
                if (NL_checkBox.Checked)
                    TEST._Header.Verifier = VerificationDescriptors._NO_LIMITS;
                else if (AO_checkBox.Checked)
                    TEST._Header.Verifier = VerificationDescriptors._AT_LEAST_ONE;
                else if (OO_checkBox.Checked)
                    TEST._Header.Verifier = VerificationDescriptors._ONLY_ONE;
                else {
                    MessageBox.Show("Ошибка: вы не выбрали вариант валидации");
                    return;
                }
                Form_Questions FQ = new Form_Questions(TEST);
                this.Close();
            }
        }
    }
}
