namespace WEBtest.Db.Models
{
    public class OrderFurniture
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string OrderPlace { get; set; }
        public string Provider { get; set; }

        public DateTime OrderCreationDateTime { get; set; }
        public DateTime OrderDeliveryDateTime { get; set; }

        public int Volume { get; set; }

        public int? FurnituresId { get; set; }
        public Furniture? Furnitures { get; set; }



    }
}
