using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASCPR
{
    public partial class Test_selection : Form
    {
        private List<string> NameTest = new List<string>();

        void Button_add_test_Click(object sender, EventArgs e){//добавление нового теста в список.
            if ((sender as Button).BackgroundImage == Design.Background_button_true){
                (sender as Button).BackgroundImage = Design.Background_button;
                string temp = (sender as Button).Text + ".txt";
                for (int i = 0; i < NameTest.Count; i++)
                    if (temp == NameTest[i]){
                        NameTest.Remove(NameTest[i]);
                        return;
                    }
            }
            else{
                (sender as Button).BackgroundImage =  Design.Background_button_true;
                NameTest.Add((sender as Button).Text + ".txt");
            }
        }

        void StatTest_Click(object sender, EventArgs e)// создание файла и начала тестирования 
        {
            if (NameTest.Count == 0)
            {
                MessageBox.Show("Ошибка: вы не выбрали тест");
                return;
            }
            string fileName = "", FIO,BD,TD;//Создаём имя файла, ФИО-ДР-ДАТА
            FIO =  (textBox1.Text != "" ? textBox1.Text + " " : "") + (textBox2.Text != "" ? textBox2.Text + " " : "") + (textBox3.Text != "" ? textBox3.Text + " " : "");
            BD  =  (textBox4.Text != "" ? textBox4.Text + "." : "") + (textBox5.Text != "" ? textBox5.Text + "." : "") + textBox6.Text;
            TD = (DateTime.Today.ToString("d")).Replace('/', '.');
            fileName =  (FIO != "" ? FIO + " " : "") + (BD != "" ? BD + " " : "") + TD;
            fileName = Additional_functions.Create_name_for_file(fileName);
            StreamWriter sr;
            sr = new StreamWriter(fileName = Setting.database_path + "\\" + fileName + ".txt");
            sr.WriteLine(Descriptor_name._HEADER + " <");
            sr.WriteLine("Имя: " + FIO);
            sr.WriteLine("Дата рождения: " + BD);
            sr.WriteLine("Дата тестирования: " + TD);
            sr.WriteLine("Тесты: ");
            for (int i = 0; i < NameTest.Count; i++)
                sr.WriteLine(i+1 + ") " + NameTest[i]);
            sr.WriteLine(">");
            Form2 FormCreate = new Form2(NameTest, fileName);
            sr.Close();
            this.Close();
        }

        public Test_selection()
        {
            InitializeComponent();

            const int Width_Button = 550, Height_Button = 45;
            BackgroundImage = Design.Background;
            Design.Design_for_label(label_SName);
            Design.Design_for_label(label_Name);
            Design.Design_for_label(label_PName);
            Design.Design_for_label(label_day);
            Design.Design_for_label(label_month);
            Design.Design_for_label(label_year);
            
            this.SuspendLayout(); //Временно приостанавливает логику компоновки для элемента управления.
            List<string> test_names = new List<string>(Additional_functions.Get_filenames(Setting.tests_path));
            Button[] Test_add_button = new Button[test_names.Count];
            Test_add_button[0] = new Button
            {
                Text = test_names[0],
                Width = Width_Button,
                Height = Height_Button,
                BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch,
                Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(50, textBox4.Location.Y+textBox4.Height+45)
            };
            Design.Design_for_button(Test_add_button[0]);
            Test_add_button[0].Click += new EventHandler(Button_add_test_Click);    
            this.Controls.Add(Test_add_button[0]);
            for (int i = 1; i < test_names.Count; i++)
            {
                Test_add_button[i] = new Button
                {   Width = Width_Button, Height = Height_Button, Text = test_names[i],
                    BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch,
                    Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)))
                };
                Test_add_button[i].Location = new Point(50, Test_add_button[i - 1].Location.Y + Test_add_button[i - 1].Height + 5);
                this.Controls.Add(Test_add_button[i]);
                Test_add_button[i].Click += new EventHandler(Button_add_test_Click);
                Design.Design_for_button(Test_add_button[i]);
            }
            Button StatTest = new Button{ Width = Width_Button - 100, Height = Height_Button, Text = "Начать тестирование"};
            StatTest.Click += new EventHandler(StatTest_Click);
            Design.Design_for_button(StatTest);
            StatTest.Location = new Point(150, Test_add_button[Test_add_button.Length - 1].Location.Y + Test_add_button[Test_add_button.Length - 1].Height + 35);
            this.Controls.Add(StatTest);
            
            this.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.ResumeLayout(false);//
            this.Show();
        }
    }
}
