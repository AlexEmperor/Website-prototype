using Microsoft.EntityFrameworkCore;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBTest.Db;

namespace WEBtest.Db.Repositories
{
    public class FurnitureDbRepository(DatabaseContext databaseContext) : IFurnituresRepository
    {
        private readonly DatabaseContext _databaseContext = databaseContext;
        public List<OrderFurniture> GetAll() => _databaseContext.FurnitureOrders.ToList();
        public List<Furniture> GetAllFurniture() => _databaseContext.Furniture.ToList();


        //    public List<Furniture> GetAll() => _databaseContext.FurnitureOrdersFurniture
        //.Include(x => x.DeliveryUser)
        //.Include(x => x.Items)
        //.ThenInclude(x => x.Product)
        //.OrderByDescending(x => x.CreationDateTime)
        //.ToList();


    }
}
