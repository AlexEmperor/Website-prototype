using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBtest.Db.Repositories;
using WEBtest.Helpers;
using WEBtest.Interfaces;
using WEBtest.Models;


namespace WEBtest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderFurnitureController(IOrderFurnituresRepository orderfurnitureRepository, IFurnituresRepository furnitureRepository) : Controller
    {
         private readonly IOrderFurnituresRepository _orderfurnitureRepository = orderfurnitureRepository;
         private readonly IFurnituresRepository _furnitureRepository = furnitureRepository;



        public IActionResult Index()
        {
            var orderfurnitures = _orderfurnitureRepository.GetAllOrderFurniture();

            return View(orderfurnitures.ToOrderFurnitureViewModels().OrderByDescending(x => x.Id).ToList());
        }


        /*
        public IActionResult Index()
        {

            var orderfurnitures = _orderfurnitureRepository.GetAllOrderFurniture().ToOrderFurnitureViewModels().OrderBy(product => product.Id).ToList();
            return View(orderfurnitures);

            //return View(orderfurnitures.ToOrderFurnitureViewModels().OrderByDescending(x => x.Id).ToList());
            //var products = _productsRepository.GetAll().ToProductViewModels().OrderBy(product => product.Id).ToList();
        }
        */
        //public IActionResult Index()
        //{
        //    var orders = _orderfurnitureRepository.GetAllOrderFurniture();


        //    return View(orders.ToOrderFurnitureViewModels());
        //    //return View(orders.ToOrderFurnitureViewModels().OrderByDescending(x => x.CreationDateTime).ToList());


        //}
        
/*
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
                            Description = orderfurniture.Description,
                            Provider = orderfurniture.Provider,
                            OrderPlace = orderfurniture.OrderPlace,
                            Furnitures = orderfurniture.Furnitures,
                            FurnituresId = orderfurniture.FurnituresId,

                        });

                        //_furnituresRepository.Save(); // если требуется явное сохранение
                        return RedirectToAction(nameof(Index));
                    }

                    // Если валидация не прошла — возвращаем форму с ошибками
                    return View(orderfurniture);
                }
        
*/

        public IActionResult Add(OrderFurnitureViewModel orderfurniture)
        {

                ViewBag.Furniture = _furnitureRepository.GetAllFurniture()
             .Select(o => new SelectListItem
             {
                 Value = o.Id.ToString(),
                 Text = o.Name.ToString(),
             }).ToList();

            var orderfurnitures = _orderfurnitureRepository.GetAllOrderFurniture();
            int maxId = orderfurnitures.Max(f => (int?)f.Id) ?? 0;
            


            if (ModelState.IsValid)
            {
                string nn = ViewBag.Furniture[1].Value;
                _orderfurnitureRepository.Add(new OrderFurniture
            {
                Id = maxId + 1, //
                Price = orderfurniture.Price,
                Description = orderfurniture.Description,
                Provider = orderfurniture.Provider,
                OrderPlace = orderfurniture.OrderPlace,
                OrderCreationDateTime = orderfurniture.OrderCreationDateTime,
                Volume = orderfurniture.Volume,
                Furnitures = orderfurniture.Furnitures,
                FurnituresId = orderfurniture.FurnituresId,
            });


                //_furnituresRepository.Save(); // если требуется явное сохранение
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        /*
        public IActionResult Add()
        {
            ViewBag.Furnitures = _orderfurnitureRepository.GetAllOrderFurniture()
        .Select(o => new SelectListItem
        {   Value = o.Id.ToString(),
            Text = o.Furnitures.Name.ToString()
        }).ToList();

            //return RedirectToAction(nameof(Index));
            return View();
        }
        */
    }
}
