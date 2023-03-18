using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WriteErase.Pages;
using static System.Net.Mime.MediaTypeNames;

namespace WriteErase.windows
{
    /// <summary>
    /// Логика взаимодействия для создание поле каптча
    /// </summary>
    public partial class captcha : Window
    {
        string word = "";

        int count = 0;
        /// <summary>
        /// Создание каптча
        /// </summary>
        public captcha()
        {
            InitializeComponent();
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            // Создаем генератор случайных чисел.
            Random rand = new Random();
            List<string> lstWords = new List<string>();
            // Делаем слова.
            count = 4;
            int wordOrNum = 0;
            int randNum = 0;
            for (int j = 1; j <= count; j++)
            {
                wordOrNum = rand.Next(1, 3);
                // Выбор случайного числа от 0 до 25
                // для выбора буквы из массива букв.
                if (wordOrNum == 1)
                {
                    int letter_num = rand.Next(0, letters.Length - 1);

                    // Добавить письмо.
                    word += letters[letter_num];
                }
                else
                {
                    randNum = rand.Next(0, 9);
                    word += randNum.ToString();
                }
            }
            char[] arrCh = word.ToCharArray();

            int widhts = 0;
            int heiugh = 0;
            int maxRastWid = 0;
            maxRastWid = (int)(250 / count);
            int pred = 0;
            int sled = 0;
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    widhts = rand.Next(0, maxRastWid);
                    pred = maxRastWid;
                }
                else
                {
                    sled = pred + maxRastWid;
                    widhts = rand.Next(pred, sled);
                    if (widhts - pred < 15 && widhts + 15 < 250) // чтобы было видно расстояние в случае если оно слишком мало
                    {
                        widhts += 15;
                    }
                    pred = widhts;
                }
                heiugh = rand.Next(0, 100);

               
                    TextBlock txt1 = new TextBlock()
                    {
                        Text = arrCh[i].ToString(),
                        Padding = new Thickness(widhts, heiugh, 0, 0),
                        FontSize = 26,
                        FontStyle = FontStyles.Italic,


                    };
                    captch.Children.Add(txt1);

            }
            Random rnd = new Random();
            Line l4 = new Line()
            {
                X1 = rnd.Next(0, 100),
                Y1 = rnd.Next(0, 100),
                X2 = rnd.Next(0, 300),
                Y2 = rnd.Next(0, 200),
                Stroke = Brushes.Black,
            };


            captch.Children.Add(l4); // добавление линии внутрь контейнера Canvas


        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (tbCode.Text == word)
            {
                AutorizationPage.capth = true;
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}
