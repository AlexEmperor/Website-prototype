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
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        public IViewComponentResult Invoke()
        {
            var cart = _cartRepository.TryGetByUserId(GetUserId());
            var productsCount = cart?.ToCartViewModel()?.Quantity ?? 0;

            return View("Cart", productsCount);
        }
    }
}
