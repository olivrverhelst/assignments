using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace UiS.Dat240.Lab2
{
    public interface IFoodItemProvider
    {
        Task<FoodItem[]> GetItems();
        Task AddFoodItem(FoodItem item);
        Task<FoodItem> GetFoodItem(int id);
        Task UpdateFoodItem(int id, FoodItem item);
        Task RemoveFoodItem(int id);

    }

    public class FoodItemProvider : IFoodItemProvider
    {
        private readonly ShopContext _provider;


        public FoodItemProvider(ShopContext provider)
        {
            _provider = provider;
        }

        public async Task AddFoodItem(FoodItem item)
        {
            _provider.Add(item);
            await _provider.SaveChangesAsync();

            await Task.Delay(200);
            Console.WriteLine(item.Name);
        }

        public async Task<FoodItem> GetFoodItem(int id)
        {
            return await _provider.FoodItems.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<FoodItem[]> GetItems()
        {
            return await _provider.FoodItems.ToArrayAsync();
        }

        public async Task RemoveFoodItem(int id)
        {
            _provider.Remove(_provider.FoodItems.Single(a => a.Id == id));
            await _provider.SaveChangesAsync();
        }

        public async Task UpdateFoodItem(int id, FoodItem item)
        {
            //id for sjekk ?
            _provider.Update(item);
            await _provider.SaveChangesAsync();
            //throw new NotImplementedException();
        }


    }

}