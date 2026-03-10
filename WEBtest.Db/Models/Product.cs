namespace WEBtest.Db.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string? Description { get; set; }

        public string? PhotoPath { get; set; } = "/img/anyProduct.png";

        public byte[]? Jpeg { get; set; } 

        public List<CartItem>? CartItems { get; set; }

        public int? FurnitureOrderId { get; set; }

        public OrderFurniture? FurnitureOrder { get; set; }

        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        public string? Article { get; set; } = "0";

        public string? Barcode { get; set; } = "0";

        public int? Storage_Ozon { get; set; }

        public int? Storage_FBS1 { get; set; }

        public int? Cost_price { get; set; }

        public int? Costs_Ozon { get; set; }

        public int? Margin_FBO1 { get; set; }

        public int? Margin_FBS1 { get; set; }
    }
}
