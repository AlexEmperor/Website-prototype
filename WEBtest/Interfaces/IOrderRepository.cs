using WEBtest.Models;

namespace WEBtest.Interfaces
{
    public interface IOrderRepository
    {
        void Add(OrderViewModel order);
        List<OrderViewModel> GetAll();
        OrderViewModel? TryGetById(Guid orderId);
        void UpdateStatus(Guid orderId, OrderStatusViewModel status);
    }
}
