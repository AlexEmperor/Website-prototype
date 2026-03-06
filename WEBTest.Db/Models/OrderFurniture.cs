using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBtest.Db.Models
{
    public class OrderFurniture
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public List<Furniture> Furniture { get; set; }

        public string Provider {  get; set; }

        public DateTime OrderCreationDateTime { get; set; }
        public DateTime OrderDeliveryDateTime { get; set; }
    }
}
