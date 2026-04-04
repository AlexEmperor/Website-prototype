using WEBtest.Db.Models;

namespace WEBtest.Db.Interfaces
{
    public interface IFurnituresRepository
    {
        List<Furniture> GetAll();

        //Furniture? TryGetById(Guid furnitureId);
        //void Add(Furniture furniture);
    }
}
