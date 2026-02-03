using Microsoft.AspNetCore.Mvc;
using WEBtest.Db.Interfaces;
using WEBtest.Helpers;
using WEBtest.Interfaces;

namespace WEBtest.Controllers
{
    public class FavouriteController : Controller
    {
        private readonly IFavouritesRepository _favouriteRepository;
        private readonly IProductsRepository _productRepository;

        public FavouriteController(IFavouritesRepository favouriteRepository, IProductsRepository productRepository)
        {
            _favouriteRepository = favouriteRepository;
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var favorite = _favouriteRepository.TryGetByUserId(Constants.UserId);

            return View(favorite.ToFavoriteViewModel());
        }
        public IActionResult Add(int productId)
        {
            _favouriteRepository.Add(_productRepository.TryGetById(productId), Constants.UserId);

            return RedirectToAction(nameof(Index));
            //return View("../Home/index", ProductRepository.GetAll());
        }
        public IActionResult Delete(int productId)
        {
            _favouriteRepository.Delete(/*_productRepository.TryGetById(productId)*/productId, Constants.UserId);

            return RedirectToAction(nameof(Index));
            //return View("../Home/index", ProductRepository.GetAll());
        }
        public IActionResult Clear()
        {
            _favouriteRepository.Clear(Constants.UserId);

            return RedirectToAction(nameof(Index));
        }
    }
}
