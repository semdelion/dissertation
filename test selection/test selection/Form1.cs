using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_selection
{
    public partial class Form1 : Form
    {
        void B_Click(object sender, EventArgs e)
        {
            Form2 FormCreate = new Form2((sender as Button).Text + ".txt");
            //FormCreate.Test((sender as Button).Text+".txt");
        }
        public Form1()
        {
            InitializeComponent();
            this.Show();
            this.SuspendLayout(); //// !!! достаточно хорошо оптимизировала вывод


            System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(Setting.location_tests); // открываем папку  и получаем имена всех файлов. 
            System.IO.DirectoryInfo[] dirs = info.GetDirectories();
            System.IO.FileInfo[] files = info.GetFiles();
            Button[] Testbutton = new Button[files.Length];
            Testbutton[0] = new Button
            {
                Text = files[0].Name.Remove(files[0].Name.Length - 4),
                Width = 300,
                Location = new Point((100)/2, 10)
            };
            Testbutton[0].Click += new EventHandler(B_Click);    
            this.Controls.Add(Testbutton[0]);
            for (int i = 1; i < files.Length; i++)
            {
                Testbutton[i] = new Button
                {
                    Width = 300,
                    Text = files[i].Name.Remove(files[i].Name.Length - 4)
                };
                ;
               Testbutton[i].Location = new Point((100) / 2, Testbutton[i - 1].Location.Y + Testbutton[i - 1].Height + 15);
               this.Controls.Add(Testbutton[i]);
               Testbutton[i].Click += new EventHandler(B_Click);
            }
            this.ResumeLayout(false);//!!! достаточно хорошо оптимизировала вывод  
        }
    }
}
