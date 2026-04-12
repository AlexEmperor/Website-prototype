
namespace WEBtest.Db.Models
{
    public class Order  //Класс заказы
    {
        public Guid Id { get; set; }  //!!
        public string UserId { get; set; }                           //
        public List<CartItem> Items { get; set; }
        public Guid? DeliveryUserId { get; set; }
        public DeliveryUser DeliveryUser { get; set; }               //
        public DateTime CreationDateTime { get; set; }               //Время во сколько сделали заказ
        public OrderStatus Status { get; set; }                      //статус заказа
        ///////////////////////////////////////////////////////////////////////////////////
        //public string Address { get; set; }                         //адрес покупателя

        public decimal? TotalCost { get; set; }                    // 
        public decimal? TotalCostOrder { get; set; }
        public int? ItemsQuantity { get; set; }
        public int? DeparNumbe { get; set; }
    }
}
