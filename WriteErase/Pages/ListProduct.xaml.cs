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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WriteErase.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListProduct.xaml
    /// </summary>
    public partial class ListProduct : Page
    {
        List<Product> products;
        User users;
        public ListProduct()
        {
            InitializeComponent();
            SortOrFilt();
            var brush = new SolidColorBrush(Color.FromArgb(255, 73, 140, 81));
            MainTitle.Foreground = brush;
            TbFIO.Text = "Гость";
            brush = new SolidColorBrush(Color.FromArgb(255, 118, 227, 133));
            goOrder.Background = brush;
        }
        public ListProduct(User user)
        {
            InitializeComponent();
            SortOrFilt();
            var brush = new SolidColorBrush(Color.FromArgb(255, 73, 140, 81));
            MainTitle.Foreground = brush;
            TbFIO.Text = user.UserName + "  " +  user.UserSurname + "  " + user.UserPatronymic;
            brush = new SolidColorBrush(Color.FromArgb(255, 118, 227, 133));
            goOrder.Background = brush;
            users = user;
        }

        private void SortOrFilt()
        {
            products = Base.EM.Product.ToList();
            TbFirst.Text = products.Count.ToString();

            if (CBDiscount.SelectedIndex != 0) //фильтрация
            {
                switch (CBDiscount.SelectedIndex)
                {
                    case 1:
                        {
                            products = Base.EM.Product.Where(x => x.ProductDiscountAmount >= 0 && x.ProductDiscountAmount < 10).ToList();
                        }
                        break;
                    case 2:
                        {
                            products = Base.EM.Product.Where(x => x.ProductDiscountAmount >= 10 && x.ProductDiscountAmount < 15).ToList();
                        }
                        break;
                    case 3:
                        {
                            products = Base.EM.Product.Where(x => x.ProductDiscountAmount >=15).ToList();
                        }
                        break;
                 
                }
            }
            else if (CBDiscount.SelectedIndex != -1)
            {
                products = Base.EM.Product.ToList();
            }



            if ((CBSort.SelectedIndex != -1)) //сортировка
            {

                if (CBSort.SelectedIndex == 0)
                {
                    products = products.OrderBy(x => x.ProductCost).ToList();
                }
                else
                {
                    products = products.OrderByDescending(x => x.ProductCost).ToList();
                }


            }



            if (!string.IsNullOrWhiteSpace(TbFindTitle.Text))//По названию
            {
                products = products.Where(x => x.ProductName.ToLower().Contains(TbFindTitle.Text.ToLower())).ToList();
            }
           

            TbSecond.Text = products.Count.ToString();
            // listTable.ItemsSource = services;
            listProduct.ItemsSource = products;
        }

        private void cbSort_Chang(object sender, SelectionChangedEventArgs e)
        {
            SortOrFilt();
        }

        private void TbFindTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            SortOrFilt();
        }

        private void cbFiltr_Chang(object sender, SelectionChangedEventArgs e)
        {
            SortOrFilt();
        }

        private void TBCost_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock textB = (TextBlock)sender;
            if (textB.Uid != null)
            {
                textB.Visibility = Visibility.Visible;
            }
            else
            {
                textB.Visibility = Visibility.Collapsed;
            }
        }

        private void goOrder_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new Pages.Orders(users));
        }
    }
}
