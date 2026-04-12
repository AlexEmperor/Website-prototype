using WEBtest.Db.Models;

namespace WEBtest.Models
{
    public class FavouriteItemViewModel
    {
        public Guid Id { get; set; }
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public ProductViewModel Product { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public int Quantity { get; set; }
        public decimal Cost => Product.Cost * Quantity;
    }
}
