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
namespace test_selection
{
    public partial class Form2 : Form
    {
        public Form2(string FileName)
        {
            void Form_FQ(Questions Q, ref Questions_Form FQ, int ind) // заполнение объектов.
            {
                FQ.Question = new Label{
                    Text = Convert.ToString(ind + 1) + ") " + Q.Question,
                    AutoSize = true,
                    MaximumSize = new Size(this.Width - 60, this.Height - 60),
                    Font = new Font("Arial", 12, FontStyle.Regular)
                };
                for (int i = 0; i < Q.Answer.Count; i++)
                {
                    FQ.Answer.Add(new CheckBox{
                        Text = Q.Answer[i],
                        MaximumSize = new Size(this.Width - 60, this.Height - 60),
                        AutoSize = true,
                        Font = new Font("Arial", 12, FontStyle.Regular)
                    });
                }
            }
            void Auto_Size(ref Label N, ref Label D, ref List<Questions_Form> LQ, ref Button BF) // функция вывода элементов на форму, в зависимости от размера формы
            {
                N.Location = new Point(60, 10);
                this.Controls.Add(N);
                int size = N.Location.Y + N.Height + 30,j;
                if (D.Text != ""){
                    D.Location = new Point(40, size);
                    this.Controls.Add(D);
                    size = D.Location.Y + D.Height + 30;
                }
                this.SuspendLayout(); //// !!! достаточно хорошо оптимизировала вывод
                for (int i = 0; i < LQ.Count; i++){
                    LQ[i].Question.Location = new Point(20, size);
                    this.Controls.Add(LQ[i].Question);
                    size = LQ[i].Question.Location.Y + LQ[i].Question.Height + 10;
                    for (j = 0; j < LQ[i].Answer.Count; j++){
                        LQ[i].Answer[j].Location = new Point(45, size);
                        this.Controls.Add(LQ[i].Answer[j]);
                        size = LQ[i].Answer[j].Location.Y + LQ[i].Answer[j].Height + 5;
                    }
                    size += 5;
                }
                this.ResumeLayout(false);//!!! достаточно хорошо оптимизировала вывод  
                BF.Location = new Point(this.Width - 100 - BF.Size.Width, size);
                this.Controls.Add(BF);
            }
            void Result_TEST(ref List<Questions_Form> T_F,ref List<List<int>> Res) // Формируем вектор ответов на тест.
            {
                for (int i = 0; i < T_F.Count; i++){
                    List<int> R = new List<int>();                    
                    for (int j = 0; j < T_F[i].Answer.Count; j++)
                        if (T_F[i].Answer[j].Checked)
                            R.Add(j);
                    Res.Add(R);
                }
            }
 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////           
            InitializeComponent();
            Test TEST = new Test();
            if (!TEST.Creat_test(FileName)) // заполняем класс тест
                this.Hide();
            else
                this.Show();
            Label TEST_NAME = new Label  // имя теста
            {
                Text = TEST.Name,
                MaximumSize = new Size(this.Width - 60, this.Height - 60),
                AutoSize = true,
                Font = new Font("Arial", 20, FontStyle.Bold)
            };
            Label TEST_DESCRIPTION = new Label // описание 
            {
                Text = TEST.Description,
                MaximumSize = new Size(this.Width - 60, this.Height - 60),
                AutoSize = true,
                Font = new Font("Arial", 14, FontStyle.Italic)
            };
            List<Questions_Form> TEST_FORM = new List<Questions_Form>(); // список вопросов 
            for (int i = 0; i < TEST.List_Question.Count; i++){
                Questions_Form temp = new Questions_Form();
                Form_FQ(TEST.List_Question[i], ref temp, i);
                TEST_FORM.Add(temp);
            }
            Button TEST_FINISH = new Button {Text = "Завершить тестирование", AutoSize = true };
            TEST_FINISH.Click += new System.EventHandler(TEST_FINISH_Click);

            Auto_Size(ref TEST_NAME, ref TEST_DESCRIPTION, ref TEST_FORM, ref TEST_FINISH);
            Button TEST_FINISH1 = new Button { Text = "Завершить тестирование", AutoSize = true };
 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    
            void TEST_FINISH_Click(object sender, EventArgs e)
            {
               
                List<List<int>> Result = new List<List<int>>();
                Result_TEST(ref TEST_FORM, ref Result);
                
                for (int i = 0; i < Result.Count; i++)
                {
                    if (Result[i].Count == 0)
                    { MessageBox.Show("Ошибка: вы не ответ на вопрос:  " + (i+1) ); return; }
                    //if (Result[i].Count == 1)
                    //{ MessageBox.Show("Ошибка: вы выбрали несколько вариантов ответа в вопросе:  " + (i + 1)); return; }
                }

                Form3 FormCreate = new Form3();
                FormCreate.ResultTest(TEST.Result,Result);
            }
        }
    }
}


