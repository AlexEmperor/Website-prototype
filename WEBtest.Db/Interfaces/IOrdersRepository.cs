using WEBtest.Db.Models;

namespace WEBtest.Db.Interfaces
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order? TryGetById(Guid orderId);
        void UpdateStatus(Guid orderId, OrderStatus status);
        void Delete(Guid orderId);
        //List<Order> Find(string user);
       // List<Order> GetOrdersByUserUserName(Guid orderId);

    }
}
