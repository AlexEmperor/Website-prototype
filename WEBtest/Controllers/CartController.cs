using Microsoft.AspNetCore.Mvc;
using WEBtest.Interfaces;
using WEBtest.Models;
using WEBtest.Helpers;
using WEBtest.Db.Interfaces;
using System.Security.Claims;

namespace WEBtest.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository _productRepository;
        private readonly ICartsRepository _cartRepository;

        public CartController(IProductsRepository productRepository, ICartsRepository cartRepository)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;

        }

        public IActionResult Index()
        {
            var cart = _cartRepository.TryGetByUserId(GetUserId());

            return View(cart.ToCartViewModel());
        }

        public string GetUserId()
        {
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        public IActionResult Add(int productId)
        {
            var product = _productRepository.TryGetById(productId);
            if (product is not null)
            {
                _cartRepository.Add(product, GetUserId());
            }
            
            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult AddInCart(int productId)
        {
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            _cartRepository.Add(_productRepository.TryGetById(productId), GetUserId());
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int productId)
        {
            _cartRepository.Delete(productId/*_productRepository.TryGetById(productId)*/, GetUserId());

            return RedirectToAction(nameof(Index));
            //return View("../Home/index", ProductRepository.GetAll());
        }

        public IActionResult Clear()
        {
            _cartRepository.Clear(GetUserId());

            return RedirectToAction(nameof(Index));
        }

    }
}
