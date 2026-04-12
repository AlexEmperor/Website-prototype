using Microsoft.AspNetCore.Identity;
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
        IOrdersRepository orderRepository,
        UserManager<UserDTO> userManager) : Controller
    {
        private readonly ICartsRepository _cartRepository = cartRepository;
        private readonly IOrdersRepository _orderRepository = orderRepository;

        public async Task<IActionResult> Index()
        {
            var cart = _cartRepository.TryGetByUserId(GetUserId());
            var appUser = await userManager.GetUserAsync(User);

//#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
//#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
//#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            var order = new OrderViewModel()
            {
                Items = cart?.Items.ToCartItemViewModels(),
                DeliveryUser = new DeliveryUserViewModel
                {
                    Name = appUser?.FirstName,        // реальное имя из БД
                    Login = appUser?.Email,           // email
                    Phone = appUser?.PhoneNumber,     // телефон из БД
                }
            };
//#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
//#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
//#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.

            return View(order);
        }

        public string GetUserId()
        {
//#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
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

            orderDb.Items[0].Product.Storage_FBS1 = orderDb.Items[0].Product.Storage_FBS1 - orderDb.Items[0].Quantity;


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


