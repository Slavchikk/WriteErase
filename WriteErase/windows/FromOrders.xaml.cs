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

namespace WriteErase.windows
{
    /// <summary>
    /// Логика взаимодействия для FromOrders.xaml
    /// </summary>
    public partial class FromOrders : Window
    {
        List<ProductOrders> productOrders;
        public FromOrders(List<ProductOrders> productOrders)
        {
            InitializeComponent();
            this.productOrders = productOrders;
            listProductOrders.ItemsSource = productOrders;
            conclusionShow();
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

    }
}
