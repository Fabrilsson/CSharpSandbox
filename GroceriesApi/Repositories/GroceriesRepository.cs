using GroceriesApi.Models;
using GroceriesApi.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace GroceriesApi.Repositories;

public class GroceriesRepository : IGroceriesRepository
{

    private readonly DatabaseContext _context;

    public GroceriesRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
        return await _context.Items.ToListAsync();
    }

    public void AddItem(Item item)
    {
        _context.Items.Add(item);
    }

    public void UpdateItem(Item item)
    {
        _context.Items.Update(item);
    }
}