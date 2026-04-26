using WEBtest.Db.Models;

namespace WEBtest.Db.Interfaces
{
    public interface IOrderFurnituresRepository
    {
        List<OrderFurniture> GetAllOrderFurniture();
       void Add(OrderFurniture orderfurniture);

    }
}
