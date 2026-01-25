using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Xml.Linq;
using WEBtest.Interfaces;
using WEBtest.Models;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBtest.Helpers;

namespace WEBtest.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository _productRepository;

        public ProductController(IProductsRepository productRepository) 
        { 
            _productRepository = productRepository;
        }

        public IActionResult Index(int id)
        {
            var product = _productRepository.TryGetById(id);
            return View(product?.ToProductViewModel());
            //return View(product);
        }

        public IActionResult Addition(Product product)
        {
            _productRepository.Add(product);
            return View(_productRepository);
        }
        public IActionResult Add(Product product)
        {
            _productRepository.Add(product);

            return RedirectToAction(nameof(Index), "Home");
            //return View("../Home/index", ProductRepository.GetAll());
        }
        /*public IActionResult Addition(string name, decimal cost, string description)
        {
            _productRepository.Add(name, cost, description);
            return View(_productRepository);
        }
        public IActionResult Add(string name, decimal cost, string description)
        {
            _productRepository.Add(name, cost, description);

            return RedirectToAction(nameof(Index), "Home");
            //return View("../Home/index", ProductRepository.GetAll());
        }*/
    }
}
