using Microsoft.EntityFrameworkCore;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBTest.Db;

namespace WEBtest.Db.Repositories
{
    public class OrdersDbRepository : IOrdersRepository
    {
        private readonly DatabaseContext _databaseContext;

        public OrdersDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(Order order)  // передаем полученные данные об заказе  в Таблицу "Order"!!!
        {
            try
            {
                order.Id = Guid.NewGuid();
                order.CreationDateTime = DateTime.UtcNow;
                order.DeliveryUser.Id = Guid.NewGuid();
                order.Status = OrderStatus.Created;
               // order.Address = string.Address;

                _databaseContext.Orders.Add(order);

                _databaseContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        public List<Order> GetAll() => _databaseContext.Orders.Include(x => x.DeliveryUser).Include(x => x.Items).ThenInclude(x => x.Product).ToList();

        public Order? TryGetById(Guid orderId) =>
            _databaseContext.Orders.Include(x => x.DeliveryUser).Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefault(order => order.Id == orderId);

        public void UpdateStatus(Guid orderId, OrderStatus newStatus)
        {
            var existingOrder = TryGetById(orderId);

            if (existingOrder != null)
            {
                existingOrder.Status = newStatus;

                _databaseContext.SaveChanges();
            }
        }
    }
}
