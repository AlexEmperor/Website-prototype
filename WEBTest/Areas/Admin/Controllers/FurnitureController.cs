using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBtest.Helpers;
using WEBtest.Interfaces;
using WEBtest.Models;

namespace WEBtest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FurnitureController(IFurnituresRepository furnituresRepository) : Controller
    {
        private readonly IFurnituresRepository _furnituresRepository = furnituresRepository;

        public IActionResult Index()
        {
            var furnitures = _furnituresRepository.GetAllFurniture();

            return View(furnitures.ToFurnitureViewModels().OrderByDescending(x => x.Id).ToList());
        }
        /*
        public IActionResult Add()   // дабавить продукт
        {

            ViewBag.Furniture = _furnituresRepository.GetAll()
    
            .Select(fo => new SelectListItem
            {
                Value = fo.Id.ToString()
            }).ToList();

            return View();
        }
        */
        public IActionResult Add(FurnitureViewModel furniture)   // дабавить продукт
        {
            if (ModelState.IsValid)
            {

                // Id обычно не задаём вручную — он генерируется БД
                // Если нужно, установите другие свойства из модели
                _furnituresRepository.Add(new Furniture
                {
                    Id = furniture.Id,
                    Name = furniture.Name,
                    Price = furniture.Price,
                    Description = furniture.Description,
                    OrderPlace= furniture.OrderPlace,
                    HardNumber= furniture.HardNumber
                });

                //_furnituresRepository.Save(); // если требуется явное сохранение
                return RedirectToAction(nameof(Index));
            }

            // Если валидация не прошла — возвращаем форму с ошибками
            return View(furniture);
        }







        /*
        public Task<IActionResult> Add(FurnitureViewModel model)
        {
    
            if (!ModelState.IsValid)
            {
                return View(model);
            }
          //  _furnituresRepository.Add(model.ToFurnitureProductDb());

            return RedirectToAction(nameof(Index));
        }
        */
    }
}
