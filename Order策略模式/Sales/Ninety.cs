using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace order.Sales
{
    internal class Ninety : Discount
    {

        public Ninety() : base() { }

        public override void Operation(List<Subtotal> subtotal_list)
        {
            subtotal_list.ForEach(eachFood =>
            {
                eachFood.total = eachFood.count * eachFood.price * 9 / 10;
            });
        }


    }
}
