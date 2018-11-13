using System;
using System.Drawing;
using System.Windows.Forms;
namespace ASCPR
{
    static class Design
    {
        public static int Button_width { get; set; }
        public static int Button_hight { get; set; }
        public static Image Background { get; set; }
        public static Image Background_button { get; set; }
        public static Image Background_button_true { get; set; }
        public static Image Background_button_touch { get; set; }
        public static Image Background_button_add { get; set; }
        public static Image Background_button_remove { get; set; }
        public static Font Font_button { get; set; }
        public static Font Font_heading { get; set; }
        public static Font Font_text { get; set; }
        public static Color Font_color { get; set; }

        public static void Loading(string path, string theme = "")
        {
            try
            {
                Font_button = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                Font_heading = new Font("Arial", 13F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
                Font_text = new Font("Arial", 13F); //new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                Button_width = 120;
                Button_hight = 40;
                if (theme == "dark")
                {
                    
                    Background = new Bitmap($"{path}\\background_dark.png");
                    Background_button = new Bitmap($"{path}\\buttonBeforeClicking.png");
                    Background_button_true = new Bitmap($"{path}\\button_true.png");
                    Background_button_touch = new Bitmap($"{path}\\button_touch.png");
                    Background_button_add = new Bitmap($"{path}\\add.png");
                    Background_button_remove = new Bitmap($"{path}\\remove.png");
                    Font_color = Color.Honeydew;
                    return;
                }
                Background = null;
                Background_button = null;
                Background_button_touch = null;
                Background_button_true = new Bitmap($"{path}\\button_true.png");
                Background_button_add = new Bitmap($"{path}\\add.png");
                Background_button_remove = new Bitmap($"{path}\\remove.png");
                Font_color = Color.Black;
            }
            catch 
            {
                MessageBox.Show("Ошибка: тема не загружена!");
                Background = null;
                Background_button = null;
                Background_button_touch = null;
                Background_button_true = null;
                Font_color = Color.Black;
            }
        }

        public static void Design_for_button(Button but)
        {
            but.Font = Font_button;
            //but.AutoSize = true;
            if (Background_button == null)
                return;
            but.BackgroundImage = Background_button;
            but.ForeColor = Font_color;
            but.BackgroundImageLayout = ImageLayout.Stretch;
            but.BackColor = Color.Transparent;
            but.FlatStyle = FlatStyle.Flat;
            but.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            but.FlatAppearance.BorderSize = 0;
            but.MouseEnter += new EventHandler(Button_Light);
            but.MouseLeave += new EventHandler(Button_Extinct);
            void Button_Light(object sender, EventArgs e)// создание файла и начала тестирования 
            {
                if ((sender as Button).BackgroundImage != Background_button_true)
                    (sender as Button).BackgroundImage  = Background_button_touch;
            }
            void Button_Extinct(object sender, EventArgs e)// создание файла и начала тестирования 
            {
                if ((sender as Button).BackgroundImage != Background_button_true)
                    (sender as Button).BackgroundImage  = Background_button;
            }
        }

        public static void Design_for_label(Label lab)
        {
            lab.Font = Font_heading;
            lab.ForeColor = Font_color;
            lab.BackColor = Color.Transparent;
        }

        public static void Design_for_checkbox(CheckBox CB)
        {
            CB.Font = Font_heading;
            CB.ForeColor = Font_color;
            CB.BackColor = Color.Transparent;
        }

        public static void Design_for_textbox(TextBox lab)
        {
            lab.Font = Font_text;
        }
    }
}
