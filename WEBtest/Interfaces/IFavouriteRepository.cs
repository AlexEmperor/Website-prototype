using WEBtest.Models;

namespace WEBtest.Interfaces
{
    public interface IFavouriteRepository
    {
        void Add(ProductViewModel product, string userId);
        void Delete(ProductViewModel? product, string userId);
        void Clear(string userId);
        FavouriteViewModel? TryGetByUserId(string userId);
    }
}
