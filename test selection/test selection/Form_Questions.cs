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
    public partial class Form_Questions : Form
    {
        private int Question_number = 0;
        public List<TextBox> Answer_form = new List<TextBox>();

        private void Hide_O()
        {
            main_panel.Hide();
            button_left.Hide();
            button_right.Hide();
            Q_label.Hide();
        }

        private void Show_O()
        {
            main_panel.Show();
            button_left.Show();
            button_right.Show();
            Q_label.Show();
        }
        
        private void Design_for_Form_Questions()
        {
            BackgroundImage = Design.Background;

            Design.Design_for_button(button_create);
            Design.Design_for_button(button_back);
            Design.Design_for_button(button_next);
            Design.Design_for_button(button_left);
            Design.Design_for_button(button_right);

            button_add_answer.BackgroundImage = Design.Background_button_add;
            button_remove_answer.BackgroundImage = Design.Background_button_remove;

            Design.Design_for_label(CoQ_label);
            Design.Design_for_label(CA_label);
            Design.Design_for_label(Q_label);

            Design.Design_for_textbox(CoQ_textbox);

            
            Q_label.Font = new Font("Arial", 24F);
            CoQ_textbox.Location = new Point(CoQ_label.Location.X + 15 + CoQ_label.Width, CoQ_label.Location.Y);
            button_create.Width = CoQ_textbox.Location.X + CoQ_textbox.Width - CoQ_label.Location.X;
            Hide_O();
        }

        private new void Resize()
        {
            button_right.Location = new Point(Q_label.Location.X + 15 + Q_label.Width, button_right.Location.Y);
        }

        private void Add_answer_on_form(int height,TextBox answer )
        {
            Additional_functions.Create_textbox(answer, question_textBox.Width-95, 110, height);
            answer.Multiline = true;
            answer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            answer.Height = 50;
            answer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            main_panel.Controls.Add(answer);
        }

        private void Create_answer(Test TEST, int index = 0)
        {
            CA_label.Text = "Количество ответов " + Convert.ToString(TEST._Questions[Question_number]._Answer.Count);
            int height;

            if (index==0)
                height = question_textBox.Height + 15 + question_textBox.Location.Y;
            else if (index > TEST._Questions[Question_number]._Answer.Count - 1)
                return;
            else
                height = Answer_form[index-1].Location.Y + 15 + Answer_form[index-1].Height;
            for (int i = index; i < TEST._Questions[Question_number]._Answer.Count; i++)
            {
                Add_answer_on_form(height, Answer_form[i]);
                Answer_form[i].Text = TEST._Questions[Question_number]._Answer[i];
                height = Answer_form[i].Location.Y + 15 + Answer_form[i].Height;
            }
        }

        private void TextBox_KeyPress_integers(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (number == 8)
                e.Handled = false;
            else if (!Char.IsDigit(number))
                e.Handled = true;
        }

        private void Create_questions(Test TEST)
        {
            this.SuspendLayout();
            Q_label.Text = Convert.ToString(Question_number + 1) + " / " + Convert.ToString(TEST._Questions.Count);
            question_textBox.Text = TEST._Questions[Question_number]._Question;
            Clear_panel();
            Answer_form = new List<TextBox>();
            for (int i = 0; i < TEST._Questions[Question_number]._Answer.Count; i++)
                Answer_form.Add(new TextBox());
            Create_answer(TEST);
            Resize();
            Show_O();
            this.ResumeLayout(false);
        }

        private void Clear_panel()
        {
            for(int i = Answer_form.Count-1;i>=0;i--)
                main_panel.Controls.Remove(Answer_form[i]);
        }

        private void Delete_last_answer_on_panel()
        {
                main_panel.Controls.Remove(Answer_form[Answer_form.Count-1]);
        }

        internal Form_Questions(Test TEST)
        {
            InitializeComponent();
            Design_for_Form_Questions();
            Show();
            CoQ_textbox.Text = Convert.ToString(TEST._Questions.Count);
            CoQ_textbox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress_integers);
            button_add_answer.Click += new EventHandler(button_add_answer_click);
            button_remove_answer.Click += new EventHandler(button_remove_answer_click);
            button_left.Click += new EventHandler(button_left_click);
            button_right.Click += new EventHandler(button_right_click);
            button_create.Click += new EventHandler(button_create_click);
            button_next.Click += new EventHandler(button_next_click);
            button_back.Click += new EventHandler(button_back_click);

            if (TEST._Questions.Count > 0)
                Create_questions(TEST);

            void button_create_click(object sender, EventArgs e)
            {
                try
                {
                    int tmp = Convert.ToInt32(CoQ_textbox.Text);
                    if (tmp > 0)
                    {
                        if (tmp > TEST._Questions.Count)
                        {
                            for (int i = TEST._Questions.Count; i < tmp; i++)
                                TEST._Questions.Add(new Question());
                            Create_questions(TEST);
                        }
                        if (tmp < TEST._Questions.Count)
                        {
                            for (int i = TEST._Questions.Count - 1; i >= tmp; i--)
                                TEST._Questions.RemoveAt(i);
                            if (Question_number >= TEST._Questions.Count)
                                Question_number = TEST._Questions.Count - 1;
                            Create_questions(TEST);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка: некорректно задано число вопросов. OS");
                }
            }

            void button_add_answer_click(object sender, EventArgs e)
            {
                TEST._Questions[Question_number]._Answer.Add("");
                Answer_form.Add(new TextBox());
                Create_answer(TEST, TEST._Questions[Question_number]._Answer.Count-1);
            }

            void button_remove_answer_click(object sender, EventArgs e)
            {
                if (TEST._Questions[Question_number]._Answer.Count <= 0)
                    return;
                Delete_last_answer_on_panel();
                TEST._Questions[Question_number]._Answer.RemoveAt(TEST._Questions[Question_number]._Answer.Count-1);
                Answer_form.RemoveAt(Answer_form.Count-1);
                CA_label.Text = "Количество ответов " + Convert.ToString(TEST._Questions[Question_number]._Answer.Count);
            }

            void button_left_click(object sender, EventArgs e)
            {
                //check for the last question 
                if (Question_number <= 0)
                    return;
                //go to the previous question
                Question_number--;
                Clear_panel();
                Answer_form = new List<TextBox>();
                Create_questions(TEST);
            }

            void button_right_click(object sender, EventArgs e)
            {
                //check for the correctness of the question and answers
                if (question_textBox.Text.Trim() == "" || question_textBox.Text.Contains('>') || question_textBox.Text.Contains('<'))
                {
                    MessageBox.Show("Ошибка: вопрос пуст или содержит символы '<', '>'");
                    return;
                }
                if (Answer_form.Count == 0)
                {
                    MessageBox.Show("Ошибка: вопрос должен иметь хотя бы один ответ");
                    return;
                }
                for (int i = 0; i < Answer_form.Count; i++)
                    if (Answer_form[i].Text.Trim() == "" || Answer_form[i].Text.Contains('>') || Answer_form[i].Text.Contains('<'))
                    {
                        MessageBox.Show("Ошибка: ответы пусты или содержат символы '<', '>'");
                        return;
                    }

                TEST._Questions[Question_number]._Question = question_textBox.Text.Trim();
                for (int i = 0; i < Answer_form.Count; i++)
                    TEST._Questions[Question_number]._Answer[i] = Answer_form[i].Text.Trim();

                //check for the last question
                if (Question_number >= TEST._Questions.Count - 1)
                {
                    MessageBox.Show("Добавлен последний вопрос");
                    return;
                }
                //update and add text box on the panel

                Question_number++;
                Clear_panel();
                Create_questions(TEST);
            }

            void button_next_click(object sender, EventArgs e)
            {
                if (TEST._Questions.Count > 0 && TEST._Questions[TEST._Questions.Count - 1]._Answer.Count > 0 && TEST._Questions[TEST._Questions.Count - 1]._Answer[TEST._Questions[TEST._Questions.Count - 1]._Answer.Count - 1] != "")
                {
                    this.Close();
                    Form_Keys FK = new Form_Keys(TEST);
                }
                else
                {
                    MessageBox.Show("Ошибка: не все вопросы заданы");
                }
                
            }

            void button_back_click(object sender, EventArgs e)
            {
                this.Close();
                Form_header FH = new Form_header(TEST);
            }
        }
    }
}
