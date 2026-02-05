using Microsoft.AspNetCore.Mvc;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBtest.Helpers;
using WEBtest.Models;

namespace WEBtest.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository _cartRepository;
        private readonly IOrdersRepository _orderRepository;
        public OrderController(ICartsRepository cartRepository, IOrdersRepository orderRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            var cart = _cartRepository.TryGetByUserId(Constants.UserId);

            var order = new OrderViewModel()
            {
                Items = cart?.Items.ToCartItemViewModels()
            };

            return View(order);
        }

        [HttpPost]
        public IActionResult Buy(OrderViewModel order)
        {
            var cart = _cartRepository.TryGetByUserId(Constants.UserId);

            if (cart == null)
            {
                return View(nameof(Index), order);
            }

            order.Items = cart.Items.ToCartItemViewModels();
            order.UserId = Constants.UserId;

            if (!ModelState.IsValid)
            {
                return View(nameof(Index), order);
            }

            var orderDb = new Order()
            {
                Id = order.Id,
                UserId = order.UserId,
                Items = cart.Items,
                DeliveryUser = order.DeliveryUser.ToDeliveryUserDb(),
                CreationDateTime = order.CreationDateTime,
                Status = (OrderStatus)order.Status,
            };

            _orderRepository.Add(orderDb);

            _cartRepository.Clear(Constants.UserId);

            return RedirectToAction(nameof(Success));
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}


