using Microsoft.EntityFrameworkCore;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBTest.Db;

namespace WEBtest.Db.Repositories
{

    public class PicturesDbRepository  : IPicturesRepository
    {
        private readonly DatabaseContext _databaseContext;

        public PicturesDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public byte[]? TryGetPhotoById(int id)
        {
            var result = _databaseContext.Pictures.FirstOrDefault(picture => picture.Id == id);
            return result?.Point;
        }
        public List<Pictures> GetAll() => _databaseContext.Pictures.ToList();


    } 
}
