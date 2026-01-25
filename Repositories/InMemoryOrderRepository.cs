using WEBtest.Interfaces;
using WEBtest.Models;

namespace WEBtest.Repositories
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        public readonly List<Order> _orders = [];
        public void Add(Order order)
        {
            order.Id = Guid.NewGuid();
            order.CreationDateTime = DateTime.Now;
            order.DeliveryUser.Id = Guid.NewGuid();
            _orders.Add(order);
        }

        public List<Order> GetAll() => _orders;

        public Order? TryGetById(Guid orderId) => _orders.FirstOrDefault(order => order.Id == orderId);
        public void UpdateStatus(Guid orderId, OrderStatus newStatus)
        {
            var existingOrder = TryGetById(orderId);

            if (existingOrder != null)
            {
                existingOrder.Status = newStatus;
            }
        }
    }
}
