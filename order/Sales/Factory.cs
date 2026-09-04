using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace order.Sales
{
    internal class Factory
    {
        public static Discount GetDiscount(ComboBox comboBox1, List<Subtotal> subtotal_list)
        {
            Discount discount = null;
            switch (comboBox1.Text)
            {
                case "雞腿飯送蘿蔔湯":
                    discount = new Chicken(subtotal_list);
                    break;
                case "烤肉飯買二送一":
                    discount = new Barbecue_rice(subtotal_list);
                    break;
                case "打八折":
                    discount = new Eighty(subtotal_list);
                    break;
                case "打九折":
                    discount = new Ninety(subtotal_list);
                    break;
            }
            return discount;
        }
    }
}
