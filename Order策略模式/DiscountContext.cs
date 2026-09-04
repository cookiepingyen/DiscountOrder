using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace order.Sales
{
    internal class DiscountContext
    {
        private Discount discount = null;

        public DiscountContext(String type)
        {
            switch (type)
            {
                case "打八折":
                    discount = new Eighty();
                    break;
                case "打九折":
                    discount = new Ninety();
                    break;
                case "烤肉飯買二送一":
                    discount = new Barbecue_rice();
                    break;
                case "雞腿飯送蘿蔔湯":
                    discount = new Chicken();
                    break;
            }
        }


        public void Getresult(List<Subtotal> subtotal_list)
        {
            discount.Operation(subtotal_list);
        }


    }
}
