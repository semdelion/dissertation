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
    public partial class Form_Keys : Form
    {
        private int Key_number = 0;
        List<TextBox> Questions_form = new List<TextBox>();
        List<TextBox> Answers_form = new List<TextBox>();
        List<TextBox> Points_form = new List<TextBox>();

        private new void Resize()
        {
            button_right.Location = new Point(Key_label.Location.X + 15 + Key_label.Width, button_right.Location.Y);
        }

        private void Hide_O()
        {
            main_panel.Hide();
            button_left.Hide();
            button_right.Hide();
            Key_label.Hide();
        }

        private void Show_O()
        {
            main_panel.Show();
            button_left.Show();
            button_right.Show();
            Key_label.Show();
        }

        private void Clear_panel()
        {
            for (int i = Questions_form.Count - 1; i >= 0; i--)
            {
                main_panel.Controls.Remove(Questions_form[i]);
                main_panel.Controls.Remove(Answers_form[i]);
                main_panel.Controls.Remove(Points_form[i]);
            }
        }

        private void Delete_last_row_on_panel()
        {
            main_panel.Controls.Remove(Questions_form[Questions_form.Count - 1]);
            main_panel.Controls.Remove(Answers_form[Answers_form.Count - 1]);
            main_panel.Controls.Remove(Points_form[Points_form.Count - 1]);
        }

        private void Design_for_Form_Keys()
        {
            BackgroundImage = Design.Background;

            Design.Design_for_button(button_create);
            Design.Design_for_button(button_back);
            Design.Design_for_button(button_next);
            Design.Design_for_button(button_left);
            Design.Design_for_button(button_right);

            Design.Design_for_label(CoKey_label);
            Design.Design_for_label(C_Row_label);
            Design.Design_for_label(Key_label);

            Design.Design_for_label(Q_label);
            Design.Design_for_label(A_label);
            Design.Design_for_label(P_label);

            Design.Design_for_textbox(CoKey_textbox);

            Key_label.Font = new Font("Arial", 24F);
            CoKey_textbox.Location = new Point(CoKey_label.Location.X + 15 + CoKey_label.Width, CoKey_label.Location.Y);
            button_create.Width = CoKey_textbox.Location.X + CoKey_textbox.Width - CoKey_label.Location.X;
            Hide_O();
        }

        private void Add_row_on_form(int y, TextBox question, TextBox answer, TextBox point)
        {
            Additional_functions.Create_textbox(question, 100, 15, y);
            question.Height = 20;
            question.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top) | System.Windows.Forms.AnchorStyles.Left));
            main_panel.Controls.Add(question);

            Additional_functions.Create_textbox(answer, 100, 130, y);
            answer.Height = 20;
            answer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top) | System.Windows.Forms.AnchorStyles.Left));
            main_panel.Controls.Add(answer);

            Additional_functions.Create_textbox(point, 100, 245, y);
            point.Height = 20;
            point.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top) | System.Windows.Forms.AnchorStyles.Left));
            main_panel.Controls.Add(point);
        }

        private void Create_row(Test TEST, int index=0)
        {
            this.SuspendLayout();
            C_Row_label.Text = "Количество строк " + Convert.ToString(TEST._Keys[Key_number].Count);

            int height;
            if (index == 0)
                height = Q_label.Location.Y + 15 + Q_label.Height;
            else if (index > TEST._Keys[Key_number].Count - 1)
                return;
            else
                height = Questions_form[index - 1].Location.Y + 15 + Questions_form[index - 1].Height;
            for (int i = index; i < TEST._Keys[Key_number].Count; i++)
            {
                Add_row_on_form(height, Questions_form[i], Answers_form[i], Points_form[i]);
                Questions_form[i].Text = Convert.ToString(TEST._Keys[Key_number][i].Question);
                Answers_form[i].Text = Convert.ToString(TEST._Keys[Key_number][i].Answer);
                Points_form[i].Text = Convert.ToString(TEST._Keys[Key_number][i].Point);

                Questions_form[i].KeyPress += new KeyPressEventHandler(TextBox_KeyPress_integers);
                Answers_form[i].KeyPress += new KeyPressEventHandler(TextBox_KeyPress_integers);
                Points_form[i].KeyPress += new KeyPressEventHandler(TextBox_KeyPress_real);

                height = Questions_form[i].Location.Y + 15 + Questions_form[i].Height;
            }
            this.ResumeLayout(false);
        }

        private void TextBox_KeyPress_real(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (number == ',' || number == 8)
                e.Handled = false;
            else if (!Char.IsDigit(number))
                e.Handled = true;
        }

        private void TextBox_KeyPress_integers(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (number == 8)
                e.Handled = false;
            else if (!Char.IsDigit(number))
                e.Handled = true;
        }

        private void Create_Key(Test TEST)
        {
            Key_label.Text = Convert.ToString(Key_number + 1) + " / " + Convert.ToString(TEST._Keys.Count);
            Clear_panel();

            Questions_form = new List<TextBox>();
            Answers_form = new List<TextBox>();
            Points_form = new List<TextBox>();

            for (int i = 0; i < TEST._Keys[Key_number].Count; i++)
            {
                Questions_form.Add(new TextBox());
                Answers_form.Add(new TextBox());
                Points_form.Add(new TextBox());
            }
            Create_row(TEST);
            Resize();
            Show_O();
        }

        internal Form_Keys(Test TEST)
        {
            InitializeComponent();
            Design_for_Form_Keys();
            Show();

            CoKey_textbox.Text = Convert.ToString(TEST._Keys.Count);
            CoKey_textbox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress_integers);
            button_add_row.Click += new EventHandler(button_add_row_click);
            button_remove_row.Click += new EventHandler(button_remove_row_click);
            button_left.Click += new EventHandler(button_left_click);
            button_right.Click += new EventHandler(button_right_click);
            button_create.Click += new EventHandler(button_create_click);
            button_next.Click += new EventHandler(button_next_click);
            button_back.Click += new EventHandler(button_back_click);
            if (TEST._Keys.Count > 0)
                Create_Key(TEST);

            void button_add_row_click(object sender, EventArgs e)
            {
                TEST._Keys[Key_number].Add(new Element());
                Questions_form.Add(new TextBox());
                Answers_form.Add(new TextBox());
                Points_form.Add(new TextBox());
                Create_row(TEST, TEST._Keys[Key_number].Count - 1);
            }

            void button_remove_row_click(object sender, EventArgs e)
            {
                if (TEST._Keys[Key_number].Count <= 0)
                    return;
                Delete_last_row_on_panel();
                TEST._Keys[Key_number].RemoveAt(TEST._Keys[Key_number].Count - 1);

                Questions_form.RemoveAt(Questions_form.Count - 1);
                Answers_form.RemoveAt(Answers_form.Count - 1);
                Points_form.RemoveAt(Points_form.Count - 1);

                C_Row_label.Text = "Количество строк " + Convert.ToString(TEST._Keys[Key_number].Count);
            }

            void button_create_click(object sender, EventArgs e)
            {
                try
                {
                    int tmp = Convert.ToInt32(CoKey_textbox.Text);
                    if (tmp > 0)
                    {
                        if (tmp > TEST._Keys.Count)
                        {
                            for (int i = TEST._Keys.Count; i < tmp; i++)
                                TEST._Keys.Add(new Key());
                            Create_Key(TEST);
                        }
                        if (tmp < TEST._Keys.Count)
                        {
                            for (int i = TEST._Keys.Count - 1; i >= tmp; i--)
                                TEST._Keys.RemoveAt(i);
                            if (Key_number >= TEST._Keys.Count)
                                Key_number = TEST._Keys.Count - 1;
                            Create_Key(TEST);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка: некорректно задано количество ключей");
                }
            }

            void button_left_click(object sender, EventArgs e)
            {
                if (Key_number <= 0)
                    return;
                Key_number--;
                Clear_panel();
                Questions_form = new List<TextBox>();
                Answers_form = new List<TextBox>();
                Points_form = new List<TextBox>();
                Create_Key(TEST);
            }

            void button_right_click(object sender, EventArgs e)
            {
                try
                {
                    if (Questions_form.Count == 0)
                    {
                        MessageBox.Show("Ошибка: ключ должен иметь хотя бы одну строку");
                        return;
                    }
                    for (int i = 0; i < Questions_form.Count; i++)
                    {
                        if (Convert.ToInt32(Questions_form[i].Text.Trim()) <= 0 || Convert.ToInt32(Answers_form[i].Text.Trim()) <= 0 || Convert.ToSingle(Points_form[i].Text.Trim()) <= 0)
                        {
                            MessageBox.Show("Ошибка: значения в строках заданы неверно");
                            return;
                        }
                    }
                    for (int i = 0; i < Questions_form.Count; i++)
                    {
                        TEST._Keys[Key_number][i] = new Element(Convert.ToInt32(Questions_form[i].Text.Trim()),
                                                                Convert.ToInt32(Answers_form[i].Text.Trim()),
                                                                Convert.ToSingle(Points_form[i].Text.Trim()));
                    }
                    //check for the last question
                    if (Key_number >= TEST._Keys.Count - 1)
                    {
                        MessageBox.Show("Добавлен последний ключ");
                        return;
                    }
                    //update and add text box on the panel

                    Key_number++;
                    Clear_panel();
                    Create_Key(TEST);
                }
                catch
                {
                    MessageBox.Show("Ошибка: значения в строках заданы неверно GE");
                    return;
                }
            }

            void button_next_click(object sender, EventArgs e)
            {
                if (TEST._Keys.Count > 0 && TEST._Keys[TEST._Keys.Count - 1].Count > 0 && TEST._Keys[TEST._Keys.Count - 1][TEST._Keys[TEST._Keys.Count - 1].Count - 1].Point != 0)
                {
                    this.Close();
                    Form_Scales FS = new Form_Scales(TEST);
                }
                else
                    MessageBox.Show("Ошибка: не все ключи заданы");
            }

            void button_back_click(object sender, EventArgs e)
            {
                this.Close();
                Form_Questions FQ = new Form_Questions(TEST);
            }
        }
    }
}

