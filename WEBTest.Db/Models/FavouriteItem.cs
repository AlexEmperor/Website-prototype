using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBtest.Db.Models
{
    public class FavouriteItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Favourite? Favourite { get; set; }
    }
}
