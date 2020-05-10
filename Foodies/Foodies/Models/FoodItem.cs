using System;
using System.Collections.Generic;
using System.Text;

namespace Foodies.Models
{
    public class FoodItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int IconID { get; set; }
        public int UnitsID { get; set; }
        public bool isPurchasedEveryTime { get; set; }
    }
}
