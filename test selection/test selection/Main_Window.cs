using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASCPR
{
    public partial class ASPD : Form
    {
        public ASPD()
        {                  
            InitializeComponent();
            Design.Design_for_button(button_update);
            Design.Design_for_button(button_testing);
            Design.Design_for_button(button_new_test);
            Design.Design_for_button(button_Test_change);
            BackgroundImage = Design.Background;
            Button_update_Click(null, null); // добавляем всё на форму
        }
        private void ListBox_test_results_SelectedIndexChanged(object sender, System.EventArgs e) // open result in new window
        {
            if (listBox_test_results.SelectedIndex >= 0)
            { 
                string curItem = listBox_test_results.SelectedItem.ToString();
                View_Form View_text = new View_Form(Setting.database_path + "\\" + curItem + ".txt");
            }
        }

        private void Button_testing_Click(object sender, EventArgs e) // new testing
        {
            Test_selection FormCreate = new Test_selection();
        }

        private void Button_update_Click(object sender , EventArgs e) // update Listbox
        {
            try
            {
                listBox_test_results.Items.Clear();
                List<string> names = new List<string>(Additional_functions.Get_filenames(Setting.database_path));
                for (int i = 0; i < names.Count; i++)
                    listBox_test_results.Items.Add(names[i]);
            }
            catch
            {
                MessageBox.Show("Ошибка: БД результатов не найдена");
                return;
            }
        }

        private void Add_new_test_Click(object sender, EventArgs e)//add new test
        {
            Test TEST = new Test(); 
            Form_header AddForm = new Form_header(TEST);
        }

        private void Button_Test_change_Click(object sender, EventArgs e)
        {
            Form3 test_change = new Form3();
        }
    }
}
