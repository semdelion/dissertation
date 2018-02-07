using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace test_selection
{
    
    class Win32
    {
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();
    }
    class Questions 
    {
        public string Question { get; set; }
        public List<string> Answer { get; set; }

        public Questions()
        {
            Question = "";
            Answer = new List<string>();
        }
        public Questions(Questions q)
        {
            Question = q.Question;
            Answer = new List<string>();
            foreach (var i in q.Answer)
                Answer.Add(i);
        }
        
    }
    class Test // собственно сам тест для заплнения объектов на форме 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }
        public List<Questions> List_Question;
        public void Add(Questions q) { List_Question.Add(q); }
        public Test(){
            Name = "";
            Description = "";
            Result = "";
            List_Question = new List<Questions>();
        }
        public Test(Test T){
            Name = T.Name;
            Description = T.Description;
            Result = T.Result;
            List_Question = new List<Questions>();
            foreach (var i in T.List_Question)
                List_Question.Add(i);
        }

        string ClearLine(ref int i, ref string line) // выделение строки из текста, отчистка строки от  тегов < > и пробелов в начале и в конце 
        {
            for (; i < line.Length && line[i] != '<'; i++) ;
            i++;
            string Line = "";
            for (; i < line.Length && line[i] != '>'; i++)
                Line += line[i];
            return Line.Trim();
            //for (; i < line.Length && line[i] != '<'; i++) ;
            //i++;
            //int j = i;
            //string Line = "";
            //for (; i < line.Length && line[i] != '>'; i++) ;
            //    Line = line.Substring(j,i-j-1);
            //return Line.Trim();
        }
        public bool Creat_test(string FileName) // создание теста
        {
            try
            {
                using (StreamReader sr = new StreamReader(Setting.location_tests + "\\" + FileName, Encoding.Default))
                {
                    // Read the stream to a string, and write the string to the console.
                    string line = sr.ReadToEnd();
                    string keyword;

                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == '_') // выделение ключевого слова 
                        {
                            keyword = "";
                            for (; i < line.Length && line[i] != ' '; i++)
                                keyword += line[i];

                            switch (keyword) // заполнение класса Test
                            {
                                case Key_Words._ANSWER:
                                    {
                                        this.List_Question[List_Question.Count - 1].Answer.Add(ClearLine(ref i, ref line));
                                        break;
                                    }
                                case Key_Words._QUESTION:
                                    {
                                        this.List_Question.Add(new Questions());
                                        this.List_Question[List_Question.Count - 1].Question = ClearLine(ref i, ref line);
                                        break;
                                    }
                                case Key_Words._NAME:
                                    {
                                        this.Name = ClearLine(ref i, ref line);
                                        break;
                                    }
                                case Key_Words._DESCRIPTION:
                                    {
                                        this.Description = ClearLine(ref i, ref line);
                                        break;
                                    }

                                case Key_Words._RESULT:
                                    {
                                        this.Result = line.Substring(i);
                                        //return false;
                                        return true;
                                    }

                                default:
                                    break;
                            }

                        }
                    }
                }
                return true;
            }
            catch
            {
                MessageBox.Show("The file could not be read:");
                return false;
            }
        }
        //public bool Creat_test(string FileName) // создание теста
        //{
        //    try
        //    {
        //        using (StreamReader sr = new StreamReader(Setting.location_tests + "\\" + FileName, Encoding.Default))
        //        {
        //            string keyword = (sr.ReadLine()).Trim();
        //            while (keyword != null)
        //            {

        //                switch (keyword) // заполнение класса Test
        //                {
        //                    case Key_Words._ANSWER:
        //                        {
        //                            this.List_Question[List_Question.Count - 1].Answer.Add((sr.ReadLine()).Trim());
        //                            break;
        //                        }
        //                    case Key_Words._QUESTION:
        //                        {
        //                            this.List_Question.Add(new Questions());
        //                            this.List_Question[List_Question.Count - 1].Question = (sr.ReadLine()).Trim();
        //                            break;
        //                        }
        //                    case Key_Words._NAME:
        //                        {
        //                            this.Name = (sr.ReadLine()).Trim();
        //                            break;
        //                        }
        //                    case Key_Words._DESCRIPTION:
        //                        {
        //                            this.Description = (sr.ReadLine()).Trim();
        //                            break;
        //                        }

        //                    case Key_Words._RESULT:
        //                        {
        //                            this.Result = sr.ReadLine();
        //                            //return false;
        //                            return true;
        //                        }

        //                    default:
        //                        break;
        //                }

        //                keyword = (sr.ReadLine()).Trim();
        //            }

        //        }
        //        return true;
        //    }
        //    catch
        //    {
        //        MessageBox.Show("The file could not be read:");
        //        return false;
        //    }
        //}
    }

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
}
