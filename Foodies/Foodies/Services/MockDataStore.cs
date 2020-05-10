using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodies.Models;

namespace Foodies.Services
{
    public class MockDataStore : IDataStore<Ingredient>
    {
        readonly List<Ingredient> items;

        public MockDataStore()
        {
            items = new List<Ingredient>()
            {
                new Ingredient { Id =1, Name = "First item", Description="This is an item description." },
                new Ingredient { Id = 2, Name = "Second item", Description="This is an item description." },
                new Ingredient { Id = 3, Name = "Third item", Description="This is an item description." },
                new Ingredient { Id = 4, Name = "Fourth item", Description="This is an item description." },
                new Ingredient { Id = 5, Name = "Fifth item", Description="This is an item description." },
                new Ingredient { Id = 6, Name = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Ingredient item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Ingredient item)
        {
            var oldItem = items.Where((Ingredient arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Ingredient arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Ingredient> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Ingredient>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}