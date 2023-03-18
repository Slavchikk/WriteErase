using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WriteErase
{
    public partial class Product
    {
        public double DiscPriceDouble
        {
            get
            {
               

                    double onePers = Convert.ToDouble(ProductCost) / 100;
                    double price = Convert.ToDouble(ProductCost) - onePers * (Convert.ToDouble(ProductDiscountAmount));
                    return price;
                
               
            }
        }
        public string DiscPrice
        {
            get
            {
                if (ProductDiscountAmount != null)
                {

                    double onePers = Convert.ToDouble(ProductCost) / 100;
                    double price = Convert.ToDouble(ProductCost) - onePers * (Convert.ToDouble(ProductDiscountAmount));
                    return price.ToString();
                }
                else
                {
                    return Convert.ToString(ProductCost);
                }
            }
        }
       
        public SolidColorBrush DiscountColor 
        {
            get
            {
                if (ProductDiscountAmount != null && ProductDiscountAmount>15)
                {
                    SolidColorBrush mushThen15 = new SolidColorBrush(Color.FromRgb(127, 255, 0));
                    return mushThen15;
                }
                else
                {
                    SolidColorBrush notMushThen15 = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    return notMushThen15;
                }
            }
        }
    }
}

    
