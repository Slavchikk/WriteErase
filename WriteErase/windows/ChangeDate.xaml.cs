using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для ChangeDate.xaml
    /// </summary>
    public partial class ChangeDate : Window
    {
        Order order;
        public ChangeDate(Order order)
        {
            InitializeComponent();
            this.order = order;

            dpDate.SelectedDate = order.OrderDeliveryDate;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                order.OrderDeliveryDate = (DateTime)dpDate.SelectedDate;
                Base.EM.SaveChanges();
                MessageBox.Show("Дата изменена");
                this.Close();
                
            }
            catch
            {
                MessageBox.Show("Ошибка при изменении даты");
            }
        }
    }
}
