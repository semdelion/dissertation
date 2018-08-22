using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
namespace ASCPR
{
    public partial class Form2 : Form
    {
        class Questions_Form // класс объектов теста.
        {
            public Label Question;
            public List<CheckBox> Answer;

            public Questions_Form()
            {
                Question = new Label();
                Answer = new List<CheckBox>();
            }
            public Questions_Form(Questions_Form q)
            {
                Question = q.Question;
                Answer = new List<CheckBox>();
                foreach (var i in q.Answer)
                    Answer.Add(i);
            }
        }

        void Form_FQ(Question Q, Questions_Form FQ, int ind) // заполнение объектов.
        {
            FQ.Question = new Label
            {
                BackColor = System.Drawing.Color.Transparent,
                ForeColor = Design.Font_color,
                Font = Design.Font_heading,
                Text = Convert.ToString(ind + 1) + ") " + Q._Question,
                AutoSize = true,
                MaximumSize = new Size(this.Width - 60, this.Height - 60)
            };

            for (int i = 0; i < Q._Answer.Count; i++)
            {
                FQ.Answer.Add(new CheckBox
                {
                    Text = Q._Answer[i],
                    Appearance = Appearance.Button,
                    
                    AutoSize = true,
                    BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch,
                    BackColor = System.Drawing.Color.Transparent,
                    FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                    ForeColor = Design.Font_color,
                    Font = Design.Font_text,
                    MaximumSize = new Size(this.Width - 60, this.Height - 60),
                    MinimumSize = new Size(100, 20),

                });
                FQ.Answer[FQ.Answer.Count-1].FlatAppearance.BorderSize=0;
                FQ.Answer[FQ.Answer.Count - 1].FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 1, 253, 179);
                FQ.Answer[FQ.Answer.Count - 1].FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(200, 1, 253, 179);
                FQ.Answer[FQ.Answer.Count - 1].FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(100, 1, 253, 179); 
            }
        }

        void Auto_Size(Label N, Label D, List<Questions_Form> LQ, Button BF) // функция вывода элементов на форму, в зависимости от размера формы
        {
            N.Location = new Point(60, 10);
            this.Controls.Add(N);
            int size = N.Location.Y + N.Height + 30, j;
            if (D.Text != "")
            {
                D.Location = new Point(40, size);
                this.Controls.Add(D);
                size = D.Location.Y + D.Height + 30;
            }
            this.SuspendLayout(); //// !!! достаточно хорошо оптимизировала вывод !!!
            for (int i = 0; i < LQ.Count; i++)
            {
                LQ[i].Question.Location = new Point(20, size);
                this.Controls.Add(LQ[i].Question);
                size = LQ[i].Question.Location.Y + LQ[i].Question.Height + 10;
                for (j = 0; j < LQ[i].Answer.Count; j++)
                {
                    LQ[i].Answer[j].Location = new Point(45, size);
                    this.Controls.Add(LQ[i].Answer[j]);
                    size = LQ[i].Answer[j].Location.Y + LQ[i].Answer[j].Height + 5;
                }
                size += 5;
            }
            this.ResumeLayout(false);//!!! достаточно хорошо оптимизировала вывод  
            BF.Location = new Point(50, size);
            this.Controls.Add(BF);
        }

        void Create_Answer_list(List<Questions_Form> T_F, Answers_to_Test answers_to_the_test) // Формируем вектор ответов на тест.
        {
            for (int i = 0; i < T_F.Count; i++)
            {
                Answers_to_question A = new Answers_to_question();
                for (int j = 0; j < T_F[i].Answer.Count; j++)
                    if (T_F[i].Answer[j].Checked)
                        A.Add(j);
                answers_to_the_test.Add(A);
            }
        }

