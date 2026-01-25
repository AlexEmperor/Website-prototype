using Microsoft.AspNetCore.Mvc;
using WEBtest.Models;

namespace WEBtest.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register(Registration registration)
        {
            return View();
        }
    }
}
