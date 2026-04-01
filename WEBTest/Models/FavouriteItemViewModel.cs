using WEBtest.Db.Models;

namespace WEBtest.Models
{
    public class FavouriteItemViewModel
    {
        public Guid Id { get; set; }
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }
        public decimal Cost => Product.Cost * Quantity;
    }
}