        void ShowTest(List<string> Tests, int Test_number,string FileName)
        {
            Test TEST = new Test();
            if (!TEST.Creat_test(Tests[Test_number]))
            {
                MessageBox.Show("Ошибка: Файл - \"" + Tests[Test_number] + "\" содержит ошибку.");
                this.Close();
                throw new Exception("Ошибка: Файл - \"" + Tests[Test_number] + "\" содержит ошибку.");
            }
            TESTS.Add(TEST);// add test in list
            this.Text = TEST._Header.Name;
            LABEL_TEST_NAME.Text = TEST._Header.Name; // test name
            LABEL_TEST_DESCRIPTION.Text = TEST._Header.Description; // test description
            List<Questions_Form> LIST_OF_LABELS_TEST_QUESTIONS = new List<Questions_Form>(); // список вопросов 
            for (int i = 0; i < TEST._Questions.Count; i++)
            {
                Questions_Form temp = new Questions_Form();
                Form_FQ(TEST._Questions[i], temp, i);
                LIST_OF_LABELS_TEST_QUESTIONS.Add(temp);
            }
            Button BUTTON_TEST_FINISH = new Button
            {
                Size = new System.Drawing.Size(200, 45),
                Text = "Завершить тестирование",
                UseVisualStyleBackColor = true
            };

            Design.Design_for_button(BUTTON_TEST_FINISH);
            
            BUTTON_TEST_FINISH.Click += new System.EventHandler(BUTTON_TEST_FINISH_Click);

            Auto_Size(LABEL_TEST_NAME, LABEL_TEST_DESCRIPTION, LIST_OF_LABELS_TEST_QUESTIONS, BUTTON_TEST_FINISH);

            void BUTTON_TEST_FINISH_Click(object sender, EventArgs e) // Кновка закончить тест.
            {
                Answers_to_Test answers_to_the_Test = new Answers_to_Test();
                Create_Answer_list(LIST_OF_LABELS_TEST_QUESTIONS, answers_to_the_Test);//формируем список вопросов и ответов на эти вопросы. 

                if (TEST._Header.Verifier == Descriptor_name._ONLY_ONE)
                    for (int i = 0; i < answers_to_the_Test.Count; i++)
                        if (answers_to_the_Test[i].Count != 1)
                        {
                            string Err = "Ошибка: на вопрос: ";
                            for (; i < answers_to_the_Test.Count; i++)       
                                if (answers_to_the_Test[i].Count != 1)
                                    Err += " " + Convert.ToString(i + 1);
                            MessageBox.Show(Err + " должен быть один.");
                            return;
                        }

                if (TEST._Header.Verifier == Descriptor_name._AT_LEAST_ONE)
                    for (int i = 0; i < answers_to_the_Test.Count; i++)
                        if (answers_to_the_Test[i].Count == 0)
                        {
                            string Err = "Ошибка: вы не ответили на вопрос: ";
                            for (; i < answers_to_the_Test.Count; i++)
                                if (answers_to_the_Test[i].Count == 0)
                                    Err += " " + Convert.ToString(i + 1);
                            MessageBox.Show(Err);
                            return;
                        }

                Answer_to_all_tests.Add(answers_to_the_Test);
                if (Test_number < Tests.Count - 1)
                {
                    this.Controls.Clear();
                    ShowTest(Tests, Test_number + 1, FileName);
                }
                else
                {
                    Test_parser.Create_an_automatic_resume(TESTS, Answer_to_all_tests, FileName);
                    this.Close();
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  
        List<Test> TESTS = new List<Test>(); // all tests
        List<Answers_to_Test> Answer_to_all_tests = new List<Answers_to_Test>(); // all answers to all questions of all tests

        public Form2(List<string> Tests, string FileName)
        {
            this.Show();
            InitializeComponent();
            this.BackgroundImage = Design.Background;
            Design.Design_for_label(LABEL_TEST_NAME);
            Design.Design_for_label(LABEL_TEST_DESCRIPTION);
            ShowTest(Tests, 0 , FileName);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    
    }
}


