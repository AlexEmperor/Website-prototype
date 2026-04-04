
namespace WEBtest.Db.Models
{
    public class Order  //Класс заказы
    {
       ///  В БД ///////
        public Guid Id { get; set; }                                 //+//
        public string UserId { get; set; }                           //+//
        public DateTime CreationDateTime { get; set; }               //+// Время во сколько сделали заказ
        public OrderStatus Status { get; set; }                      //+// Статус заказа
        public decimal? TotalCost { get; set; }                      //-// Общая сумма заказанного
        public int? ItemsQuantity { get; set; }                      //-// Ко-во азаказанного
        public decimal? TotalCostOrder { get; set; }                 //-// 
        public Guid? DeliveryUserId { get; set; }                    //+//
                                                                     ///////////////////////////////////////////////////////////////////////////////////
        public List<CartItem> Items { get; set; }
        public DeliveryUser DeliveryUser { get; set; }               //
        //public string Address { get; set; }                        //адрес покупателя
    }
}
