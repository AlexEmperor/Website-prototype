using WEBtest.Db.Models;

namespace WEBtest.Db.Interfaces
{
    public interface IFurnituresRepository
    {
        List<OrderFurniture> GetAll();
        List<Furniture> GetAllFurniture();
        //Furniture? TryGetById(Guid furnitureId);
        //void Add(Furniture furniture);
    }
}
