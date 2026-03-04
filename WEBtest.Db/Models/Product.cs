namespace WEBtest.Db.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string? Description { get; set; }

        public string? PhotoPath { get; set; } //= "/img/anyProduct.png";

        public Byte[]? jpeg { get; set; } = { };

        public List<CartItem>? CartItems { get; set; }

        public string? Article { get; set; }

        public string? Barcode { get; set; }

        public string? Category { get; set; }

        public int? Storage_Ozon { get; set; }

        public int? Storage_FBS1 { get; set; }

        public int? Cost_price { get; set; }

        public int? Costs_Ozon { get; set; }

        public int? Margin_FBO1 { get; set; }

        public int? Margin_FBS1 { get; set; }

        //public List<Image> Images { get; set; }

        /*public Product() { }

        public Product(int id, string name, decimal cost, string? description)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
        }

        public Product()
        {
            CartItems = [];
            Images = [];
        }*/
    }
}
