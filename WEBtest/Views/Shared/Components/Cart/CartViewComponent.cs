using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WEBtest.Db.Interfaces;
using WEBtest.Helpers;
using WEBtest.Interfaces;

namespace WEBtest.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository _cartRepository;

        public CartViewComponent(ICartsRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public string GetUserId()
        {
            return HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public IViewComponentResult Invoke()
        {
            var cart = _cartRepository.TryGetByUserId(GetUserId());
            var productsCount = cart?.ToCartViewModel()?.Quantity ?? 0;

            return View("Cart", productsCount);
        }
    }
}
