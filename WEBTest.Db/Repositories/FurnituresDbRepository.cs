using Microsoft.EntityFrameworkCore;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBTest.Db;

namespace WEBtest.Db.Repositories
{
    public class FurnitureDbRepository(DatabaseContext databaseContext) : IFurnituresRepository
    {
        private readonly DatabaseContext _databaseContext = databaseContext;

        public List<Furniture> GetAllFurniture() => _databaseContext.Furniture.ToList();

        public void Add(Furniture furniture)
        {
            _databaseContext.Furniture.Add(furniture);
            _databaseContext.SaveChanges();  // Сохраняем изменения в БД
        }

    }
}
