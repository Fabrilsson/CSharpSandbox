using System.ComponentModel.DataAnnotations;

namespace GroceriesApi.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set;}

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Value { get; set; }

        public Item()
        {
            
        }

        public Item(string name, int quantity, decimal value)
        {
            Name = name;
            Quantity = quantity;
            Value = value;
        }        
    }
}