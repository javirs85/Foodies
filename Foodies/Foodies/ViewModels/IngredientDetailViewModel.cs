using System;
using System.Collections.Generic;
using System.Linq;
using Foodies.Models;

namespace Foodies.ViewModels
{
    public class IngredientDetailViewModel : BaseViewModel
    {
        public List<string> unitsStr
        {
            get
            {
                return Enum.GetNames(typeof(Foodies.Models.Units)).ToList();
            }
        }
        public FoodItem Item { get; set; }
        public IngredientDetailViewModel(FoodItem item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
