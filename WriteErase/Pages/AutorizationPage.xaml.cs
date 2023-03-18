using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WriteErase.windows;

namespace WriteErase.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public static bool capth = false; //при входе исп каптчу да или нет
        int countError;
       
        int countSek; // Время для получения кода
        DispatcherTimer distTimer = new DispatcherTimer();
        public AutorizationPage()
        {
            InitializeComponent();
            distTimer.Interval = new TimeSpan(0, 0, 1); 
            distTimer.Tick += new EventHandler(DisTimer_Tick);
        }
        private void DisTimer_Tick(object sender, EventArgs e)
        {
            if (countSek == 0) // Если 10 секунд закончились
            {
                btnEnter.IsEnabled = true;
                distTimer.Stop();
                tbTime.Visibility = Visibility.Collapsed;
            }
            else
            {
                tbTime.Text = "получить код можно через " + countSek + " секунд";
            }
            countSek--;
        }
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            
            User user = Base.EM.User.FirstOrDefault(z => z.UserLogin == Tblogin.Text && z.UserPassword==TbPasReg.Password);
            if (user == null)
            {
                MessageBox.Show("НЕудачный вход");
                capth = false;
                captcha captcha = new captcha();
                captcha.ShowDialog();
                countError++;
                if (!capth) 
                {
                    btnEnter.IsEnabled = false;
                    countSek = 10;
                    tbTime.Text = "Получить код можно через " + countSek + " секунд";
                    tbTime.Visibility = Visibility.Visible;
                    distTimer.Start();
                }
            }
            else if (user != null)
            {
                if (countError == 0)
                {                
                 FrameClass.MainFrame.Navigate(new Pages.ListProduct(user));                  
                }
                else
                {
                    captcha captcha = new captcha();
                    captcha.ShowDialog();
                    if (capth) 
                    {
                        FrameClass.MainFrame.Navigate(new ListProduct(user));
                    }
                }
            }
            
            
           
        }

        private void EnterHowGuess_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new Pages.ListProduct());
        }
    }
}
