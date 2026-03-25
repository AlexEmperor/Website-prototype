using WEBtest.Models;

namespace WEBtest.Interfaces
{
    public interface ICartRepository
    {
        void Add(ProductViewModel product, string userId, string login);
        void Delete(ProductViewModel? product, string userId);
        void Clear(string userId);
        CartViewModel? TryGetByUserId(string userId);
    }
}
