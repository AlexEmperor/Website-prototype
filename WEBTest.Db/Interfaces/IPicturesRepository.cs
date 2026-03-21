using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBtest.Db.Models;

namespace WEBtest.Db.Interfaces
{
    public interface IPicturesRepository
    {
        byte[]? TryGetPhotoById(int id);
        List<Pictures> GetAll();
    }
}
