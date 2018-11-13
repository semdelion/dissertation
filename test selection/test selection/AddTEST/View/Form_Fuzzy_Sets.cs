using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace ASCPR
{
    public partial class Form_Fuzzy_Sets : Form
    {
        private int Fuzzy_sets_number = 0;
        private Bitmap My_bitmap = null;
        private List<TextBox> textBox_left_x1 = new List<TextBox>();
        private List<TextBox> textBox_left_x2 = new List<TextBox>();
        private List<TextBox> textBox_right_x1 = new List<TextBox>();
        private List<TextBox> textBox_right_x2 = new List<TextBox>();

        private void Hide_O()
        {
            main_panel.Hide();
            button_left.Hide();
            button_right.Hide();
            Fuzzy_sets_label.Hide();
        }

        private void Show_O()
        {
            main_panel.Show();
            button_left.Show();
            button_right.Show();
            Fuzzy_sets_label.Show();
        }

        private new void Resize()
        {
            button_right.Location = new Point(Fuzzy_sets_label.Location.X + 15 + Fuzzy_sets_label.Width, button_right.Location.Y);
        }

        private void Clear_panel()
        {
            for (int i = textBox_left_x1.Count - 1; i >= 0; i--)
            {
                main_panel.Controls.Remove(textBox_left_x1[i]);
                main_panel.Controls.Remove(textBox_left_x2[i]);
                main_panel.Controls.Remove(textBox_right_x1[i]);
                main_panel.Controls.Remove(textBox_right_x2[i]);
            }
        }

        private void Delete_last_function_on_panel()
        {
            main_panel.Controls.Remove(textBox_left_x1[textBox_left_x1.Count - 1]);
            main_panel.Controls.Remove(textBox_left_x2[textBox_left_x2.Count - 1]);
            main_panel.Controls.Remove(textBox_right_x1[textBox_right_x1.Count - 1]);
            main_panel.Controls.Remove(textBox_right_x2[textBox_right_x2.Count - 1]);
        }

        private void Add_textboxes_on_function_on_form(int height, TextBox L_x1, TextBox L_x2, TextBox R_x1, TextBox R_x2)
        {
            Additional_functions.Create_textbox(L_x1, 100, label_left_line.Location.X, height);
            L_x1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top) | System.Windows.Forms.AnchorStyles.Left);
            main_panel.Controls.Add(L_x1);

            Additional_functions.Create_textbox(L_x2, 100, L_x1.Location.X + L_x1.Width + 15, height);
            L_x2.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top) | System.Windows.Forms.AnchorStyles.Left);
            main_panel.Controls.Add(L_x2);

            Additional_functions.Create_textbox(R_x1, 100, label_right_line.Location.X, height);
            R_x1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top) | System.Windows.Forms.AnchorStyles.Left);
            main_panel.Controls.Add(R_x1);

            Additional_functions.Create_textbox(R_x2, 100, R_x1.Location.X + R_x1.Width + 15, height);
            R_x2.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top) | System.Windows.Forms.AnchorStyles.Left);
            main_panel.Controls.Add(R_x2);
        }

        private void Create_Functions(Test TEST, int index = 0)
        {
            C_Function_label.Text = $"Количество функций {Convert.ToString(TEST._Fuzzy_sets[Fuzzy_sets_number].Functions.Count)}";
            int height;
            if (index == 0)
                height = label_left_line.Location.Y + label_left_line.Height + 15;
            else if (index > TEST._Fuzzy_sets[Fuzzy_sets_number].Functions.Count - 1)
                return;
            else
                height = textBox_left_x1[index - 1].Location.Y + 15 + textBox_left_x1[index - 1].Height;
            for (int i = index; i < TEST._Fuzzy_sets[Fuzzy_sets_number].Functions.Count; i++)
            {
                Add_textboxes_on_function_on_form(height, textBox_left_x1[i], textBox_left_x2[i], textBox_right_x1[i], textBox_right_x2[i]);
                textBox_left_x1[i].Text = Convert.ToString(TEST._Fuzzy_sets[Fuzzy_sets_number].Functions[i].Left_side.A.X);
                textBox_left_x2[i].Text = Convert.ToString(TEST._Fuzzy_sets[Fuzzy_sets_number].Functions[i].Left_side.B.X);
                textBox_right_x1[i].Text = Convert.ToString(TEST._Fuzzy_sets[Fuzzy_sets_number].Functions[i].Right_side.A.X);
                textBox_right_x2[i].Text = Convert.ToString(TEST._Fuzzy_sets[Fuzzy_sets_number].Functions[i].Right_side.B.X);

                textBox_left_x1[i].KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
                textBox_left_x2[i].KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
                textBox_right_x1[i].KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
                textBox_right_x2[i].KeyPress += new KeyPressEventHandler(TextBox_KeyPress);

                height = textBox_left_x1[i].Location.Y + 15 + textBox_left_x1[i].Height;
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (number == ',' || number == 8)
                e.Handled = false;
            else if (!Char.IsDigit(number))
                e.Handled = true;
        }

        private void Create_Fuzzy_sets(Test TEST)
        {
            this.SuspendLayout();
            Fuzzy_sets_label.Text = $"{Convert.ToString(Fuzzy_sets_number + 1)} / {Convert.ToString(TEST._Fuzzy_sets.Count)}";
            textBox_fuzzy_set_name.Text = TEST._Fuzzy_sets[Fuzzy_sets_number].Name;
            Clear_panel();
            Show_O();
            Resize();
            textBox_left_x1 = new List<TextBox>();
            textBox_left_x2 = new List<TextBox>();
            textBox_right_x1 = new List<TextBox>();
            textBox_right_x2 = new List<TextBox>();
            for (int i = 0; i < TEST._Fuzzy_sets[Fuzzy_sets_number].Functions.Count; i++)
            {
                textBox_left_x1.Add(new TextBox());
                textBox_left_x2.Add(new TextBox());
                textBox_right_x1.Add(new TextBox());
                textBox_right_x2.Add(new TextBox());
            }
            Create_Functions(TEST);
            Button_Show_Click(null, null);
            this.ResumeLayout(false);
        }

        private void Design_for_Form_Fuzzy_sets()
        {
            BackgroundImage = Design.Background;

            Design.Design_for_button(button_create);
            Design.Design_for_button(button_back);
            Design.Design_for_button(button_next);
            Design.Design_for_button(button_left);
            Design.Design_for_button(button_right);
            Design.Design_for_button(button_Show);

            Design.Design_for_label(CoFuzzy_sets_label);
            Design.Design_for_label(Fuzzy_sets_label);
            Design.Design_for_label(C_Function_label);
            Design.Design_for_label(label_left_line);
            Design.Design_for_label(label_right_line);
            Design.Design_for_label(label_Fuzzy_set_name);

            button_add_function.BackgroundImage = Design.Background_button_add;
            button_remove_function.BackgroundImage = Design.Background_button_remove;

            Design.Design_for_textbox(CoFuzzy_sets_textBox);
            Design.Design_for_textbox(textBox_fuzzy_set_name);

            Fuzzy_sets_label.Font = new Font("Arial", 24F);
            CoFuzzy_sets_textBox.Location = new Point(CoFuzzy_sets_label.Location.X + 15 + CoFuzzy_sets_label.Width, CoFuzzy_sets_label.Location.Y);
            button_create.Width = CoFuzzy_sets_textBox.Location.X + CoFuzzy_sets_textBox.Width - CoFuzzy_sets_label.Location.X;
            Hide_O();
        }

        private void DrawLine(PointF a, PointF b, float min, float max)
        {
            Brush brush = new SolidBrush(Color.Black);
            Graphics g = Graphics.FromImage(My_bitmap);
            float scope_x;
            if (max - min == 0)
                scope_x = 0;
            else
                scope_x = (My_bitmap.Width - 50) / (max - min);

            Pen pen = new Pen(Brushes.Blue, 3);

            g.DrawLine(pen, (a.X * scope_x) + 25, a.Y == 0 ? (pictureBox_Fuzzy_sets.Height - 25) : 25,
                (b.X * scope_x) + 25, b.Y == 0 ? (pictureBox_Fuzzy_sets.Height - 25) : 25);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            if (a.Y == 1)
                g.DrawLine(pen, a.X * scope_x + 25, pictureBox_Fuzzy_sets.Height - 25, a.X * scope_x + 25, 25);
            else
                g.DrawLine(pen, b.X * scope_x + 25, pictureBox_Fuzzy_sets.Height - 25, b.X * scope_x + 25, 25);
            g.DrawString(Convert.ToString(a.X), Design.Font_text, brush, (a.X * scope_x) + 20, pictureBox_Fuzzy_sets.Height - 24);
            g.DrawString(Convert.ToString(b.X), Design.Font_text, brush, (b.X * scope_x) + 20, pictureBox_Fuzzy_sets.Height - 24);
        }

        private void DrawFunc()
        {
            My_bitmap = new Bitmap(pictureBox_Fuzzy_sets.Width, pictureBox_Fuzzy_sets.Height);
            Graphics g = Graphics.FromImage(My_bitmap);
            g.DrawLine(new Pen(Brushes.Black, 2), 10, pictureBox_Fuzzy_sets.Height - 25, pictureBox_Fuzzy_sets.Width - 20, pictureBox_Fuzzy_sets.Height - 25);
            g.DrawLine(new Pen(Brushes.Black, 2), pictureBox_Fuzzy_sets.Width - 25, pictureBox_Fuzzy_sets.Height - 20, pictureBox_Fuzzy_sets.Width - 20, pictureBox_Fuzzy_sets.Height - 25);
            g.DrawLine(new Pen(Brushes.Black, 2), pictureBox_Fuzzy_sets.Width - 25, pictureBox_Fuzzy_sets.Height - 30, pictureBox_Fuzzy_sets.Width - 20, pictureBox_Fuzzy_sets.Height - 25);

            g.DrawLine(new Pen(Brushes.Black, 2), 20, pictureBox_Fuzzy_sets.Height - 10, 20, 10);
            g.DrawLine(new Pen(Brushes.Black, 2), 15, 15, 20, 10);
            g.DrawLine(new Pen(Brushes.Black, 2), 25, 15, 20, 10);
            pictureBox_Fuzzy_sets.BackgroundImage = My_bitmap;
        }

        private void TextBox_KeyPress_integers(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (number == 8)
                e.Handled = false;
            else if (!Char.IsDigit(number))
                e.Handled = true;
        }

        private bool Find_max_and_min(out float max, out float min)
        {
            try
            {
                if (textBox_left_x1[0].Text != "")
                    min = max = Convert.ToSingle(textBox_left_x1[0].Text);
                else
                {
                    min = max = 0;
                    return false;
                }
                for (int i = 0; i < textBox_left_x1.Count; i++)
                {
                    if (textBox_left_x1[i].Text == "" || textBox_left_x2[i].Text == "")
                        return true;

                    max = Math.Max(Convert.ToSingle(textBox_left_x1[i].Text), max);
                    max = Math.Max(Convert.ToSingle(textBox_left_x2[i].Text), max);

                    min = Math.Min(Convert.ToSingle(textBox_left_x1[i].Text), min);
                    min = Math.Min(Convert.ToSingle(textBox_left_x2[i].Text), min);

                    if (textBox_right_x1[i].Text == "" || textBox_right_x2[i].Text == "")
                        return true;

                    max = Math.Max(Convert.ToSingle(textBox_right_x1[i].Text), max);
                    max = Math.Max(Convert.ToSingle(textBox_right_x2[i].Text), max);

                    min = Math.Min(Convert.ToSingle(textBox_right_x1[i].Text), min);
                    min = Math.Min(Convert.ToSingle(textBox_right_x2[i].Text), min);
                }
                return true;
            }
            catch
            {
                min = max = 0;
                return false;
            }



        }

        private void Create_file(Test TEST)
        {
            Random t = new Random();
            string fileName = "";
            fileName = TEST._Header.Name;

            fileName = Additional_functions.Create_name_for_file(fileName);
            StreamWriter sr;
            sr = new StreamWriter(fileName = $"{Setting.tests_path}\\{fileName}.txt", true, Encoding.UTF8);
            sr.WriteLine($"{Descriptors._NAME} <{TEST._Header.Name }>");
            sr.WriteLine($"{Descriptors._DESCRIPTION} <{TEST._Header.Description}>");
            sr.WriteLine($"{Descriptors._VERIFIER} <{TEST._Header.Verifier}>");
            for (int i = 0; i < TEST._Questions.Count; i++)
            {
                sr.WriteLine($"{Descriptors._QUESTION} <{TEST._Questions[i]._Question}>");
                for (int j = 0; j < TEST._Questions[i]._Answer.Count; j++)
                    sr.WriteLine($"  {Descriptors._ANSWER} <{TEST._Questions[i]._Answer[j]}>");
            }
            for (int i = 0; i < TEST._Keys.Count; i++)
            {
                sr.WriteLine($"{Descriptors._KEY} [{i}]<");
                for (int j = 0; j < TEST._Keys[i].Count - 1; j++)
                    sr.WriteLine($"[{TEST._Keys[i][j].Question}]({TEST._Keys[i][j].Answer})={TEST._Keys[i][j].Point}+");
                sr.WriteLine($"[{TEST._Keys[i][TEST._Keys[i].Count - 1].Question}]({TEST._Keys[i][TEST._Keys[i].Count - 1].Answer})={TEST._Keys[i][TEST._Keys[i].Count - 1].Point}>");
            }
            for (int i = 0; i < TEST._Scales.Count; i++)
            {
                sr.WriteLine($"{Descriptors._SCALE} [{TEST._Scales[i].If_scale}]({TEST._Scales[i].Name_scale}) ");
                sr.WriteLine($"<{TEST._Scales[i].Manifestation}>");
            }
            for (int i = 0; i < TEST._Fuzzy_sets.Count; i++)
            {
                sr.WriteLine(Descriptors._FUZZY_SETS + " (" + TEST._Fuzzy_sets[i].Name + ") <");
                for (int j = 0; j < TEST._Fuzzy_sets[i].Functions.Count - 1; j++)
                {
                    sr.Write($"[{TEST._Fuzzy_sets[i].Functions[j].Left_side.A.X};{TEST._Fuzzy_sets[i].Functions[j].Left_side.A.Y}]");
                    sr.Write($"[{TEST._Fuzzy_sets[i].Functions[j].Left_side.B.X};{TEST._Fuzzy_sets[i].Functions[j].Left_side.B.Y}]");
                    sr.Write($"[{TEST._Fuzzy_sets[i].Functions[j].Right_side.A.X};{TEST._Fuzzy_sets[i].Functions[j].Right_side.A.Y}]");
                    sr.WriteLine($"[{TEST._Fuzzy_sets[i].Functions[j].Right_side.B.X};{TEST._Fuzzy_sets[i].Functions[j].Right_side.B.Y}],");
                }
                sr.Write($"[{TEST._Fuzzy_sets[i].Functions[TEST._Fuzzy_sets[i].Functions.Count - 1].Left_side.A.X};{TEST._Fuzzy_sets[i].Functions[TEST._Fuzzy_sets[i].Functions.Count - 1].Left_side.A.Y}]");
                sr.Write($"[{TEST._Fuzzy_sets[i].Functions[TEST._Fuzzy_sets[i].Functions.Count - 1].Left_side.B.X};{TEST._Fuzzy_sets[i].Functions[TEST._Fuzzy_sets[i].Functions.Count - 1].Left_side.B.Y}]");
                sr.Write($"[{TEST._Fuzzy_sets[i].Functions[TEST._Fuzzy_sets[i].Functions.Count - 1].Right_side.A.X};{TEST._Fuzzy_sets[i].Functions[TEST._Fuzzy_sets[i].Functions.Count - 1].Right_side.A.Y}]");
                sr.WriteLine($"[{TEST._Fuzzy_sets[i].Functions[TEST._Fuzzy_sets[i].Functions.Count - 1].Right_side.B.X};{TEST._Fuzzy_sets[i].Functions[TEST._Fuzzy_sets[i].Functions.Count - 1].Right_side.B.Y}]>");
            }
            sr.Close();
            MessageBox.Show("Файл добавлен");
            this.Close();
        }

        internal Form_Fuzzy_Sets(Test TEST)
        {
            InitializeComponent();
            My_bitmap = new Bitmap(pictureBox_Fuzzy_sets.Width, pictureBox_Fuzzy_sets.Height);
            Design_for_Form_Fuzzy_sets();
            Show();

            CoFuzzy_sets_textBox.Text = Convert.ToString(TEST._Fuzzy_sets.Count);
            CoFuzzy_sets_textBox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress_integers);
            button_create.Click += new EventHandler(button_create_click);
            button_add_function.Click += new EventHandler(button_add_function_click);
            button_remove_function.Click += new EventHandler(button_remove_function_click);
            button_left.Click += new EventHandler(button_left_click);
            button_right.Click += new EventHandler(button_right_click);
            button_next.Click += new EventHandler(button_next_click);
            button_back.Click += new EventHandler(button_back_click);
            
            if (TEST._Fuzzy_sets.Count > 0)
                Create_Fuzzy_sets(TEST);

            void button_create_click(object sender, EventArgs e)
            {
                try
                {
                    int tmp = Convert.ToInt32(CoFuzzy_sets_textBox.Text);
                    if (tmp > 0)
                    {
                        if (tmp > TEST._Fuzzy_sets.Count)
                        {
                            for (int i = TEST._Fuzzy_sets.Count; i < tmp; i++)
                                TEST._Fuzzy_sets.Add(new Fuzzy_sets());
                            Create_Fuzzy_sets(TEST);
                        }
                        if (tmp < TEST._Fuzzy_sets.Count)
                        {
                            for (int i = TEST._Fuzzy_sets.Count - 1; i >= tmp; i--)
                                TEST._Fuzzy_sets.RemoveAt(i);
                            if (Fuzzy_sets_number >= TEST._Fuzzy_sets.Count)
                                Fuzzy_sets_number = TEST._Fuzzy_sets.Count - 1;
                            Create_Fuzzy_sets(TEST);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка: некорректно задано число вопросов. OS");
                }
            }

            void button_add_function_click(object sender, EventArgs e)
            {
                TEST._Fuzzy_sets[Fuzzy_sets_number].Functions.Add(new Trapeze());

                textBox_left_x1.Add(new TextBox());
                textBox_left_x2.Add(new TextBox());
                textBox_right_x1.Add(new TextBox());
                textBox_right_x2.Add(new TextBox());

                Create_Functions(TEST);
            }

            void button_remove_function_click(object sender, EventArgs e)
            {
                if (TEST._Fuzzy_sets[Fuzzy_sets_number].Functions.Count <= 0)
                    return;
                Delete_last_function_on_panel();
                TEST._Fuzzy_sets[Fuzzy_sets_number].Functions.RemoveAt(TEST._Fuzzy_sets[Fuzzy_sets_number].Functions.Count - 1);
                textBox_left_x1.RemoveAt(textBox_left_x1.Count - 1);
                textBox_left_x2.RemoveAt(textBox_left_x2.Count - 1);
                textBox_right_x1.RemoveAt(textBox_right_x1.Count - 1);
                textBox_right_x2.RemoveAt(textBox_right_x2.Count - 1);
                C_Function_label.Text = $"Количество функций {Convert.ToString(TEST._Fuzzy_sets[Fuzzy_sets_number].Functions.Count)}";
            }

            void button_left_click(object sender, EventArgs e)
            {
                if (Fuzzy_sets_number <= 0)
                    return;
                Fuzzy_sets_number--;
                Clear_panel();
                textBox_left_x1 = new List<TextBox>();
                textBox_left_x2 = new List<TextBox>();
                textBox_right_x1 = new List<TextBox>();
                textBox_right_x2 = new List<TextBox>();
                Create_Functions(TEST);
            }

            void button_right_click(object sender, EventArgs e)
            {
                try
                {
                    bool check = false;
                    for (int i = 0; i < TEST._Scales.Count; i++)
                        if (TEST._Scales[i].Name_scale.ToLower() == textBox_fuzzy_set_name.Text.Trim().ToLower())
                            check = true;
                    if (!check)
                    {
                        MessageBox.Show($"Ошибка: шкала {textBox_fuzzy_set_name.Text.Trim()} не найдена!");
                        return;
                    }
                    if (textBox_left_x1.Count == 0)
                    {
                        MessageBox.Show("Ошибка: множество должно содержать хотя бы одну функцию");
                        return;
                    }
                    TEST._Fuzzy_sets[Fuzzy_sets_number].Name = textBox_fuzzy_set_name.Text.Trim();
                    for (int i = 0; i < textBox_left_x1.Count; i++)
                    {
                        if (textBox_left_x1[i].Text == "" || textBox_left_x2[i].Text == "" || textBox_right_x1[i].Text == "" || textBox_right_x2[i].Text == "")
                            return;
                        float L_x1 = Convert.ToSingle(textBox_left_x1[i].Text);
                        float L_x2 = Convert.ToSingle(textBox_left_x2[i].Text);
                        float R_x1 = Convert.ToSingle(textBox_right_x1[i].Text);
                        float R_x2 = Convert.ToSingle(textBox_right_x2[i].Text);
                        if (L_x1 > L_x2 || L_x2 > R_x1 || R_x1 > R_x2)
                        {
                            MessageBox.Show($"Ошибка: В строке {Convert.ToString(i)}, все элементы должны быть в порядке возрастения!");
                            return;
                        }
                        TEST._Fuzzy_sets[Fuzzy_sets_number].Functions[i].Left_side.A = new PointF(L_x1, 0);
                        TEST._Fuzzy_sets[Fuzzy_sets_number].Functions[i].Left_side.B = new PointF(L_x2, 1);
                        TEST._Fuzzy_sets[Fuzzy_sets_number].Functions[i].Right_side.A = new PointF(R_x1, 1);
                        TEST._Fuzzy_sets[Fuzzy_sets_number].Functions[i].Right_side.B = new PointF(R_x2, 0);
                    }
                    if (Fuzzy_sets_number >= TEST._Fuzzy_sets.Count - 1)
                    {
                        MessageBox.Show("Добавлено последнее множество!");
                        return;
                    }
                    Fuzzy_sets_number++;
                    Clear_panel();
                    Create_Fuzzy_sets(TEST);
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                    return;
                }
            }

            void button_next_click(object sender, EventArgs e)
            {
                if (TEST._Fuzzy_sets.Count == 0)
                {
                    this.Close();
                    Create_file(TEST);
                }
                else if (TEST._Fuzzy_sets[TEST._Fuzzy_sets.Count-1].Functions.Count>0)
                {
                    for (int i = 0; i < TEST._Fuzzy_sets[TEST._Fuzzy_sets.Count - 1].Functions.Count; i++)
                    {

                        float L_x1 = TEST._Fuzzy_sets[TEST._Fuzzy_sets.Count - 1].Functions[i].Left_side.A.X;
                        float L_x2 = TEST._Fuzzy_sets[TEST._Fuzzy_sets.Count - 1].Functions[i].Left_side.B.X;
                        float R_x1 = TEST._Fuzzy_sets[TEST._Fuzzy_sets.Count - 1].Functions[i].Right_side.A.X;
                        float R_x2 = TEST._Fuzzy_sets[TEST._Fuzzy_sets.Count - 1].Functions[i].Right_side.B.X;
                        if (L_x1 > L_x2 || L_x2 > R_x1 || R_x1 > R_x2)
                        {
                            MessageBox.Show("Ошибка: не все функции заданы");
                            return;
                        }
                    }
                    this.Close();
                    Create_file(TEST);
                }
                else
                    MessageBox.Show("Ошибка: не все функции заданы");
            }

            void button_back_click(object sender, EventArgs e)
            {
                this.Close();
                Form_Scales FH = new Form_Scales(TEST);
            }
        }

        private void Button_Show_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Find_max_and_min(out float max, out float min))
                    return;
                DrawFunc();
                for (int i = 0; i < textBox_left_x1.Count; i++)
                {
                    if (textBox_left_x1[i].Text == "" || textBox_left_x2[i].Text == "" || textBox_right_x1[i].Text == "" || textBox_right_x2[i].Text == "")
                        return;
                    float L_x1 = Convert.ToSingle(textBox_left_x1[i].Text);
                    float L_x2 = Convert.ToSingle(textBox_left_x2[i].Text);
                    float R_x1 = Convert.ToSingle(textBox_right_x1[i].Text);
                    float R_x2 = Convert.ToSingle(textBox_right_x2[i].Text);
                    if (L_x1 > L_x2 || L_x2 > R_x1 || R_x1 > R_x2)
                    {
                        MessageBox.Show($"Ошибка: В строке {Convert.ToString(i)}, все элементы должны быть в порядке возрастения!");
                        return;
                    }

                    DrawLine(new PointF(Convert.ToSingle(textBox_left_x1[i].Text), 0), new PointF(Convert.ToSingle(textBox_left_x2[i].Text), 1), min, max);

                    DrawLine(new PointF(Convert.ToSingle(textBox_left_x2[i].Text), 1), new PointF(Convert.ToSingle(textBox_right_x1[i].Text), 1), min, max);

                    DrawLine(new PointF(Convert.ToSingle(textBox_right_x1[i].Text), 1), new PointF(Convert.ToSingle(textBox_right_x2[i].Text), 0), min, max);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка: элемент задан неверно! ");
            }
        }
    }
}