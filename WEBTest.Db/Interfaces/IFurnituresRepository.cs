using WEBtest.Db.Models;

namespace WEBtest.Db.Interfaces
{
    public interface IFurnituresRepository
    {


       List<Furniture> GetAllFurniture();
       void Add(Furniture furniture);

    }
}
