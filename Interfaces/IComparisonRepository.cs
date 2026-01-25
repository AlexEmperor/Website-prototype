using WEBtest.Models;

namespace WEBtest.Interfaces
{
    public interface IComparisonRepository
    {
        void Add(ProductViewModel product, string userId);
        void Delete(ProductViewModel? product, string userId);
        void Clear(string userId);
        ComparisonViewModel? TryGetByUserId(string userId);
    }

}
