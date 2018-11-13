using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ASCPR
{
    class Link
    {
        public List<string> Test_name { get; set;}
        public List<string> Scale_name { get; set;}
        public List<int> Function_number { get; set; }
        public double Measure_of_expression { get; set; }

        public Link()
        {
            Test_name = new List<string>();
            Scale_name = new List<string>();
            Function_number = new List<int>();
            Measure_of_expression = -1;
        }

        public Link(Link L)
        {
            Test_name = new List<string>(L.Test_name);
            Scale_name = new List<string>(L.Scale_name);
            Function_number = new List<int>(L.Function_number);
            Measure_of_expression = L.Measure_of_expression;
        }

        public void Add(string test_name, string scale_name, int function_number)
        {
            Test_name.Add(test_name);
            Scale_name.Add(scale_name);
            Function_number.Add(function_number);
        }
    }

    class Group
    {
        public string Manifestation { get; set; }
        public List<Link> Links { get; set; }

        public Group()
        {
            Manifestation = "";
            Links = new List<Link>();
        }

        public Group(Group G)
        {
            Manifestation = G.Manifestation;
            Links = new List<Link>(G.Links);
        }
    }

    class Personal_characteristic
    {
        public string Name { get; set; }
        public List<Group> Groups { get; set; }

        public Personal_characteristic()
        {
            Name = "";
            Groups = new List<Group>();
        }

        public Personal_characteristic(Personal_characteristic P_CH)
        {
            Name = P_CH.Name;
            Groups = new List<Group>(P_CH.Groups);
        }

        public bool Creat_Personal_characteristic(string FileName)
        {
            using (StreamReader sr = new StreamReader(Setting.characteristics_path + "\\" + FileName + ".txt", Encoding.GetEncoding(1251)))
            {
                string line = sr.ReadToEnd();
                string keyword;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '_') // выделение ключевого слова 
                    {
                        keyword = "";
                        for (; i < line.Length && line[i] != ' '; i++)
                            keyword += line[i];
                        Enum.TryParse(keyword, out Descriptors Descriptor);
                        switch (Descriptor) // заполнение класса 
                        {
                            case Descriptors._GROUP:
                                {
                                    Descriptors_implementation._GROUP(Groups, ref i, ref line);
                                    break;
                                }
                            case Descriptors._LINK:
                                {
                                    Descriptors_implementation._LINK(Groups, ref i, ref line);
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                }
                if (!Stored_Exceptions.Empty)
                {
                    Stored_Exceptions.Show();
                    MessageBox.Show("The file could not be read:");
                    return false;
                }
            }
            return true;
        }

        private bool Contains_links(List<string> completed_tests, Link L)
        {
            for (int i = 0; i < L.Test_name.Count; i++)
            {
                if (!completed_tests.Contains(L.Test_name[i]))
                    return false;
            }
            return true;
        }

        public void Remove_links_to_missing_tests(List<string> completed_tests)
        {
            for (int i = 0; i < Groups.Count; i++)
                for (int j = 0; j < Groups[i].Links.Count; j++)
                    if (!Contains_links(completed_tests, Groups[i].Links[j]))
                    {
                        Groups[i].Links.RemoveAt(j);
                        j--;
                    }
        }

        double Return_Measure_for_fuzzy_sets(Test TEST, string Scale_name, double point_on_scale, int number_function)
        {
            try
            {
                for (int i = 0; i < TEST._Fuzzy_sets.Count; i++)

                    if (TEST._Fuzzy_sets[i].Name == Scale_name)
                        return Convert.ToSingle(TEST._Fuzzy_sets[i].Functions[number_function - 1].Measure_of_belonging(Convert.ToSingle(point_on_scale)));
                return 0;
            }
            catch
            {
                Stored_Exceptions.Add(new Exception("Error: number the function for fuzzy sets given with wrong"));
                return 0;
            }
        }

        public void Calculation_measure_of_expression(List<Dictionary<string, double>> Dictionary_of_scales,List<Test> TESTS)
        {
            for (int number_group = 0; number_group < Groups.Count; number_group++)
            {
                for (int number_link = 0; number_link < Groups[number_group].Links.Count; number_link++)
                {
                    double Sum = 0;
                    for (int i = 0; i < Groups[number_group].Links[number_link].Test_name.Count; i++)
                    {
                        int number_test = Additional_functions.Number_of_Contains(TESTS, Groups[number_group].Links[number_link].Test_name[i]);
                        if (number_test >= 0 && Dictionary_of_scales[number_test].TryGetValue(Groups[number_group].Links[number_link].Scale_name[i], out double point_on_scale)) 
                                Sum += Return_Measure_for_fuzzy_sets(
                                TESTS[number_test], 
                                Groups[number_group].Links[number_link].Scale_name[i], 
                                point_on_scale, Groups[number_group].Links[number_link].Function_number[i]
                                );
                        else
                            Stored_Exceptions.Add(new Exception("Error: cannot find name of scale"));
                    }
                    if (Stored_Exceptions.Empty)
                        Groups[number_group].Links[number_link].Measure_of_expression = Sum / Groups[number_group].Links[number_link].Scale_name.Count;
                }
            }
        }

        public void Show()
        {
            string Text = Name;
            for (int i = 0; i < Groups.Count; i++)
            {
                Text +=  $"\n\r {(i+1)}) {Groups[i].Manifestation}";
                for (int j = 0; j < Groups[i].Links.Count; j++)
                    Text += $"\n\r           {(j + 1)}) {Groups[i].Links[j].Test_name[0]}  {Groups[i].Links[j].Scale_name[0]}" +
                        $"   {Groups[i].Links[j].Function_number[0]}    {Groups[i].Links[j].Measure_of_expression}";
            }
            MessageBox.Show(Text);
        }
    }
}
