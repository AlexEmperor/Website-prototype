using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEBtest.Db.Interfaces;
using WEBtest.Helpers;
using WEBtest.Models;

namespace WEBtest.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    public class ProductFurnitureController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IWebHostEnvironment _environment;

        public ProductFurnitureController(IProductsRepository productsRepository, IWebHostEnvironment environment)
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
            ViewBag.Categories = _productsRepository.GetAllCategories()
        .Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.CategoryName
        }).ToList();
            ViewBag.FurnitureOrders = _productsRepository.GetAllFurnitureOrders()
    .Select(fo => new SelectListItem
    {
        Value = fo.Id.ToString(),
        Text = $"{fo.Provider} ({fo.OrderCreationDateTime:dd.MM.yyyy})"
    }).ToList();
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
            */
            model.PhotoPath = await FileSaver.SaveFileAsync(
                model.PhotoFile,
                "img",
                _environment,
                model.Name);

            _productsRepository.Add(model.ToProductDb());

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            _productsRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            var product = _productsRepository.TryGetById(id);

            ViewBag.Categories = _productsRepository.GetAllCategories()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.CategoryName
                }).ToList();
            ViewBag.FurnitureOrders = _productsRepository.GetAllFurnitureOrders()
    .Select(fo => new SelectListItem
    {
        Value = fo.Id.ToString(),
        Text = $"{fo.Provider} ({fo.OrderCreationDateTime:dd.MM.yyyy})"
    }).ToList();
            return View(product?.ToProductViewModel());
        }


        [HttpPost]
        public IActionResult Update(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var productDb = _productsRepository.TryGetById(product.Id);
            if (productDb == null)
            {
                return NotFound();
            }

            // ===== Фото =====
            if (product.PhotoFile != null)
            {
                // Удаляем старый файл
                if (!string.IsNullOrEmpty(productDb.PhotoPath))
                {
                    var oldPhotoPath = Path.Combine(_environment.WebRootPath, productDb.PhotoPath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                    if (System.IO.File.Exists(oldPhotoPath))
                    {
                        System.IO.File.Delete(oldPhotoPath);
                    }
                }

                var newPhoto = FileSaver.SaveFileAsync(product.PhotoFile, "img", _environment, product.Name).Result;
                if (newPhoto != null)
                {
                    productDb.PhotoPath = newPhoto;
                }
            }
            _productsRepository.Update(product.ToProductDb());

            return RedirectToAction(nameof(Index));
        }
    }
}
