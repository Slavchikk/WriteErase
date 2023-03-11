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

namespace WriteErase.Pages
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Page
    {
        List<Order> orders;
        public Orders()
        {
            InitializeComponent();
            SortOrFilt();
        }
        public Orders(User user)
        {
            InitializeComponent();
            SortOrFilt();
        }
        private void SortOrFilt()
        {
            orders = Base.EM.Order.ToList();
           

            if (CBDiscount.SelectedIndex != 0) //фильтрация
            {
                switch (CBDiscount.SelectedIndex)
                {
                    case 1:
                        {
                           // orders = Base.EM.Order.Where(x => x.ProductDiscountAmount >= 0 && x.ProductDiscountAmount < 10).ToList();
                        }
                        break;
                    case 2:
                        {
                           // products = Base.EM.Product.Where(x => x.ProductDiscountAmount >= 10 && x.ProductDiscountAmount < 15).ToList();
                        }
                        break;
                    case 3:
                        {
                            //products = Base.EM.Product.Where(x => x.ProductDiscountAmount >= 15).ToList();
                        }
                        break;

                }
            }
            else if (CBDiscount.SelectedIndex != -1)
            {
               // products = Base.EM.Product.ToList();
            }



            //if ((CBSort.SelectedIndex != -1)) //сортировка
            //{

            //    if (CBSort.SelectedIndex == 0)
            //    {
            //        products = products.OrderBy(x => x.ProductCost).ToList();
            //    }
            //    else
            //    {
            //        products = products.OrderByDescending(x => x.ProductCost).ToList();
            //    }


            //}



           
            // listTable.ItemsSource = services;
           // listProduct.ItemsSource = products;
        }
        private void TBSostav_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;  // получаем доступ к TextBlock из шаблона
            int index = Convert.ToInt32(tb.Uid);
            List<OrderProduct> list = Base.EM.OrderProduct.Where(x=>x.OrderID== index).ToList();

            string text = "";

            int id = 0;
            foreach (OrderProduct tc in list)
            {
                id = tc.OrderProductID;
            }

            List<Product> hc = Base.EM.Product.Where(x => x.ProductArticleNumberID == id).ToList();

            string product = "";

            foreach (Product hcc in hc)
            {
                product = hcc.ProductName;
            }

            tb.Text = "Состав: " + product;
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
                    discount += Convert.ToDouble(hcc.ProductDiscountAmount);
                }
               
            }

        
           

            tb.Text = "Общая скидка заказа: " + discount;
        }

        private void cbSort_Chang(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbFiltr_Chang(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
