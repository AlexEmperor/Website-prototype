using Microsoft.EntityFrameworkCore;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBTest.Db;

namespace WEBtest.Db.Repositories
{
    public class OrdersFurnitureDbRepository(DatabaseContext databaseContext) : IOrderFurnituresRepository
    {
        private readonly DatabaseContext _databaseContext = databaseContext;


        /*
        public List<OrderFurniture> GetAllOrderFurniture() => _databaseContext.FurnitureOrders.ToList();
        */
        
        public List<OrderFurniture> GetAllOrderFurniture() => 
            _databaseContext.FurnitureOrders
            //.Include(p => p.FurnituresId)
            .Include(fo => fo.Furnitures)
            .ToList();
        

        public void Add(OrderFurniture orderfurniture)
        {
            _databaseContext.FurnitureOrders.Add(orderfurniture);
            _databaseContext.SaveChanges();  // Сохраняем изменения в БД
        }





        //public void Add(Furniture furniture)
        //{
        //    _databaseContext.Furniture.Add(furniture);
        //    _databaseContext.SaveChanges();  // Сохраняем изменения в БД
        //}

    }
}
