namespace GroceriesApi.Models
{
    public class Store
    {
        public List<Item> Items { get; set; }

        public Store()
        {
            Items = new List<Item>();
        }
    }
}