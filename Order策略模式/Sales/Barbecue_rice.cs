using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace order.Sales
{
    internal class Barbecue_rice : Discount
    {
        public Barbecue_rice() : base() { }



        public override void Operation(List<Subtotal> subtotal_list)
        {

            subtotal_list.RemoveAll(x => (x.Name.Contains("贈送")));

            subtotal_list.ForEach(eachFood =>
            {
                eachFood.total = eachFood.price * eachFood.count;
            });


            Subtotal item = subtotal_list.Where(x => x.Name == "烤肉飯").FirstOrDefault();
            if ((item != null) && (item.count >= 2))
            {
                Subtotal free = new Subtotal("烤肉飯(贈送)", 0, item.count / 2, 0);
                subtotal_list.Add(free);
            }
            else
            {
                Subtotal free = subtotal_list.Where(x => x.Name == "烤肉飯(贈送)").FirstOrDefault();
                if (free != null)
                {
                    subtotal_list.Remove(free);
                }
            }
        }
    }
}
