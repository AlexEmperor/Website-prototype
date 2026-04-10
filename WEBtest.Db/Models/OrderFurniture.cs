namespace WEBtest.Db.Models
{
    public class OrderFurniture
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string OrderPlace { get; set; }
        public List<Furniture> Furnitures { get; set; } = [];

        public string Provider { get; set; }

        public DateTime OrderCreationDateTime { get; set; }
        public DateTime OrderDeliveryDateTime { get; set; }
        public List<OrderFurnitureItem> Items { get; set; } = [];
    }
}
