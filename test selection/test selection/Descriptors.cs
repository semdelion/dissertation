using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ASCPR
{
    public static class Descriptor_name
    {
        public const string _NAME = "_NAME";
        public const string _DESCRIPTION = "_DESCRIPTION";
        public const string _QUESTION = "_QUESTION";
        public const string _ANSWER = "_ANSWER";

        public const string _KEY = "_KEY";
        public const string _SCALE = "_SCALE";

        public const string _FUZZY_SETS = "_FUZZY_SETS";

        public const string _HEADER = "_HEADER";
        public const string _TEST_RESULT = "_TEST_RESULT";
        public const string _AUTOMATIC_RESUME = "_AUTOMATIC_RESUME";
        
        public const string _ANSWERS_TO_TESTS = "_ANSWERS_TO_TESTS";
        public const string _TEST_SCALES = "_TEST_SCALES";
        public const string _LEVELS_OF_EXPRESSION = "_LEVELS_OF_EXPRESSION";

        public const string _VERIFIER = "_VERIFIER";
        public const string _AT_LEAST_ONE = "_AT_LEAST_ONE";
        public const string _ONLY_ONE = "_ONLY_ONE";
        public const string _NO_LIMITS = "_NO_LIMITS";

        public const string _GROUP = "_GROUP";
        public const string _LINK = "_LINK";
    }

    static class Descriptors_implementation
    {
        public static void _NAME(Header _Header, ref int i, ref string line)
        {
            _Header.Name = Additional_functions.ClearLine(ref i, line);
        }

        public static void _DESCRIPTION(Header _Header, ref int i, ref string line)
        {
            _Header.Description = Additional_functions.ClearLine(ref i, line);
        }

        public static void _VERIFIER(Header _Header, ref int i, ref string line)
        {
            string tmp_nt = Additional_functions.ClearLine(ref i, line);
            switch (tmp_nt)
            {
                case Descriptor_name._ONLY_ONE: { _Header.Verifier = Descriptor_name._ONLY_ONE; break; }
                case Descriptor_name._AT_LEAST_ONE: { _Header.Verifier = Descriptor_name._AT_LEAST_ONE; break; }
                case Descriptor_name._NO_LIMITS: { _Header.Verifier = Descriptor_name._NO_LIMITS; break; }
            }
        }

        public static void _QUESTION(List<Question> _Questions, ref int i, ref string line)
        {
            _Questions.Add(new Question());
            _Questions[_Questions.Count - 1]._Question = Additional_functions.ClearLine(ref i, line);
        }

        public static void _ANSWER(List<Question> _Questions, ref int i, ref string line)
        {
            _Questions[_Questions.Count - 1]._Answer.Add(Additional_functions.ClearLine(ref i, line));
        }

        public static void _KEY(List<Key> _Keys, ref int i, ref string line)
        {
            string temp = Additional_functions.ClearLine(ref i, line);
            temp = temp.Replace('\n', ' ').Replace('\r', ' ').Replace(" ", "");
            try{
                Key key = new Key();
                string[] rows = temp.Split('+');
                foreach (var row in rows){
                    int k = 0;
                    key.Add(new Element(
                    
                        Convert.ToInt32(Additional_functions.Trim(row, ref k, '[', ']')),
                        Convert.ToInt32(Additional_functions.Trim(row, ref k, '(', ')')),
                        Convert.ToSingle(Additional_functions.Trim(row, ref k, '=', '*').Replace('.', ','))
                    ));
                }
                _Keys.Add(key);
            }
            catch{
                Stored_Exceptions.Add(new Exception("Error: _Keys exception, key number " + _Keys.Count + 1));
            }
        }

        public static void _SCALE(List<Scale> _Scales, ref int i, ref string line)
        {
            try{
                string temp = "";
                for (; i < line.Length && line[i] != ']'; i++)
                    temp += line[i];
                for (; i < line.Length && line[i] != '<'; i++)
                    temp += line[i];
                temp = temp.Trim();
                int k = 0;
                Scale scale = new Scale(
                    Additional_functions.Trim(temp, ref k, '[', ']').Replace('\n', ' ').Replace('\r', ' ').Replace(" ", ""),
                    Additional_functions.Trim(temp, ref k, '(', ')'),
                    Additional_functions.ClearLine(ref i, line)
                );
                _Scales.Add(scale);
            }
            catch{
                Stored_Exceptions.Add(new Exception("Error: _Scales exception, Scale number " + _Scales.Count + 1));
            }
        }

        public static void _FUZZY_SETS(List<Fuzzy_sets> _Fuzzy_sets, ref int i, ref string line)
        {
            Fuzzy_sets F_s = new Fuzzy_sets
            {
                Name = (Additional_functions.Trim(line, ref i, '(', ')')).Trim()
            };
            string temp = Additional_functions.ClearLine(ref i, line).Replace('\n', ' ').Replace('\r', ' ').Replace(" ", "");
            try{
                string[] Functions = temp.Split(',');
                int k = 0;
                foreach (var f in Functions){
                    F_s.Functions.Add(new Trapeze(
                        Additional_functions.ToLine(Additional_functions.Trim(f, ref k, '[', ']'), Additional_functions.Trim(f, ref k, '[', ']')),
                        Additional_functions.ToLine(Additional_functions.Trim(f, ref k, '[', ']'), Additional_functions.Trim(f, ref k, '[', ']'))
                    ));
                    k = 0;
                }
                _Fuzzy_sets.Add(F_s);
            }
            catch{
                Stored_Exceptions.Add(new Exception("Error: _Fuzzy_sets exception, fuzzy sets number " + _Fuzzy_sets.Count + 1));
            }
        }

        public static void _GROUP(List<Group> Groups, ref int i, ref string line)
        {
            Groups.Add(new Group());
            Groups[Groups.Count - 1].Manifestation = Additional_functions.ClearLine(ref i, line, '<','>',false);
        }

        public static void _LINK(List<Group> Groups, ref int i, ref string line)
        {
            string temp = Additional_functions.ClearLine(ref i, line);
            try
            {
                string[] links = temp.Split('&');
                int k = 0;
                Link L = new Link();
                foreach (var l in links)
                {
                    L.Add(
                            Additional_functions.Trim(l, ref k, '{', '}'),
                            Additional_functions.Trim(l, ref k, '{', '}'),
                            Convert.ToInt32(Additional_functions.Trim(l, ref k, '[', ']'))
                        );
                    k = 0;
                }
                Groups[Groups.Count - 1].Links.Add(L);
            }
            catch
            {
                Stored_Exceptions.Add(new Exception("Error: Link exception, in Group " + Groups.Count));
            }
        }

        public static List<double> _SUM_counting(List<Key> keys, Answers_to_Test Answers_to_the_test)
        {
            try
            {
                List<double> Key_value_all = new List<double>();
                for (int scale_number = 0; scale_number < keys.Count; scale_number++){
                    double Point = 0;
                    for (int i = 0; i < keys[scale_number].Count; i++){
                        for (int j = 0; j < Answers_to_the_test[(keys[scale_number][i].Question - 1)].Count; j++){
                            if (Answers_to_the_test[(keys[scale_number][i].Question - 1)][j] == (keys[scale_number][i].Answer - 1))
                                Point += keys[scale_number][i].Point;
                        }
                    }
                    Key_value_all.Add(Point);
                }
                return Key_value_all;
            }
            catch{
                Stored_Exceptions.Add(new Exception("Error: internal format is not correct"));
                return null;
            }
        }

        public static string _SCALE_counting(Scale _Scale, List<double> Key_value, Dictionary<string, double> newscale)
        {
            try{
                string expression = _Scale.If_scale;
                expression = Additional_functions.Replace_Point(expression, Key_value);
                expression = expression.Replace(',','.');
                if (!newscale.Keys.Contains(_Scale.Name_scale)){// add new name scale
                    string tmp = Additional_functions.Split_for_value(expression);
                    tmp = Additional_functions.Clean_for_compilation(tmp);
                    double point = Convert.ToSingle(Additional_functions.Verification_of_conditions(Constants_for_the_compiler.Begin_C, tmp, Constants_for_the_compiler.End));
                    newscale.Add(_Scale.Name_scale, point);
                }
                if (Convert.ToBoolean(Additional_functions.Verification_of_conditions(Constants_for_the_compiler.Begin_V, expression, Constants_for_the_compiler.End)))
                    return  ("(" + _Scale.Name_scale + ") " + "Баллов - " + Convert.ToString(newscale[_Scale.Name_scale]) +"\r\n"+ _Scale.Manifestation);
                return null;
            }
            catch{
                Stored_Exceptions.Add(new Exception ("Error: internal format is not correct"));
                return null;
            }
        }

        public static void _GET_RESULT(ref int i, string line, out string result)
        {
            result = Additional_functions.ClearLine(ref i, line);
        }
    }
}
                                
                               