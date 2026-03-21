using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBtest.Helpers;
using WEBtest.Interfaces;
using WEBtest.Models;

namespace WEBtest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository _productRepository;
        private readonly IPicturesRepository _picturesRepository;
        private bool _sorted {get; set;}

        public HomeController(IProductsRepository productRepository, IPicturesRepository picturesRepository)
        {
            _productRepository = productRepository;
            _picturesRepository = picturesRepository;
        }

        public List<ProductViewModel> GetProductsByCategory(string categoryName)
        {
            var products = _productRepository.GetAll();
            var sortedProducts = new List<ProductViewModel>();
            foreach (var product in products)
            {
                if (product?.Category?.CategoryName == categoryName)
                {
                    sortedProducts.Add(product.ToProductViewModel());
                }
            }
            _sorted = true;
            return sortedProducts;
        }


        public IActionResult Index()   // Сортировка общей по категориям и по возрастанию
        {
            //if (_sorted)
            //{
            //    return View();
            //}
            var photo = _picturesRepository.GetAll().ToPicturesViewModels();

            var products = _productRepository
                .GetAll()
                .ToProductViewModels();
            var homeView = new HomeViewModel
            {
                Products = products,
                Pictures = photo
            };
            return View(homeView);
        }

        public IActionResult Sort(/*string categoryName*/)   // Сортировка общей по категориям и по возрастанию
        {
            /*string categoryName*/ // - получить из формы
            var sortedProducts = GetProductsByCategory("Сережки" /*string categoryName*/);
           // return RedirectToAction();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Category()   // Вызов страницы категория Сережек
        {

            return View(_productRepository.GetAll().ToProductViewModels().OrderBy(product => product.Id).ToList());
            
            //var products = _productRepository
            //    .GetAll()
            //    .ToProductViewModels();
            //var homeView = new HomeViewModel
            //{
            //    Products = products,
            //};
            //return View();
  
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
