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
    public class OrderFurnitureController(IFurnituresRepository furnitureRepository) : Controller
    {
        private readonly IFurnituresRepository _furnitureRepository = furnitureRepository;

        public IActionResult Index()
        {
            var orders = _furnitureRepository.GetAll();

            return View(orders.ToOrderFurnitureViewModels());
            //return View(orders.ToOrderFurnitureViewModels().OrderByDescending(x => x.CreationDateTime).ToList());
        }

    }
}
