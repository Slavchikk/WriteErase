﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WriteErase.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public bool capth = false; //при входе исп каптчу да или нет
        public AutorizationPage()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            
                User user = Base.EM.User.FirstOrDefault(z => z.UserLogin == Tblogin.Text);
                if (user == null)
                {
                    MessageBox.Show("Вы не зарегистрированы");

                }
                else if (user.UserPassword == TbPasReg.Password)
                {
                FrameClass.MainFrame.Navigate(new Pages.ListProduct(user));

            }
                else
                {
                    MessageBox.Show("Пароль неверен");
                    capth = true;
                }
            
           
        }

        private void EnterHowGuess_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new Pages.ListProduct());
        }
    }
}