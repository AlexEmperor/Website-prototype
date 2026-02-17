
namespace WEBtest.Db.Models
{
    public class Order  //Класс заказы
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }                           //
        public List<CartItem> Items { get; set; }
        public DeliveryUser DeliveryUser { get; set; }               //
        public DateTime CreationDateTime { get; set; }               //Время во сколько сделали заказ
        public OrderStatus Status { get; set; }                      //статус заказа
        ///////////////////////////////////////////////////////////////////////////////////
   
        public string Address { get; set; }                         //адрес покупателя


        /*
        Id = deliveryUser.Id,
                Name = deliveryUser.Name,
                Address = deliveryUser.Address,
                Phone = deliveryUser.Phone,
                Date = DateTime.SpecifyKind(deliveryUser.Date, DateTimeKind.Utc),
                Comment = deliveryUser.Comment
        */

    }
}
