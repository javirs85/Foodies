using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Foodies.Models;
using Foodies.Views;
using Foodies.Services;

namespace Foodies.ViewModels
{
    public class IngredientListViewModel : BaseViewModel
    {
        public ObservableCollection<FoodItem> Ingredients { get; set; }
        public Command LoadIngredientsCommand { get; set; }

        public IngredientListViewModel()
        {
            Ingredients = new ObservableCollection<FoodItem>();
            LoadIngredientsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<IngredientSelectorPage, FoodItem>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as FoodItem;
                Ingredients.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Ingredients.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Ingredients.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}