using Foodies.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Foodies.Models
{
    public enum Icons { meat, sugar};
    public enum Units { gramos, Kilos, mililitros, Litros, Unidades}

    public class FoodItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int IconID { get; set; }
        public int UnitsID { get; set; }
        public bool MustBeAdded
        {
            get {
                return isPurchasedEveryTime == "1";
            }
        }
        public string isPurchasedEveryTime { get; set; }

        public ImageSource Image
        {
            get
            {
                if (IconID == 0)
                    return ResourcesController.IconMeat;
                else
                    return ResourcesController.IconSugar;
            }
        }

        public Units Unit
        {
            get
            {
                return (Units)UnitsID;
            }
        }

        public string unitsShort
        {
            get
            {
                switch (Unit)
                {
                    case Units.gramos:
                        return "g";
                    case Units.Kilos:
                        return "Kg";
                    case Units.mililitros:
                        return "ml";
                    case Units.Litros:
                        return "L";
                    case Units.Unidades:
                        return "u";
                    default:
                        return "-";
                }
            }
        }
    }
}
