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

                var cart = _cartRepository.TryGetByUserId(Constants.UserId);

                return View(cart.ToCartViewModel());

        }

        public string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public IActionResult Add(int productId)
        {
            _cartRepository.Add(_productRepository.TryGetById(productId), GetUserId(), "admin2@gmail.com");  //"admin"

            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult AddInCart(int productId)
        {
            _cartRepository.Add(_productRepository.TryGetById(productId), GetUserId(), "admin2@gmail.com");  //"admin"

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
