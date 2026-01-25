using WEBtest.Interfaces;
using WEBtest.Models;

namespace WEBtest.Repositories
{
    public class InMemoryFavouriteRepository : IFavouriteRepository
    {
        private readonly List<FavouriteViewModel> _favourites = [];

        public FavouriteViewModel? TryGetByUserId(string userId)
        {
            return _favourites.FirstOrDefault(cart => cart.UserId == userId);
        }

        public void Add(ProductViewModel product, string userId)
        {
            var existingFavor = TryGetByUserId(userId);
            if (existingFavor == null)
            {
                existingFavor = new FavouriteViewModel()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = [product]
                    
                };
                _favourites.Add(existingFavor);
            }
            else
            {
                var existingFavorItem = existingFavor.Items.FirstOrDefault(item => item.Id == product.Id);
                if (existingFavorItem == null)
                {
                    existingFavor.Items.Add(product);
                }
            }
        }

        public void Delete(ProductViewModel? product, string userId)
        {
            var existingFavor = TryGetByUserId(userId);

            var existingFavorItem = existingFavor?.Items
                .FirstOrDefault(item => item.Id == product.Id);

            if (existingFavor != null)
            {
                existingFavor.Items.Remove(existingFavorItem);
            }

        }

        public void Clear(string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart != null)
            {
                _favourites.Remove(existingCart);
            }
        }
    }
}
