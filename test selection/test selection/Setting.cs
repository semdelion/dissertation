using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace ASCPR
{
    public static class Setting
    {
        private const string _tests = "_location_tests";
        private const string _database = "_database";
        private const string _design = "_design";
        private const string _characteristics = "_personal_characteristics";
        private const string _theme = "_theme";

        public static string tests_path = "";
        public static string database_path = "";
        public static string design_path = "";
        public static string characteristics_path = "";
        public static string theme = "";

        public static void Loading_settings()
        {
            StreamReader sr;
            using (sr = new StreamReader(@"Resources\\setting.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int i;
                    string key = "";
                    for (i = 0; i < line.Length && line[i] != ' '; i++) key += line[i];
                    switch (key)
                    {
                        case _tests:
                            {
                                key = Additional_functions.ClearLine(ref i, line);
                                tests_path = "..\\..\\" + key;
                                break;
                            }
                        case _database:
                            {
                                key = Additional_functions.ClearLine(ref i, line);
                                database_path = "..\\..\\" + key;
                                break;
                            }
                        case _design:
                            {
                                key = Additional_functions.ClearLine(ref i, line);
                                design_path = "..\\..\\" + key;
                                break;
                            }
                        case _characteristics:
                            {
                                key = Additional_functions.ClearLine(ref i, line);
                                characteristics_path = "..\\..\\" + key;
                                break;
                            }
                        case _theme:
                            {
                                key = Additional_functions.ClearLine(ref i, line);
                                theme = key;
                                break;
                            }
                        default: { break; }
                    }
            
                }
            }
        }
    }

    public static class Constants_for_the_compiler
    {
        public const string Begin_V = @"using System;
            namespace MyNamespace
            {
                public delegate bool V_of_C();
                public static class LambdaCreator 
                {
                    public static V_of_C Create()
                    {
                        return ()=>";
        public const string Begin_C = @"using System;
            namespace MyNamespace
            {
                public delegate double Calc();
                public static class LambdaCreator 
                {
                    public static Calc Create()
                    {
                        return ()=>";
        public const string End = @";
                    }
                }
            }";
    }
}
