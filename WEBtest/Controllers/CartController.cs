using Microsoft.AspNetCore.Mvc;
using WEBtest.Interfaces;
using WEBtest.Models;
using WEBtest.Helpers;
using WEBtest.Db.Interfaces;

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

        public IActionResult Add(int productId)
        {
            _cartRepository.Add(_productRepository.TryGetById(productId), Constants.UserId);

            return RedirectToAction(nameof(Index));
            //return View("../Home/index", ProductRepository.GetAll());
        }
        public IActionResult Delete(int productId)
        {
            _cartRepository.Delete(productId/*_productRepository.TryGetById(productId)*/, Constants.UserId);

            return RedirectToAction(nameof(Index));
            //return View("../Home/index", ProductRepository.GetAll());
        }
        public IActionResult Clear()
        {
            _cartRepository.Clear(Constants.UserId);

            return RedirectToAction(nameof(Index));
        }

    }
}
