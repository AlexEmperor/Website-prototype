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
    public class OrderFurnitureController(IOrderFurnitureRepository ordersFurnitureRepository) : Controller
    {
        private readonly IOrderFurnitureRepository _ordersfurnitureRepository = ordersFurnitureRepository;

        public IActionResult Index()
        {
            var ordersfurniture = _ordersfurnitureRepository.GetAll();

            return View(ordersfurniture); //!!!
           // return View(ordersfurniture.OrderByDescending(x => x.CreationDateTime).ToOrderFurnitureViewModels().ToList());
        }

    }
}
