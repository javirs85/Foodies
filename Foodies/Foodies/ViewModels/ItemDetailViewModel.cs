using System;

using Foodies.Models;

namespace Foodies.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public FoodItem Item { get; set; }
        public ItemDetailViewModel(FoodItem item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
