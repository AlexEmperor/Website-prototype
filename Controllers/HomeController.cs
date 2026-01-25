using Microsoft.AspNetCore.Mvc;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBtest.Helpers;
using WEBtest.Interfaces;

namespace WEBtest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository _productRepository;
        public HomeController(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products.ToProductViewModels());
            //return View(_productRepository.GetAll());
        }
        public IActionResult Search(string query)
        {
            if (query == null)
            {
                return View();
            }
            var products = _productRepository.Search(query);

            return View(products.ToProductViewModels());

            /*var products = _productRepository.Search(query);

            return View(products);*/
        }
    }
}
