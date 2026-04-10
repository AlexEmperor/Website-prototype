using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBtest.Helpers;
using WEBtest.Interfaces;
using WEBtest.Models;
using WEBTest.Db;

namespace WEBtest.Areas.Admin.Controllers
{
    public class MyOrderController(IOrdersRepository ordersRepository, UserManager<UserDTO> userManager) : Controller
    {
        private readonly IOrdersRepository _ordersRepository = ordersRepository;




        public IActionResult MyOrderVie()   // Вызов страницы категория Сережек
        {
            var appUser = userManager.GetUserAsync(User);
            if (appUser.Result != null)

            {
                string? login = appUser.Result.UserName;

                var ordersS = _ordersRepository.GetAll().ToOrderViewModels().OrderBy(product => product.Id).Where(o => o.DeliveryUser.Login == login).ToList();
                return View(ordersS);
            }
            else
            {
                return View();
            }

            // var orders = _ordersRepository.GetAll();
            //return View(orders.ToOrderViewModels().OrderByDescending(x => x.CreationDateTime).ToList());

            //return View(_ordersRepository.GetAll().ToProductViewModels().OrderBy(product => product.Id).ToList());
        }





    }
}
