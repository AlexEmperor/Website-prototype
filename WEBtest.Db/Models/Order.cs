
namespace WEBtest.Db.Models
{
    public class Order  //Класс заказы
    {
        public Guid Id { get; set; }  //!!
        public string UserId { get; set; }                           //
        public List<CartItem> Items { get; set; }
        //public DeliveryUser DeliveryUser { get; set; }               //
        public DateTime CreationDateTime { get; set; }               //Время во сколько сделали заказ
        public OrderStatus Status { get; set; }                      //статус заказа
        ///////////////////////////////////////////////////////////////////////////////////
        public string Address { get; set; }                         //адрес покупателя

    }
}
