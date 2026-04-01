using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBtest.Helpers;
using WEBtest.Models;

namespace WEBtest.Controllers
{
    public class OrderController(
        ICartsRepository cartRepository,
        IOrdersRepository orderRepository) : Controller
    {
        private readonly ICartsRepository _cartRepository = cartRepository;
        private readonly IOrdersRepository _orderRepository = orderRepository;

        public IActionResult Index()
        {
            var cart = _cartRepository.TryGetByUserId(GetUserId());

            var order = new OrderViewModel()
            {
                Items = cart?.Items.ToCartItemViewModels()
            };

            return View(order);
        }

        public string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        [HttpPost]
        public IActionResult Buy(OrderViewModel order)
        {
            var cart = _cartRepository.TryGetByUserId(GetUserId());

            if (cart == null)
            {
                return View(nameof(Index), order);
            }

            order.Items = cart.Items.ToCartItemViewModels();
            order.UserId = GetUserId();

            if (!ModelState.IsValid)
            {
                return View(nameof(Index), order);
            }

            var orderDb = new Order()    // !!Создаем новый заказ
            {
                UserId = order.UserId,
                Items = cart.Items,
                DeliveryUser = order.DeliveryUser.ToDeliveryUserDb()
            };

            _orderRepository.Add(orderDb);

            _cartRepository.Clear(GetUserId());

            return RedirectToAction(nameof(Success));
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}


