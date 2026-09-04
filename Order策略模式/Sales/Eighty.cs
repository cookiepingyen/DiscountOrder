using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace order.Sales
{
    internal class Eighty : Discount
    {

        public Eighty() : base() { }


        public override void Operation(List<Subtotal> subtotal_list)
        {
            subtotal_list.ForEach(eachFood =>
            {
                eachFood.total = eachFood.count * eachFood.price * 8 / 10;
            });

        }

    }
}
