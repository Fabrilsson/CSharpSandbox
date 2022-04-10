using GroceriesApi.Models;

namespace GroceriesApi.Repositories;

public interface IGroceriesRepository
{
    Task<IEnumerable<Item>> GetItemsAsync();

    void AddItem(Item item);

    void UpdateItem(Item item);

     Task Delete(int Id);
}