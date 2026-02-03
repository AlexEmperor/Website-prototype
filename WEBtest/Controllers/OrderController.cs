using Microsoft.AspNetCore.Mvc;
using WEBtest.Interfaces;
using WEBtest.Models;
using WEBtest.Helpers;
using WEBtest.Db.Interfaces;

namespace WEBtest.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;
        public OrderController(ICartsRepository cartRepository, IOrderRepository orderRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            var cart = _cartRepository.TryGetByUserId(Constants.UserId);

            var order = new Order()
            {
                Items = cart?.ToCartViewModel()?.Items
            };

            return View(order);
        }

        public IActionResult Buy(Order order)
        {
            var cart = _cartRepository.TryGetByUserId(Constants.UserId);

            if (cart is null)
            {
                return View(nameof(Index), order);
            }
            order.Items = cart?.ToCartViewModel()?.Items;
            order.UserId = Constants.UserId;

            if (!ModelState.IsValid)
            {
                return View(nameof(Index), order);
            }
            _orderRepository.Add(order);

            _cartRepository.Clear(Constants.UserId);

            return RedirectToAction(nameof(Success));
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}


