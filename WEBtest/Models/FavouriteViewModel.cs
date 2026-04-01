namespace WEBtest.Models
{
    public class FavouriteViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public ProductViewModel Product { get; set; }
        public List<ProductViewModel> Items { get; set; }
        public int Quantity { get; set; }
    }
}
