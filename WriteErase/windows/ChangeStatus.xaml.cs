using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
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
    /// Логика взаимодействия для ChangeStatus.xaml
    /// </summary>
    public partial class ChangeStatus : Window
    {
        Order order;
        public ChangeStatus(Order order)
        {
            InitializeComponent();
            this.order = order;
            cbStat.ItemsSource = Base.EM.OrderStatus.ToList();
            cbStat.SelectedValuePath = "OrderStatusID";
            cbStat.DisplayMemberPath = "OrderStatus1";
            cbStat.SelectedValue = order.OrderStatusID;
        }

       

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                order.OrderStatusID = cbStat.SelectedIndex + 1;
                Base.EM.SaveChanges();
                MessageBox.Show("Статус изменен");
                this.Close();
               
            }
            catch
            {
                MessageBox.Show("Ошибка  при изменении статуса");
            }
        }

       
        
    }
}
