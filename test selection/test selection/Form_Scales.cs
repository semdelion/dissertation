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
    internal partial class Form_Scales : Form
    {
        private int Scale_number = 0;

        private void Hide_Scale()
        {
            main_panel.Hide();
            button_left.Hide();
            button_right.Hide();
            Scale_label.Hide();
        }

        private void Show_Scale()
        {
            main_panel.Show();
            button_left.Show();
            button_right.Show();
            Scale_label.Show();
        }

        private new void Resize()
        {
            button_right.Location = new Point(Scale_label.Location.X + 15 + Scale_label.Width, button_right.Location.Y);
        }

        private void TextBox_KeyPress_integers(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (number == 8)
                e.Handled = false;
            else if (!Char.IsDigit(number))
                e.Handled = true;
        }
        
        private void Design_for_Form_Scales()
        {
            BackgroundImage = Design.Background;

            Design.Design_for_button(button_create);
            Design.Design_for_button(button_back);
            Design.Design_for_button(button_next);
            Design.Design_for_button(button_left);
            Design.Design_for_button(button_right);

            Design.Design_for_label(CoScale_label);
            Design.Design_for_label(Scale_label);

            Design.Design_for_label(if_label);
            Design.Design_for_label(name_Scale_label);
            Design.Design_for_label(description_label);

            Design.Design_for_textbox(CoScale_textbox);
            Design.Design_for_textbox(if_textBox);
            Design.Design_for_textbox(name_Scale_textBox);
            Design.Design_for_textbox(description_textBox);

            Scale_label.Font = new Font("Arial", 24F);
            CoScale_textbox.Location = new Point(CoScale_label.Location.X + 15 + CoScale_label.Width, CoScale_label.Location.Y);
            button_create.Width = CoScale_textbox.Location.X + CoScale_textbox.Width - CoScale_label.Location.X;
            Hide_Scale();
        }

        private void Create_Scale(Test TEST)
        {
            Scale_label.Text = Convert.ToString(Scale_number + 1) + " / " + Convert.ToString(TEST._Scales.Count);

            Design.Design_for_textbox(name_Scale_textBox);
            Design.Design_for_textbox(description_textBox);

            if_textBox.Text = TEST._Scales[Scale_number].If_scale;
            name_Scale_textBox.Text = TEST._Scales[Scale_number].Name_scale;
            description_textBox.Text = TEST._Scales[Scale_number].Manifestation;

            Resize();
            Show_Scale();
        }

        public Form_Scales(Test TEST)
        {
            InitializeComponent();
            Design_for_Form_Scales();
            Show();

            CoScale_textbox.Text = Convert.ToString(TEST._Scales.Count);
            CoScale_textbox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress_integers);
            button_left.Click += new EventHandler(button_left_click);
            button_right.Click += new EventHandler(button_right_click);
            button_create.Click += new EventHandler(button_create_click);
            button_next.Click += new EventHandler(button_next_click);
            button_back.Click += new EventHandler(button_back_click);

            if (TEST._Scales.Count > 0)
                Create_Scale(TEST);

            void button_create_click(object sender, EventArgs e)
            {
                try
                {
                    int tmp = Convert.ToInt32(CoScale_textbox.Text);
                    if (tmp > 0)
                    {
                        if (tmp > TEST._Scales.Count)
                        {
                            for (int i = TEST._Scales.Count; i < tmp; i++)
                                TEST._Scales.Add(new Scale());
                            Create_Scale(TEST);
                        }
                        if (tmp < TEST._Scales.Count)
                        {
                            for (int i = TEST._Scales.Count - 1; i >= tmp; i--)
                                TEST._Scales.RemoveAt(i);
                            if (Scale_number >= TEST._Scales.Count)
                                Scale_number = TEST._Scales.Count - 1;
                            Create_Scale(TEST);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка: некорректно задано число вопросов. OS");
                }
            }

            void button_left_click(object sender, EventArgs e)
            {
                if (Scale_number <= 0)
                    return;
                Scale_number--;
                Create_Scale(TEST);
            }

            void button_right_click(object sender, EventArgs e)
            {
                if (if_textBox.Text.Trim() == "" || if_textBox.Text.Contains('[') || if_textBox.Text.Contains(']'))
                {
                    MessageBox.Show("Ошибка: условие задано неверно! недопустимые символы [ ]");
                    return;
                }

                if (name_Scale_textBox.Text.Trim() == "" || name_Scale_textBox.Text.Contains('(') || name_Scale_textBox.Text.Contains(')'))
                {
                    MessageBox.Show("Ошибка: имя шкалы задано неверно!  недопустимые символы  ( )");
                    return;
                }

                if (description_textBox.Text.Trim() == "" || description_textBox.Text.Contains('<') || description_textBox.Text.Contains('>'))
                {
                    MessageBox.Show("Ошибка: условие задано неверно!");
                    return;
                }

                TEST._Scales[Scale_number] = new Scale( if_textBox.Text.Trim(),
                                                        name_Scale_textBox.Text.Trim(),
                                                        description_textBox.Text.Trim());

                if (Scale_number >= TEST._Questions.Count - 1)
                {
                    MessageBox.Show("Добавлена последная шкала");
                    return;
                }

                Scale_number++;
                Create_Scale(TEST);
            }

            void button_next_click(object sender, EventArgs e)
            {
                if (TEST._Scales.Count > 0 && TEST._Scales[TEST._Scales.Count - 1].If_scale != "" && TEST._Scales[TEST._Scales.Count - 1].Name_scale != "" && TEST._Scales[TEST._Scales.Count - 1].Manifestation != "")
                {
                    this.Close();
                    Form_Fuzzy_Sets FFS = new Form_Fuzzy_Sets(TEST);
                }
                else
                    MessageBox.Show("Ошибка: не все шкалы заданы");
            }

            void button_back_click(object sender, EventArgs e)
            {
                this.Close();
                Form_Keys FK = new Form_Keys(TEST);
            }
        }
    }
}