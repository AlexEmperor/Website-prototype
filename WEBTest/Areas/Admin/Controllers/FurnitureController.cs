using Microsoft.AspNetCore.Mvc;
using WEBtest.Db.Interfaces;
using WEBtest.Helpers;

namespace WEBtest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FurnitureController(IFurnituresRepository furnituresRepository) : Controller
    {
        private readonly IFurnituresRepository _furnituresRepository = furnituresRepository;

        //public IActionResult Index()
        //{
        //    var furnitures = _furnituresRepository.GetAll();

        //    return View(furnitures.ToOrderFurnitureViewModels().OrderByDescending(x => x.Id).ToList());
        //}
        public IActionResult Index()
        {
            var furnitures = _furnituresRepository.GetAllFurniture();

            return View(furnitures.ToFurnitureViewModels().OrderByDescending(x => x.Id).ToList());
        }

    }
}
