using WEBtest.Db.Models;

namespace WEBtest.Db.Interfaces
{
    public interface IFavouritesRepository
    {
        Favourite? TryGetByUserId(string userId);
        void Add(Product product, string userId);
        void Delete(int productId, string userId);
        void Clear(string userId);
    }
}
