using Microsoft.Extensions.Hosting;
using System.Xml.Linq;
using WEBtest.Interfaces;
using WEBtest.Models;

namespace WEBtest.Repositories
{

    public class InMemoryCartRepository : ICartRepository
    {
        private readonly List<CartViewModel> _carts = [];

        public CartViewModel? TryGetByUserId(string userId)
        {
            return _carts.FirstOrDefault(cart => cart.UserId == userId);
        }

        public void Add(ProductViewModel product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null)
            {
                existingCart = new CartViewModel()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItemViewModel>()
                    {
                        new CartItemViewModel()
                        {
                            Id = Guid.NewGuid(),
                            Product = product,
                            Quantity = 1
                        }
                    }
                };
                _carts.Add(existingCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(item => item.Product.Id == product.Id);
                if (existingCartItem == null)
                {
                    var newCartItem = new CartItemViewModel()
                    {
                        Id = Guid.NewGuid(),
                        Product = product,
                        Quantity = 1
                    };
                    existingCart.Items.Add(newCartItem);
                }
                else
                {
                    existingCartItem.Quantity += 1;
                }
            }
        }

        public void Delete(ProductViewModel? product, string userId)
        {
            var existingCart = TryGetByUserId(userId);

            var existingCartItem = existingCart?.Items
                .FirstOrDefault(item => item.Product.Id == product.Id);
            if (existingCart == null)
            {
                return;
            }

            existingCartItem.Quantity -= 1;
            
            if (existingCartItem.Quantity == 0)
            {
                existingCart.Items.Remove(existingCartItem);
            }
        }

        public void Clear(string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart != null)
            {
                _carts.Remove(existingCart);
            }
        }
    }
}

