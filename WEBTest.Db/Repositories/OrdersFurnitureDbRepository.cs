using Microsoft.EntityFrameworkCore;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBTest.Db;

namespace WEBtest.Db.Repositories
{
    public class OrdersFurnitureDbRepository(DatabaseContext databaseContext) : IOrdersRepository
    {
        private readonly DatabaseContext _databaseContext = databaseContext;

        public void Add(Order orderfurniture)  // передаем полученные данные об заказе  в Таблицу "Order"!!!
        {
            try
            {
                orderfurniture.Id = Guid.NewGuid();
                orderfurniture.CreationDateTime = DateTime.UtcNow;
                orderfurniture.DeliveryUser.Id = Guid.NewGuid();
                orderfurniture.Status = OrderStatus.Created;

                _databaseContext.Orders.Add(orderfurniture);
                _databaseContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        public List<Order> GetAll() => _databaseContext.Orders
            .Include(x => x.DeliveryUser)
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .OrderByDescending(x => x.CreationDateTime)
            .ToList();

        public Order? TryGetById(Guid orderId) =>
            _databaseContext.Orders
            .Include(x => x.DeliveryUser)
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .FirstOrDefault(order => order.Id == orderId);

        public void UpdateStatus(Guid orderId, OrderStatus newStatus)
        {
            var existingOrder = TryGetById(orderId);

            if (existingOrder != null)
            {
                existingOrder.Status = newStatus;

                _databaseContext.SaveChanges();
            }
        }

        public void Delete(Guid orderId) 
        {
            var existingOrder = TryGetById(orderId);
        }
    }
}
