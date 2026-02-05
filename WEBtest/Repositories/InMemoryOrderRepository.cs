using WEBtest.Interfaces;
using WEBtest.Models;

namespace WEBtest.Repositories
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        public readonly List<OrderViewModel> _orders = [];
        public void Add(OrderViewModel order)
        {
            order.Id = Guid.NewGuid();
            order.CreationDateTime = DateTime.Now;
            order.DeliveryUser.Id = Guid.NewGuid();
            _orders.Add(order);
        }

        public List<OrderViewModel> GetAll() => _orders;

        public OrderViewModel? TryGetById(Guid orderId) => _orders.FirstOrDefault(order => order.Id == orderId);
        public void UpdateStatus(Guid orderId, OrderStatusViewModel newStatus)
        {
            var existingOrder = TryGetById(orderId);

            if (existingOrder != null)
            {
                existingOrder.Status = newStatus;
            }
        }
    }
}
