using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ASCPR
{
    static class Test_parser 
    {
        static List<Dictionary<string, double>> Dictionary_of_scales;

        static string Save_Groups(Personal_characteristic Personal_characteristics)
        {
            string Characteristics = "";
            for (int i = 0; i < Personal_characteristics.Groups.Count; i++)
            {
                string Manifestation = "";
                double sum = 0;
                for (int j = 0; j < Personal_characteristics.Groups[i].Links.Count; j++)
                    sum += Personal_characteristics.Groups[i].Links[j].Measure_of_expression;
                if (Personal_characteristics.Groups[i].Links.Count >= 0)
                {
                    sum = sum / Personal_characteristics.Groups[i].Links.Count;
                    if (Level_of_expression.Return_text_about_of_expression(sum, out Manifestation))
                        Manifestation = $"{Personal_characteristics.Name} - Группа {(i+1)}\r\n{Manifestation}\r\n{Personal_characteristics.Groups[i].Manifestation}\r\n";
                }
                Characteristics += Manifestation;
            }
            return Characteristics;
        }

        static string Save_All_Groups(Personal_characteristic Personal_characteristics)
        {
            string Characteristics = "";
            for (int i = 0; i < Personal_characteristics.Groups.Count; i++)
            {
                string Manifestation = "";
                for (int j = 0; j < Personal_characteristics.Groups[i].Links.Count; j++)
                {
                    Manifestation += $"Группа {(i + 1)} {Personal_characteristics.Name} - мера принадлежности " +
                        $"{Convert.ToString(Personal_characteristics.Groups[i].Links[j].Measure_of_expression)}; \r\n";
                    for (int k = 0; k < Personal_characteristics.Groups[i].Links[j].Test_name.Count; k++)
                        Manifestation += $"{Personal_characteristics.Groups[i].Links[j].Test_name[k]} --- {Personal_characteristics.Groups[i].Links[j].Scale_name[k]}; \r\n";
                    Manifestation += $"{Personal_characteristics.Groups[i].Manifestation} \r\n\r\n";
                }
                Characteristics += $"{Manifestation} \n\r";
            }
            return Characteristics;
        }

        static void Save_automatic_resume(List<Test> TESTS, List<Answers_to_Test> Answers_to_all_tests, List<List<string>> Manifestations_all, List<Personal_characteristic> Personal_characteristics, string FileName)
        {
            StreamWriter sw = File.AppendText(FileName);

            sw.WriteLine($"\r\n{Descriptors._TEST_RESULT} <"); 
            for (int i = 0; i < TESTS.Count; i++)
            {
                sw.WriteLine(TESTS[i]._Header.Name);
                for (int j = 0; j < Manifestations_all[i].Count; j++)
                    sw.WriteLine(Manifestations_all[i][j]);
            }
            sw.WriteLine(" >\r\n");

            sw.WriteLine($"\r\n{Descriptors._AUTOMATIC_RESUME} <");
            for (int i = 0; i < Personal_characteristics.Count; i++)
            {
                string tmp = Save_Groups(Personal_characteristics[i]);
                if (tmp != "")
                   sw.WriteLine(tmp);
            }
            sw.WriteLine(" >\r\n");

            sw.WriteLine($"\r\n{Descriptors._LEVELS_OF_EXPRESSION} <");
            for (int i = 0; i < Personal_characteristics.Count; i++)
            {
                string tmp = Save_All_Groups(Personal_characteristics[i]);
                if (tmp != "")
                    sw.WriteLine(tmp);
            }
            sw.WriteLine(" >\r\n");

            sw.WriteLine($"\r\n{Descriptors._TEST_SCALES} <");
            for (int i = 0; i < Dictionary_of_scales.Count; i++)
            {
                sw.WriteLine(TESTS[i]._Header.Name);
                foreach (var j in Dictionary_of_scales[i])
                    sw.WriteLine("(" + j.Key + " ) " + "Баллов - " + j.Value);
            }
            sw.WriteLine(" >\r\n");

            sw.WriteLine($"\r\n{Descriptors._ANSWERS_TO_TESTS} <");
            for (int i = 0; i < TESTS.Count; i++)
            {
                sw.WriteLine(TESTS[i]._Header.Name);
                for (int j = 0; j < Answers_to_all_tests[i].Count; j++)
                {
                    sw.WriteLine($"{(j + 1)}) {TESTS[i]._Questions[j]._Question}");
                    for (int k = 0; k < Answers_to_all_tests[i][j].Count; k++)
                        sw.WriteLine($"    {(Answers_to_all_tests[i][j][k] + 1)}) {TESTS[i]._Questions[j]._Answer[Answers_to_all_tests[i][j][k]]}");
                }
            }
            sw.WriteLine(" >\r\n");
            sw.Close();
        }

        static List<string> Test_parser_level_1_and_2(List<Scale> _Scales, List<double> Key_value, ref Dictionary<string, double> newscale)
        {
            List<string> Manifestations = new List<string>();
            for (int scale_number = 0; scale_number < _Scales.Count; ++scale_number ) 
            {
                string tmp = Descriptors_implementation._SCALE_counting(_Scales[scale_number], Key_value , newscale);
                if (tmp != null)
                    Manifestations.Add(tmp);
            }
            return Manifestations;
        }

        static Personal_characteristic Test_parser_level_3(ref List<Test> TESTS, string name_charact, List<Dictionary<string, double>> Dictionary_of_scales)
        {
            Personal_characteristic characteristic = new Personal_characteristic();
            characteristic.Creat_Personal_characteristic(name_charact);
            characteristic.Name = name_charact;

            List<string> completed_tests = new List<string>();
            for (int i = 0; i < TESTS.Count; i++)
                completed_tests.Add(TESTS[i]._Header.Name);

            characteristic.Remove_links_to_missing_tests(completed_tests);
            characteristic.Calculation_measure_of_expression(Dictionary_of_scales, TESTS);
            return characteristic;
        }

        public static void Create_an_automatic_resume(List<Test> TESTS, List<Answers_to_Test> Answers_to_all_tests, string FileName)
        {
            List<List<double>> Keys_value_all = new List<List<double>>(); // all points on the scales
            for (int test_number = 0; test_number < TESTS.Count; ++test_number)
                Keys_value_all.Add( Descriptors_implementation._SUM_counting(TESTS[test_number]._Keys, Answers_to_all_tests[test_number]));

            Dictionary_of_scales = new List<Dictionary<string, double>>();
            List<List<string>> Manifestations_all = new List<List<string>>(); // all Manifestations on the first and second level
            for (int test_number = 0; test_number < TESTS.Count; ++test_number)
            {
                Dictionary<string, double> newscale = new Dictionary<string, double>();
                Manifestations_all.Add(Test_parser_level_1_and_2(TESTS[test_number]._Scales, Keys_value_all[test_number], ref newscale));
                Dictionary_of_scales.Add(newscale);
            }

            List<string> characteristics = new List<string>(Additional_functions.Get_filenames(Setting.characteristics_path));
            List<Personal_characteristic> Personal_characteristics = new List<Personal_characteristic>();
            for (int number = 0; number < characteristics.Count; number++)
                Personal_characteristics.Add(Test_parser_level_3(ref TESTS,characteristics[number], Dictionary_of_scales));

            if (!Stored_Exceptions.Empty)
                MessageBox.Show("Ошибка: резюме содержит ошибки!");

            Save_automatic_resume(TESTS, Answers_to_all_tests, Manifestations_all, Personal_characteristics, FileName);
        }
    }
}
