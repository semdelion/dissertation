using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
namespace ASCPR
{
    static class Additional_functions
    {
        public delegate bool V_of_C();
        public delegate double Calc();

        public static object Verification_of_conditions(string begin, string program, string end)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters{ GenerateInMemory = true };
            parameters.ReferencedAssemblies.Add("System.dll");
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, begin + program + end);
            var cls = results.CompiledAssembly.GetType("MyNamespace.LambdaCreator");
            var method = cls.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
            var calc = (method.Invoke(null, null) as Delegate);
            return calc.DynamicInvoke();
        }

        public static string ClearLine(ref int i, string line, char l = '<', char r = '>', bool Trim = true) // выделение строки из текста, отчистка строки от  тегов < > и пробелов в начале и в конце 
        {
            for (; i < line.Length && line[i] != l; i++) ;
            i++;
            string Line = "";
            for (; i < line.Length && line[i] != r && line[i] != l; i++)
                Line += line[i];
            if (i == line.Length)
                Stored_Exceptions.Add(new Exception("Error: can not allocate descriptor"));
            return Trim ? Line.Trim() : Line;
        }

        public static string Trim(string str, ref int i, char l, char r)
        {
            for (; i < str.Length && str[i] != l; i++) ;
            string tmp = "";
            for (i++; i < str.Length && str[i] != r; i++)
                tmp += str[i];
            return tmp;
        }

        public static Line ToLine(string point_a, string point_b)
        {
            var a = point_a.Split(';');
            var b = point_b.Split(';');
            return new Line(Convert.ToSingle(a[0].Replace('.',',')), Convert.ToSingle(a[1].Replace('.', ',')), Convert.ToSingle(b[0].Replace('.', ',')), Convert.ToSingle(b[1].Replace('.', ',')));
        }

        public static string[] RemoveBetween(string s, char begin, char end)
        {
            Regex regex = new Regex(string.Format("\\{0}.*?\\{1}", begin, end));
            return regex.Split(s);
        }

        public static string Split_for_value(string input)
        {
            string pattern = "==?|!=?|<=?|>=";
            string[] t = Regex.Split(input, pattern);
            return t[0];
        }

        public static string Clean_for_compilation(string tmp)
        {
            int count_1 = 0;
            int count_2 = 0;
            for (int i = 0; i < tmp.Length; ++i)
                if (tmp[i] == '(')
                    count_1++;
            for (int i = 0; i < tmp.Length; ++i)
                if (tmp[i] == ')')
                    count_2++;
            if (count_1 == count_2)
                return tmp;
            else{
                for (int i = 0, j = 0; i < tmp.Length && j < count_1 - count_2; ++i)
                    if (tmp[i] == '('){ tmp = tmp.Remove(i, 1); ++j; --i; }
                return tmp;
            }
        }

        public static string Replace_Point(string expression, List<double> Key_value)
        {
            List<int> value = new List<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                string temp = ClearLine(ref i, expression, '{', '}');
                if (temp != "")
                    value.Add(Convert.ToInt32(temp));
            }

            string[] str = RemoveBetween(expression, '{', '}'); // replace {0} on the point of scale
            string tmp = ""; int j = 0;
            for (int i = 0; i < str.Length ; i++)
            {
                tmp += str[i] ;
                if (j < value.Count)
                    tmp += Convert.ToString(Key_value[value[j]]);
                j++;
            }
            return expression = tmp;
        }

        public static List<string> Get_filenames(string path)
        {
            System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(path);
            System.IO.DirectoryInfo[] dirs = info.GetDirectories();
            System.IO.FileInfo[] files = info.GetFiles();
            List<string> names = new List<string>();
            for (int i = 0; i < files.Length; i++)
                names.Add(files[i].Name.Remove(files[i].Name.Length - 4));
            return names;
        }

        public static int Number_of_Contains(List<Test> Tests, string name_test)
        {
            for (int i = 0; i < Tests.Count; i++)
                if (Tests[i]._Header.Name == name_test)
                    return i;
            return -1;
        }

        public static void Create_textbox(TextBox textbox, int width, int x, int y)
        {
            textbox.Width = width;
            textbox.Location = new Point(x, y);
            textbox.BackColor = System.Drawing.Color.WhiteSmoke;
            textbox.Font = Design.Font_text;
        }

        public static string Create_name_for_file(string name_file)
        {
            string next_number = "";
            int i = 0;
            while (System.IO.File.Exists($"{Setting.database_path}\\{(next_number == "" ? "" : $"{next_number} ")}{name_file}.txt"))
                next_number = Convert.ToString(++i);
            return $"{(next_number == "" ? "": $"{next_number} ")}{name_file}";
        }
    }
}
