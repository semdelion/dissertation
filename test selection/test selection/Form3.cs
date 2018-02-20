using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_selection
{
    
    public partial class Form3 : Form
    {
        string Trim(string str, ref int i, char l, char r){
            for (; i < str.Length && str[i] != l; i++) ;
            string t = "";
            for (i++; i < str.Length && str[i] != r; i++)
                t += str[i];
            return t;
        }

        void _SUMR(List<int> RES, ref string TEST,string IF, ref Label RESULTLABEL)
        {
            string keyword = "";
            int k = 0, i = 0;
            k = Convert.ToInt32(Trim(IF, ref i, '[', ']'));
            for (i++ ; i < IF.Length ; i++){
                switch (keyword){
                    case "=>":{
                            keyword = Trim(IF, ref i, '(', ')');
                            string l = "", r = "";
                            bool flag = false;
                            for ( int j=0; j < keyword.Length; j++)
                            {
                                if (keyword[j] == ';')
                                {
                                    j++;
                                    flag = true;
                                }
                                if (!flag)
                                    l += keyword[j];
                                else
                                    r += keyword[j];
                            }
                            if (Convert.ToInt32(l) <= RES[k] && RES[k] <= Convert.ToInt32(r))
                            {
                                RESULTLABEL.Location = new Point(40, FormSize.Form3Y+20);
                                RESULTLABEL.Text +="\n" +"( Баллов - "+RES[k]+ " ) - "+TEST;
                                this.Controls.Add(RESULTLABEL);
                                return; 
                            }
                            else
                                return;
                        }
                    default:
                        keyword +=IF[i];
                        break;
                }
                
            }
        }
        int _SUM(ref string sum, ref List<List<int>> Result)
        {
            string NewElem = "";
            List<string> resString = new List<string>();
            List<int> resInt = new List<int>();
            List<char> sign = new List<char>();
           
            for (int i = 0; i < sum.Length; i++)
                switch (sum[i]) // разбиваем строку на элементы и знаки
                {
                    case '+': { resString.Add(NewElem); sign.Add(sum[i]); NewElem = ""; break; }   
                    case '*': { resString.Add(NewElem); sign.Add(sum[i]); NewElem = ""; break; }
                    case '/': { resString.Add(NewElem); sign.Add(sum[i]); NewElem = ""; break; }
                    default:  { NewElem += sum[i]; break; }
                }
            resString.Add(NewElem);
            int q = 0;
            int t = 0;
            int k;
            for (int i = 0, j = 0; i < resString.Count; i++, j = 0) // записываем ответы и баллы за данные ответы // TESTING  //// КОРОРОЧОЕ ВЫ В ВЫТАПФ ЫАРПДЛО РДАФЫ РЛОАОР ЫВЛОДА ПЫРАООЛ ТУТ ПИЗДЕЦ
            {
                q = Convert.ToInt32(Trim(resString[i], ref j, '[', ']')) - 1;//номер вопроса 
                t = Convert.ToInt32(Trim(resString[i], ref j, '(', ')')) - 1;//вариант ответа
                for (k = 0; k < Result[q].Count && Result[q][k] != t; k++);
                    if (k < Result[q].Count) //  [i](j) где i - вопрос а j = ответ  // добавить цикл
                        resInt.Add(Convert.ToInt32(resString[i].Substring(j + 2, resString[i].Length - j - 2))); //  пропускаем '=' полуаем количество баллов за ответ 
                    else
                        resInt.Add(0);
            }

            if ((sign.Count + 1) == resInt.Count)
            {
                int i = 0;
                for (int j = 0; j < sign.Count; j++)
                    switch (sign[j]) // разбиваем строку на элементы и знаки
                    {
                        case '+': { resInt[0] += resInt[++i]; break; }
                        case '*': { resInt[0] *= resInt[++i]; break; }
                        case '/': { resInt[0] /= resInt[++i]; break; }
                    }
            }
            else
                throw new Exception("Ошибка: не верно составлены списки RESsign  и ResInt");


            return resInt[0];
            
        }
        public Form3()
        {
            InitializeComponent();
            FormSize.Form3Y = 0;
        }
        public void ResultTest(string TESTResult, List<List<int>> Result,string NAMETEST)
        {
            FormSize.Form3Y = 0;
            this.Show();
            ResultParser RES = new ResultParser();
            string keyword;

            Label TEST_NAME = new Label  // имя теста
            {
                Text = NAMETEST,
                MaximumSize = new Size(this.Width - 60, this.Height - 60),
                AutoSize = true,
                Font = new Font("Arial", 20, FontStyle.Bold),
                Location = new Point(60, 10)
            };
            this.Controls.Add(TEST_NAME);
            FormSize.Form3Y = TEST_NAME.Height+TEST_NAME.Location.Y;
            Label RESULTLABEL = new Label
            {
                Text = "",
                AutoSize = true,
                MaximumSize = new Size(this.Width - 60, this.Height - 60),
                Font = new Font("Arial", 11, FontStyle.Regular)
            };
            

            for (int i = 0; i < TESTResult.Length; i++)
            {
                if (TESTResult[i] == '_') // выделение ключевого слова 
                {
                    keyword = "";
                    for (; i < TESTResult.Length && TESTResult[i] != ' '; i++)
                        keyword += TESTResult[i];

                    switch (keyword) // заполнение класса Test
                    {
                        case Key_Words._HELP:
                            {
                                FormSize._HELP = Test.ClearLine(ref i, ref TESTResult);
                                break;
                            }
                        case Key_Words._SUM:
                            {
                                for (; i < TESTResult.Length && TESTResult[i] != ']'; i++);
                                string temp = Test.ClearLine(ref i, ref TESTResult);
                                temp = temp.Replace('\n',' ').Replace('\r', ' ').Replace(" ", "");
                                string t = temp;
                                RES._SUM.Add(_SUM(ref  temp,ref  Result));
                                break;
                            }
                        case Key_Words._SUMR:
                            {
                                string IF = "";
                                for (; i < TESTResult.Length && TESTResult[i] != '<';i++)
                                    IF += TESTResult[i];
                                IF = IF.Trim();
                                string sumr = Test.ClearLine(ref i, ref TESTResult);
                                _SUMR( RES._SUM, ref sumr,IF, ref RESULTLABEL);
                                break;
                            }
                        default:
                            break;
                        }
                }
            }
            FormSize.Form3Y = RESULTLABEL.Height + RESULTLABEL.Location.Y;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Label HELPLABEL = new Label
            {
                Text = FormSize._HELP,
                AutoSize = true,
                MaximumSize = new Size(this.Width - 60, this.Height - 60),
                Font = new Font("Arial", 11, FontStyle.Italic),
                Location = new Point(60, FormSize.Form3Y  + 30)
            };

            this.Controls.Add(HELPLABEL);
            FormSize.Form3Y = HELPLABEL.Height + HELPLABEL.Location.Y;
        }
    }
}
