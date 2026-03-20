using Microsoft.EntityFrameworkCore;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBTest.Db;

namespace WEBtest.Db.Repositories
{

    public class PicturesDbRepository  // : IProductsRepository
    {
        private readonly DatabaseContext _databaseContext;

        public PicturesDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
   //     public List<Pictures> GetAll() => _databaseContext.Pictures.ToList();





        // public List<Category> GetAllCategories() => _databaseContext.Categories.ToList();

        // public List<OrderFurniture> GetAllFurnitureOrders() => _databaseContext.FurnitureOrders.ToList();
    }
}
