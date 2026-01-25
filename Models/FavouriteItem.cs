namespace WEBtest.Models
{
    public class FavouriteItem
    {
        public Guid Id { get; set; }
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }
        public decimal Cost => Product.Cost * Quantity;
    }
}
