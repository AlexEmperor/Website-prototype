using Microsoft.AspNetCore.Mvc;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBtest.Helpers;
using WEBtest.Models;

namespace WEBtest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController(IOrdersRepository ordersRepository) : Controller
    {
        private readonly IOrdersRepository _ordersRepository = ordersRepository;

        public IActionResult Index()
        {
            var orders = _ordersRepository.GetAll();

            return View(orders.ToOrderViewModels().OrderByDescending(x => x.CreationDateTime).ToList());
        }

        public IActionResult Detail(Guid orderId)
        {
            var order = _ordersRepository.TryGetById(orderId);

            return View(order?.ToOrderViewModel());
        }

        [HttpPost]
        public IActionResult UpdateStatus(Guid orderId, OrderStatusViewModel status)
        {
            _ordersRepository.UpdateStatus(orderId, (OrderStatus)status);

            return RedirectToAction(nameof(Index));
        }
    }
}
