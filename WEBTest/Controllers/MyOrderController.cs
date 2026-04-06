using Microsoft.AspNetCore.Mvc;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBtest.Helpers;
using WEBtest.Interfaces;
using WEBtest.Models;

namespace WEBtest.Areas.Admin.Controllers
{
    public class MyOrderController(IOrdersRepository ordersRepository) : Controller
    {
        private readonly IOrdersRepository _ordersRepository = ordersRepository;




        public IActionResult MyOrderVie()   // Вызов страницы категория Сережек
        {
            var orders = _ordersRepository.GetAll();
            return View(orders.ToOrderViewModels().OrderByDescending(x => x.CreationDateTime).ToList());

            //return View(_ordersRepository.GetAll().ToProductViewModels().OrderBy(product => product.Id).ToList());
        }


    }
}
