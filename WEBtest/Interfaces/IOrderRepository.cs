using WEBtest.Models;

namespace WEBtest.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order? TryGetById(Guid orderId);
        void UpdateStatus(Guid orderId, OrderStatus status);
    }
}
