using WEBtest.Db.Models;

namespace WEBtest.Db.Interfaces
{
    public interface ICartsRepository
    {
        void Add(Product product, string userId);
        Cart? TryGetByUserId(string userId);
        void Delete(int productId, string userId);
        void Clear(string userId);
    }
}
