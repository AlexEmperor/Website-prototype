using System.Xml.Linq;
using WEBtest.Interfaces;
using WEBtest.Models;

namespace WEBtest.Repositories
{
    public class InMemoryComparisonRepository : IComparisonRepository
    {
        private readonly List<ComparisonViewModel> _comparisons = [];

        public ComparisonViewModel? TryGetByUserId(string userId)
        {
            return _comparisons.FirstOrDefault(cart => cart.UserId == userId);
        }

        public void Add(ProductViewModel product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null)
            {
                existingCart = new ComparisonViewModel()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = [product]
                };
                _comparisons.Add(existingCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(item => item.Id == product.Id);
                if (existingCartItem == null)
                {
                    existingCart.Items.Add(product);
                }
            }
        }

        public void Delete(ProductViewModel? product, string userId)
        {
            var existingCart = TryGetByUserId(userId);

#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            var existingCartItem = existingCart?.Items
                .FirstOrDefault(item => item.Id == product.Id);
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
            if (existingCart != null)
            {
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                existingCart.Items.Remove(existingCartItem);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            }
        }

        public void Clear(string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart != null)
            {
                _comparisons.Remove(existingCart);
            }
        }
    }
}
