using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBtest.Db.Repositories;
using WEBtest.Helpers;
using WEBtest.Interfaces;
using WEBtest.Models;


namespace WEBtest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderFurnitureController(IOrderFurnituresRepository orderfurnitureRepository) : Controller
    {
         private readonly IOrderFurnituresRepository _orderfurnitureRepository = orderfurnitureRepository;



        public IActionResult Index()
        {
            var orderfurnitures = _orderfurnitureRepository.GetAllOrderFurniture();

            return View(orderfurnitures.ToOrderFurnitureViewModels().OrderByDescending(x => x.Id).ToList());
        }

        //public IActionResult Index()
        //{
        //    var orders = _orderfurnitureRepository.GetAllOrderFurniture();


        //    return View(orders.ToOrderFurnitureViewModels());
        //    //return View(orders.ToOrderFurnitureViewModels().OrderByDescending(x => x.CreationDateTime).ToList());


        //}


        public IActionResult Add(OrderFurnitureViewModel orderfurniture)   // дабавить продукт
        {
            if (ModelState.IsValid)
            {
                var orderfurnitures = _orderfurnitureRepository.GetAllOrderFurniture();
                int maxId = orderfurnitures.Max(f => (int?)f.Id) ?? 0;

                // Id обычно не задаём вручную — он генерируется БД
                // Если нужно, установите другие свойства из модели
                _orderfurnitureRepository.Add(new OrderFurniture
                {
                    Id = maxId + 1, //
                    Price = orderfurniture.Price,
                    //Description = orderfurniture.Description,
                    Provider = orderfurniture.Provider,
                });

                //_furnituresRepository.Save(); // если требуется явное сохранение
                return RedirectToAction(nameof(Index));
            }

            // Если валидация не прошла — возвращаем форму с ошибками
            return View(orderfurniture);
        }
    }
}
