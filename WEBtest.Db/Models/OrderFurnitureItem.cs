namespace WEBtest.Db.Models
{
    public class OrderFurnitureItem
    {
        public int OrderFurnitureId { get; set; }
        public OrderFurniture OrderFurniture { get; set; }

        public int FurnitureId { get; set; }
        public Furniture Furniture { get; set; }

        public int Quantity { get; set; }
    }
}
