using Microsoft.AspNetCore.Mvc;
using WEBtest.Helpers;
using WEBtest.Interfaces;
using WEBtest.Models;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;

namespace WEBtest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IWebHostEnvironment _environment;

        public ProductController(IProductsRepository productsRepository, IWebHostEnvironment environment)
        {
            _productsRepository = productsRepository;
            _environment = environment;
        }


        public IActionResult Index()
        {
            return View(_productsRepository.GetAll().ToProductViewModels().OrderBy(product => product.Id).ToList());
            //return View(products);
        }


        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            /*
            // Фото ОБЯЗАТЕЛЬНО при создании
            if (model.PhotoFile == null)
            {
                ModelState.AddModelError("PhotoFile", "Необходимо загрузить фото товара");
                return View(model);
            }

            model.PhotoPath = await FileSaver.SaveFileAsync(
                model.PhotoFile,
                "img",
                _environment,
                model.Name);
            */
            _productsRepository.Add(model.ToProductDb());

            return RedirectToAction(nameof(Index));
        }

        /* [HttpPost]
         public IActionResult Add(ProductViewModel product)
         {
             if (!ModelState.IsValid)
             {
                 return View(product);
             }
             _productsRepository.Add(product.ToProductDb());
             //_productsRepository.Add(product);

             return RedirectToAction(nameof(Index));
         }*/


        public IActionResult Delete(int id)
        {
            _productsRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            var existingProduct = _productsRepository.TryGetById(id);
            return View(existingProduct?.ToProductViewModel());
            //return View(existingProduct);
        }


        [HttpPost]
        public IActionResult Update(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _productsRepository.Update(product.ToProductDb());
            //_productsRepository.Update(product);

            return RedirectToAction(nameof(Index));
        }
    }
}
