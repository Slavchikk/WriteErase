using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteErase
{
    public partial class Product
    {
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
    }
}

    
