using Microsoft.AspNetCore.Mvc;
using WEBtest.Db.Interfaces;
using WEBtest.Helpers;
using WEBtest.Interfaces;

namespace WEBtest.Controllers
{
    public class ComparisonController : Controller
    {
        private readonly IComparisonsRepository _comparisonRepository;
        private readonly IProductsRepository _productRepository;

        public ComparisonController(IComparisonsRepository comparisonRepository, IProductsRepository productRepository)
        {
            _comparisonRepository = comparisonRepository;
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var comparison = _comparisonRepository.TryGetByUserId(Constants.UserId);

            return View(comparison?.ToComparisonViewModel());
        }
        public IActionResult Add(int productId)
        {
            _comparisonRepository.Add(_productRepository.TryGetById(productId), Constants.UserId);

            return RedirectToAction(nameof(Index));
            //return View("../Home/index", ProductRepository.GetAll());
        }
        public IActionResult Delete(int productId)
        {
            _comparisonRepository.Delete(productId, Constants.UserId);

            return RedirectToAction(nameof(Index));
            //return View("../Home/index", ProductRepository.GetAll());
        }
        public IActionResult Clear()
        {
            _comparisonRepository.Clear(Constants.UserId);

            return RedirectToAction(nameof(Index));
        }
    }
}
