using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodies.Models;

namespace Foodies.Services
{
    public class WebDataStorage : IDataStore<FoodItem>
    {
        readonly List<FoodItem> items;

        public WebDataStorage()
        {
            items = new List<FoodItem>()
            {
                new FoodItem { ID = 12, Name = "Pollo", IconID = 0, isPurchasedEveryTime = true, UnitsID = 1  },
                new FoodItem { ID = 5548, Name = "Aceite", IconID = 2, isPurchasedEveryTime = false, UnitsID = 2  },
                new FoodItem { ID = 12, Name = "1", IconID = 0, isPurchasedEveryTime = true, UnitsID = 1  },
                new FoodItem { ID = 5548, Name = "12", IconID = 2, isPurchasedEveryTime = false, UnitsID = 2  },
                new FoodItem { ID = 12, Name = "123", IconID = 0, isPurchasedEveryTime = true, UnitsID = 1  },
                new FoodItem { ID = 5548, Name = "1234", IconID = 2, isPurchasedEveryTime = false, UnitsID = 2  },
                new FoodItem { ID = 12, Name = "12345", IconID = 0, isPurchasedEveryTime = true, UnitsID = 1  },
                new FoodItem { ID = 5548, Name = "123456", IconID = 2, isPurchasedEveryTime = false, UnitsID = 2  },
                new FoodItem { ID = 12, Name = "1234567", IconID = 0, isPurchasedEveryTime = true, UnitsID = 1  },
                new FoodItem { ID = 5548, Name = "12345678", IconID = 2, isPurchasedEveryTime = false, UnitsID = 2  },
                new FoodItem { ID = 12, Name = "123456789", IconID = 0, isPurchasedEveryTime = true, UnitsID = 1  },
                new FoodItem { ID = 5548, Name = "12345678910", IconID = 2, isPurchasedEveryTime = false, UnitsID = 2  },
                new FoodItem { ID = 12, Name = "1234567891011", IconID = 0, isPurchasedEveryTime = true, UnitsID = 1  },
                new FoodItem { ID = 5548, Name = "Aceite", IconID = 2, isPurchasedEveryTime = false, UnitsID = 2  }
            };
        }

        public async Task<bool> AddItemAsync(FoodItem item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(FoodItem item)
        {
            var oldItem = items.Where((FoodItem arg) => arg.ID == item.ID).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((FoodItem arg) => arg.ID == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<FoodItem> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<FoodItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}