using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WriteErase
{
    public partial class Order
    {
        public SolidColorBrush CounyMuchThen3
        {
            get
            {
                SolidColorBrush notMushThen15 = new SolidColorBrush(Color.FromRgb(255, 255, 255));
           
                List<OrderProduct> products = Base.EM.OrderProduct.Where(x => x.OrderID == OrderID).ToList();
                int check = 0;
                int check1=0;
                for(int i =0;i<products.Count;i++)
                {
                   if(products[i].Count>3)
                    {
                        for(int j=0;j<products.Count;j++)
                        {
                            if (products[j].Count > 3)
                            {
                                check1 = 1;
                            }
                            else
                            {
                                check1 = 0;
                                break;
                            }
                        }
                        if(check1==1)
                        check = 1;
                    }
                   else if (products[i].Count==0)
                    {
                        for (int j = 0; j < products.Count; j++)
                        {
                            if (products[j].Count ==0)
                            {
                                check1 = 1;
                            }
                            else
                            {
                                check1 = 0;
                                break;
                            }
                        }
                        if (check1 == 1)
                            check = 2;
                    }
                }
               


                if (check == 1)
                {
                    SolidColorBrush mushThen15 = new SolidColorBrush(Color.FromRgb(32, 178, 170));
                    return mushThen15;
                }
               else if(check==2)
                {
                    SolidColorBrush mushThen15 = new SolidColorBrush(Color.FromRgb(255, 140, 0));
                    return mushThen15;
                }
                else
                {
                    return notMushThen15;
                }
               

            }
        }
    }
}
