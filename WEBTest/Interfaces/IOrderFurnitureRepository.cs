using WEBtest.Models;

namespace WEBtest.Interfaces
{
    public interface IOrderFurnitureRepository
    {
        //void Add(OrderFurnitureViewModel orderfurniture);
        List<OrderFurnitureViewModel> GetAll();
        OrderFurnitureViewModel? TryGetById(Guid orderfurnitureId);

    }
}
