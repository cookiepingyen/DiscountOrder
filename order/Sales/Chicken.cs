using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace order.Sales
{
    internal class Chicken : Discount
    {
        public Chicken(List<Subtotal> subtotal_list) : base(subtotal_list) { }

        public override void Operation(List<Subtotal> subtotal_list)
        {
            subtotal_list.RemoveAll(x => (x.Name.Contains("贈送")));
            subtotal_list.ForEach(eachFood =>
            {
                eachFood.total = eachFood.price * eachFood.count;
            });
            //增加或刪除蘿蔔湯(贈送)
            Subtotal item = subtotal_list.Where(x => x.Name == "雞腿飯").FirstOrDefault();
            if ((item != null) && (item.count > 0))
            {
                Subtotal free = new Subtotal("蘿蔔湯(贈送)", 0, item.count, 0);
                subtotal_list.Add(free);
            }
            else
            {
                Subtotal free = subtotal_list.Where(x => x.Name == "蘿蔔湯(贈送)").FirstOrDefault();
                if (free != null)
                {
                    subtotal_list.Remove(free);
                }
            }
        }
    }
}
