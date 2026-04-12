using WEBtest.Db.Models;

namespace WEBtest.Models
{
    public class OrderFurnitureViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string OrderPlace { get; set; }
        // Навигационные свойства
        public List<Product>? Products { get; set; }
        public List<OrderFurniture>? OrderFurnitures { get; set; } // Many-to-Many
        public List<OrderFurnitureItem> OrderItems { get; set; } = [];


    }
}
