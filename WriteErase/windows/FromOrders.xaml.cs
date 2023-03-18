using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net.Sockets;
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

namespace WriteErase.windows
{
    /// <summary>
    /// Логика взаимодействия для FromOrders.xaml
    /// </summary>
 
    public partial class FromOrders : Window
    {
        User user;
        List<ProductOrders> productOrders;
        /// <summary>
        /// Метод дли инициализации списка заказов
        /// </summary>
        /// <param name="productOrders"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public FromOrders(List<ProductOrders> productOrders, User user)
        {
            InitializeComponent();
            this.productOrders = productOrders;
            listProductOrders.ItemsSource = productOrders;
            conclusionShow();
            cbPoint.ItemsSource = Base.EM.PointIssue.ToList();
            cbPoint.SelectedValuePath = "PointIssueID";
            cbPoint.DisplayMemberPath = "PostCode";
            cbPoint.SelectedIndex = 0;
            this.user = user;
            if (user != null)
            {
                TbFIO.Text = "" + user.UserSurname + " " + user.UserName + " " + user.UserPatronymic;
            }
        }

        private void conclusionShow()
        {
            double sum = 0;
            double disc = 0;
          
            foreach (ProductOrders pr in productOrders)
            {
                sum += pr.count * pr.product.DiscPriceDouble;
                disc += pr.count * (Convert.ToDouble(pr.product.ProductCost) - pr.product.DiscPriceDouble); 
            }
            tbSum.Text = "Сумма заказа: " + sum.ToString("0.00") + " руб.";
            tbDisc.Text = "Сумма скидки: " + disc.ToString("0.00") + " руб.";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            ProductOrders products = productOrders.FirstOrDefault(x => x.product.ProductArticleNumberID == index);
            productOrders.Remove(products);
            if (productOrders.Count == 0)
            {
                this.Close();
            }
            conclusionShow();
            listProductOrders.Items.Refresh();
          
        }
           private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox tb = (TextBox)sender;
                int index = Convert.ToInt32(tb.Uid);
                ProductOrders products = productOrders.FirstOrDefault(x => x.product.ProductArticleNumberID == index);


                products.count = Convert.ToInt32(tb.Text);
                if (tb.Text.Replace(" ", "") == "") 
                {
                    products.count = 0;
                }
                if (products.count == 0)
                {
                    productOrders.Remove(products);
                }
                if (productOrders.Count == 0)
                {
                    this.Close();
                }
                conclusionShow();
            }
            catch
            {
                MessageBox.Show("при изменении количества произошла ошибка");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
