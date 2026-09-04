using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace order.Sales
{
    abstract class Discount
    {
        ComboBox comboBox1;

        public Discount(List<Subtotal> subtotal_list)
        {

        }
        public abstract void Operation(List<Subtotal> subtotal_list);
    }
}
