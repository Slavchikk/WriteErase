using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using WriteErase.windows;

namespace WriteErase.Pages
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Page
    {
        List<Order> orders;
        double priceSort;
        User user;
        public Orders()
        {
            InitializeComponent();
            SortOrFilt();
           
        }
        public Orders(User user)
        {
            InitializeComponent();
            SortOrFilt();
            this.user = user;
        }
        private void SortOrFilt()
        {
            orders = Base.EM.Order.ToList();
             

            if (CBDiscount.SelectedIndex != -1) //фильтрация
            {
                switch (CBDiscount.SelectedIndex)
                {
                    case 0:
                        orders = Base.EM.Order.ToList();
                        break;
                    case 1:
                        {
                            orders = Base.EM.Order.Where(x => x.DiscPrice >= 0 && x.DiscPrice < 10).ToList();
                        }
                        break;
                    case 2:
                        {
                            orders = Base.EM.Order.Where(x => x.DiscPrice >= 10 && x.DiscPrice < 15).ToList();
                        }
                        break;
                    case 3:
                        {
                            orders = Base.EM.Order.Where(x => x.DiscPrice >= 15 ).ToList();
                        }
                        break;

                }
            }
            


            if ((CBSort.SelectedIndex != -1)) //сортировка
            {

                if (CBSort.SelectedIndex == 0)
                {
                    orders = orders.OrderBy(x => x.SumDisc).ToList();
                }

                else
                {
                    orders = orders.OrderByDescending(x => x.SumDisc).ToList();
                }


            }


            listOrder.ItemsSource = orders;
            if(orders.Count==0)
            {
                MessageBox.Show("Данные не найдены");
            }
          
        
        }
        private void TBSostav_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;  // получаем доступ к TextBlock из шаблона
            int index = Convert.ToInt32(tb.Uid);
            List<OrderProduct> orderProducts = Base.EM.OrderProduct.Where(x => x.OrderID == index).ToList();
            string compound = "";
            
            for (int i = 0; i < orderProducts.Count; i++)
            {
                    if (i == orderProducts.Count - 1)
                    {
                        compound = compound + orderProducts[i].Product.ProductName + " Количество: " + orderProducts[i].Count;
                    }
                    else
                    {
                        compound = compound + orderProducts[i].Product.ProductName + " Количество: " + orderProducts[i].Count + "; \n";
                    }
             }
            SolidColorBrush mushThen15 = new SolidColorBrush(Color.FromRgb(255, 140, 0));
            


            tb.Text = "Состав: " + compound;
        }

        private void TbSummPrice_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;  // получаем доступ к TextBlock из шаблона
            int index = Convert.ToInt32(tb.Uid);
            List<OrderProduct> list = Base.EM.OrderProduct.Where(x => x.OrderID == index).ToList();

            string text = "";


            List<int> id = new List<int>();
            double price = 0;
            foreach (OrderProduct tc in list)
            {
                id.Add(tc.ProductArticleNumberID);

            }
            for (int i = 0; i < id.Count; i++)
            {
                int d = id[i];
                List<Product> hc = Base.EM.Product.Where(x => x.ProductArticleNumberID == d).ToList();
                foreach (Product hcc in hc)
                {
                    price += Convert.ToDouble(hcc.ProductCost);
                }

            }
            tb.Text = "Общая сумма заказа "+ price + " руб.";
            priceSort = price;
        }

        private void TBSumDiscon_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;  // получаем доступ к TextBlock из шаблона
            int index = Convert.ToInt32(tb.Uid);
            List<OrderProduct> list = Base.EM.OrderProduct.Where(x => x.OrderID == index).ToList();

            string text = "";
            double discount = 0;

            List<int> id = new List<int>();
           
            foreach (OrderProduct tc in list)
            {
                id.Add(tc.ProductArticleNumberID);
                
            }
            for(int i=0; i < id.Count; i++)
            {
                int d = id[i];
                List<Product> hc = Base.EM.Product.Where(x => x.ProductArticleNumberID == d).ToList();
                foreach (Product hcc in hc)
                {
                    discount += Convert.ToDouble(hcc.ProductCost) - hcc.DiscPriceDouble;
                }
               
            }

        
           

            tb.Text = "Общая скидка заказа: " + discount;
        }

        private void cbSort_Chang(object sender, SelectionChangedEventArgs e)
        {
            SortOrFilt();
        }

        private void cbFiltr_Chang(object sender, SelectionChangedEventArgs e)
        {
            SortOrFilt();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new Pages.ListProduct(user));
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int index = Convert.ToInt32(btn.Uid);
            Order order = Base.EM.Order.FirstOrDefault(x => x.OrderID == index);
            ChangeStatus changeStatus = new ChangeStatus(order);
            changeStatus.ShowDialog();
        }

        private void btnChangeDate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int index = Convert.ToInt32(btn.Uid);
            Order order = Base.EM.Order.FirstOrDefault(x => x.OrderID == index);
            ChangeDate changeOrderDeliveryDate = new ChangeDate(order);
            changeOrderDeliveryDate.ShowDialog();
        }
    }
}
