using WEBtest.Models;

namespace WEBtest.Interfaces
{
    public interface IOrderFurnitureRepository
    {
        void Add(OrderViewModel order);
        List<OrderViewModel> GetAll();
        OrderViewModel? TryGetById(Guid orderId);
        void UpdateStatus(Guid orderId, OrderStatusViewModel status);
    }
}
