using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order策略模式.Models
{
    internal class MenuModel
    {
        public Menu[] Menus { get; set; }
        public Discount[] Discounts { get; set; }

        public class Menu
        {
            public string FoodType { get; set; }
            public Food[] Foods { get; set; }
        }

        public class Food
        {
            public string Name { get; set; }
            public int Price { get; set; }
        }

        public class Discount
        {
            public string Title { get; set; }
            public string Strategy { get; set; }
            public Condition[] Conditions { get; set; }
            public Award[] Award { get; set; }
        }

        public class Condition
        {
            public string[] Product { get; set; }
            public int Count { get; set; }
            public int Price { get; set; }
        }

        public class Award
        {
            public string[] Product { get; set; }
            public int Count { get; set; }
            public string Type { get; set; }
            public int Price { get; set; }
            public float Ratio { get; set; }
            public int Discount { get; set; }
        }

    }
}
