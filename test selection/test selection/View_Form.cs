using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace ASCPR
{
    public partial class View_Form : Form
    {
        string _HEADER = "";
        string _TEST_RESULT = "";
        string _AUTOMATIC_RESUME = "";
        string _LEVELS_OF_EXPRESSION = "";
        string _ANSWERS_TO_TESTS = "";
        string _TEST_SCALES = "";
        bool _HEADER_flag = true;
        bool _TEST_RESULT_flag = true;
        bool _AUTOMATIC_RESUME_flag = true;
        bool _LEVELS_OF_EXPRESSION_flag = false;
        bool _ANSWERS_TO_TESTS_flag = false;
        bool _TEST_SCALES_flag = false;

        bool Upload_data_from_file(string FileName)
        {
            using (StreamReader sr = new StreamReader(FileName))
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
                            case Descriptor_name._HEADER:
                                {
                                    Descriptors_implementation._GET_RESULT(ref i, line, out _HEADER);
                                    break;
                                }
                            case Descriptor_name._TEST_RESULT:
                                {
                                    Descriptors_implementation._GET_RESULT(ref i, line, out _TEST_RESULT);
                                    break;
                                }
                            case Descriptor_name._AUTOMATIC_RESUME:
                                {
                                    Descriptors_implementation._GET_RESULT(ref i, line, out _AUTOMATIC_RESUME);
                                    break;
                                }
                            case Descriptor_name._LEVELS_OF_EXPRESSION:
                                {
                                    Descriptors_implementation._GET_RESULT(ref i, line, out _LEVELS_OF_EXPRESSION);
                                    break;
                                }
                            case Descriptor_name._ANSWERS_TO_TESTS:
                                {
                                    Descriptors_implementation._GET_RESULT(ref i, line, out _ANSWERS_TO_TESTS);
                                    break;
                                }
                            case Descriptor_name._TEST_SCALES:
                                {
                                    Descriptors_implementation._GET_RESULT(ref i, line, out _TEST_SCALES);
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

        void Add_Text_on_form()
        {
            TextBox_for_test.Text = "";
            if (_HEADER_flag)
                TextBox_for_test.Text +=_HEADER + "\r\n\r\n";
            if (_TEST_RESULT_flag)
                TextBox_for_test.Text +=_TEST_RESULT + "\r\n\r\n";
            if (_AUTOMATIC_RESUME_flag)
                TextBox_for_test.Text +=_AUTOMATIC_RESUME + "\r\n\r\n";
            if (_LEVELS_OF_EXPRESSION_flag)
                TextBox_for_test.Text += _LEVELS_OF_EXPRESSION + "\r\n\r\n";
            if (_TEST_SCALES_flag)
                TextBox_for_test.Text += _TEST_SCALES + "\r\n\r\n";
            if (_ANSWERS_TO_TESTS_flag)
                TextBox_for_test.Text += _ANSWERS_TO_TESTS + "\r\n\r\n";
        }

        public View_Form(string path)
        {
            InitializeComponent();
            this.Show();
            this.BackgroundImage = Design.Background;
            Design.Design_for_button(button1);

            CheckBox_Header.ForeColor = Design.Font_color;
            CheckBox_Header.Font = Design.Font_text;

            CheckBox_Result_tests.ForeColor = Design.Font_color;
            CheckBox_Result_tests.Font = Design.Font_text;

            CheckBox_Auto_Resume.ForeColor = Design.Font_color;
            CheckBox_Auto_Resume.Font = Design.Font_text;

            CheckBox_Expression.ForeColor = Design.Font_color;
            CheckBox_Expression.Font = Design.Font_text;

            CheckBox_Scales.ForeColor = Design.Font_color;
            CheckBox_Scales.Font = Design.Font_text;

            CheckBox_Answers.ForeColor = Design.Font_color;
            CheckBox_Answers.Font = Design.Font_text;

            if (!Upload_data_from_file(path))
            {
                MessageBox.Show("Ошибка: при считывани файла.");
                return;
            }
            Add_Text_on_form();
        }
        
        private void Button_save_file_Click(object sender, EventArgs e)
        {
            StreamWriter myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "*.doc|*.doc|*.txt|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = System.IO.Path.GetFullPath(saveFileDialog1.FileName);
                myStream = new StreamWriter(path);
                myStream.WriteLine(TextBox_for_test.Text);
                myStream.Close();
            }
        }

        private void CheckBox_Header_Click(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == false)
                _HEADER_flag = false;
            else
                _HEADER_flag = true;
            Add_Text_on_form();
        }

        private void CheckBox_Result_tests_Click(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == false)
                _TEST_RESULT_flag = false;
            else
                _TEST_RESULT_flag = true;
            Add_Text_on_form();
        }

        private void CheckBox_Auto_Resume_Click(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == false)
                _AUTOMATIC_RESUME_flag = false;
            else
                _AUTOMATIC_RESUME_flag = true;
            Add_Text_on_form();
        }

        private void CheckBox_Expression_Click(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == false)
                _LEVELS_OF_EXPRESSION_flag = false;
            else
                _LEVELS_OF_EXPRESSION_flag = true;
            Add_Text_on_form();
        }
        
        private void CheckBox_Scales_Click(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == false)
                _TEST_SCALES_flag = false;
            else
                _TEST_SCALES_flag = true;
            Add_Text_on_form();
        }

        private void CheckBox_Answers_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == false)
                _ANSWERS_TO_TESTS_flag = false;
            else
                _ANSWERS_TO_TESTS_flag = true;
            Add_Text_on_form();
        }
    }
}
