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
    /// <summary>
    /// TODO SHIT CODE
    /// </summary>
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.BackgroundImage = Design.Background;
            this.Show();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            try
            {
                listBox_tests.Items.Clear();
                List<string> names = new List<string>(Additional_functions.Get_filenames(Setting.tests_path));
                for (int i = 0; i < names.Count; i++)
                    listBox_tests.Items.Add(names[i]);
            }
            catch
            {
                MessageBox.Show("Ошибка: БД тестов не найдена");
                this.Close();
                return;
            }
        }

        private void ListBox_tests_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_tests.SelectedIndex >= 0)
            {
                string name = listBox_tests.SelectedItem.ToString();
                Test TEST = new Test();
                TEST.Creat_test($"{name}.txt");
                Form_header AddForm = new Form_header(TEST);
                this.Close();
            }
        }
    }
}

  