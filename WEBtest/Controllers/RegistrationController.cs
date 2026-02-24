using Microsoft.AspNetCore.Mvc;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBtest.Helpers;
using WEBtest.Interfaces;
using WEBtest.Models;

namespace WEBtest.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationsRepository _registrationRepository;

        public RegistrationController(IRegistrationsRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Addition(Registration registration)
        {
            _registrationRepository.Add(registration);
            return View(_registrationRepository);
        }
        public IActionResult Add(Registration registration)
        {
            _registrationRepository.Add(registration);

            return RedirectToAction(nameof(Index), "Home");
        }

    }
}
