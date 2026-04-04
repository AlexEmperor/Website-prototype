using WEBtest.Models;

namespace WEBtest.Interfaces
{
    public interface IFurnitureRepository
    {
        List<FurnitureViewModel> GetAll();
        FurnitureViewModel? TryGetById(Guid furnitureId);

        //void Add(FurnitureViewModel orderfurniture);

    }
}
