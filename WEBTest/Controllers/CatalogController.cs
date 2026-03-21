using Microsoft.AspNetCore.Mvc;
using WEBtest.Db.Interfaces;
using WEBtest.Helpers;

namespace WEBtest.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductsRepository _productRepository;

        public CatalogController(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products.ToProductViewModels());
        }
    }
}
