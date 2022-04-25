using GroceriesApi.Models;

namespace GroceriesApi.Repositories
{
    public class GroceriesRepository : IGroceriesRepository
    {

        private static readonly Store _context = new Store();

        private static int Identifier = 0;

        public IEnumerable<Item> GetItemsAsync()
        {
            return _context.Items;
        }

        public void AddItem(Item item)
        {
            item.Id = Identifier;

            Identifier = Identifier + 1;

            _context.Items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            _context.Items.RemoveAll(i => i.Id == item.Id);

            _context.Items.Add(item);
        }

        public void Delete(int id)
        {
            _context.Items.RemoveAll(i => i.Id == id);
        }
    }
}