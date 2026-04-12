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

        public void Add(ProductViewModel product, string userId,string login)
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

#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            var existingCartItem = existingCart?.Items
                .FirstOrDefault(item => item.Product.Id == product.Id);
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
            if (existingCart == null)
            {
                return;
            }

#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            existingCartItem.Quantity -= 1;
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
            
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

