using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace ASCPR
{
    sealed class Test // собственно сам тест для заплнения объектов на форме 
    {
        public Header _Header { get; set; }
        public List<Question> _Questions { get; set; }
        public List<Key> _Keys { get; set; }
        public List<Scale> _Scales { get; set; }
        public List<Fuzzy_sets> _Fuzzy_sets { get; set; }

        public Test()
        {
            _Header = new Header();
            _Questions = new List<Question>();
            _Keys = new List<Key>();
            _Scales = new List<Scale>();
            _Fuzzy_sets = new List<Fuzzy_sets>();
        }

        public Test(Test T){
            _Header = new Header(T._Header);
            _Questions = new List<Question>(T._Questions);
            _Keys = new List<Key>(T._Keys);
            _Scales = new List<Scale>(T._Scales);
            _Fuzzy_sets = new List<Fuzzy_sets>(T._Fuzzy_sets);
        }

        public bool Creat_test(string FileName) // создание теста
        {
            using (StreamReader sr = new StreamReader(Setting.tests_path + "\\" + FileName, Encoding.GetEncoding(1251)))
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

                        switch (keyword) // заполнение класса Test
                        {
                            case Descriptor_name._ANSWER:
                                {
                                    Descriptors_implementation._ANSWER(_Questions, ref i, ref line);
                                        break;
                                }
                            case Descriptor_name._QUESTION:
                                {
                                    Descriptors_implementation._QUESTION(_Questions, ref i, ref line);
                                        break;
                                }
                            case Descriptor_name._SCALE:
                                {
                                    Descriptors_implementation._SCALE(_Scales, ref i, ref line);
                                        break;
                                }
                            case Descriptor_name._KEY:
                                {
                                    Descriptors_implementation._KEY(_Keys, ref i, ref line);
                                        break;
                                }
                            case Descriptor_name._FUZZY_SETS:
                                {
                                    Descriptors_implementation._FUZZY_SETS(_Fuzzy_sets, ref i, ref line);
                                        break;
                                }
                            case Descriptor_name._NAME:
                                {
                                    Descriptors_implementation._NAME(_Header, ref i, ref line);
                                        break;
                                }
                            case Descriptor_name._DESCRIPTION:
                                {
                                    Descriptors_implementation._DESCRIPTION(_Header, ref i, ref line);
                                        break;
                                }
                            case Descriptor_name._VERIFIER:
                                {
                                    Descriptors_implementation._VERIFIER(_Header, ref i, ref line);
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
    }
}
