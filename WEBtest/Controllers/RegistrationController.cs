using Microsoft.AspNetCore.Mvc;
using System.Net;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBtest.Db.Repositories;
using WEBtest.Helpers;
using WEBtest.Interfaces;
using WEBtest.Models;


namespace WEBtest.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationsRepository _registrationRepository;  // зарегистрированный репозиторий
        private readonly IUserRepository _usersRepository; 


        private readonly IRoleRepository _rolesRepository;

        [HttpPost]  // Авторизация пользователя
        public IActionResult Autorization(Autorization autorization)
        {
            if (autorization.Password == autorization.Login)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }

            var existingUser = _usersRepository.TryGetByLogin(autorization.Login);

            if (existingUser == null)
            {
                ModelState.AddModelError("", "Такого пользователя не существует!\r\nПройдите регистрацию!");
            }

            if (autorization.Password != existingUser?.Password)
            {
                ModelState.AddModelError("", "Неправильный пароль пользователя!");
            }
            if (!ModelState.IsValid)
            {
                return View(autorization);
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        public RegistrationController(IUserRepository usersRepository, IRoleRepository rolesRepository, IRegistrationsRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
            _rolesRepository = rolesRepository;
            _usersRepository = usersRepository;
        }
        public IActionResult Autorization()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }




        public IActionResult Registration()  // Нажатие на кнопку регистрации // на панели администратора// вывод страницы Регитрации
        {
            return View();
        }
 /*

        public IActionResult Registration(Registration registration)
        {
            _registrationRepository.Add(registration);

            return RedirectToAction(nameof(Index), "Home");
        }
*/

        [HttpPost]
        public IActionResult Registration(Registration registration)
        {
            //Проверка что пароль и логин не совпадает
            if (registration.Password == registration.Login)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }
/*
            //Registration? TryGetById(int registrationId);
            //User? TryGetByLogin(string login);
            //var existingUser = _registrationRepository.TryGetById(registration.Id);
            // var existingUser = _usersRepository.TryGetByLogin(registration.Login);
*/

            if (_registrationRepository.TryGetById(registration.Id) != null) // проверка по ID поиск есть ли такой пользователь
            {
                ModelState.AddModelError("", "Пользователь с таким логином уже зарегистрирован!\r\n" +
                    "Необходимо зарегистрироваться под другим логином!");
            }

            if (!ModelState.IsValid)
            {
                return View(registration);
            }

            var user = new User()
            {
                Login = registration.Login,
                Password = registration.Password,
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                Phone = registration.Phone,
            };

            _usersRepository.Add(user);
            _registrationRepository.Add(registration);

            return RedirectToAction(nameof(Index), "Home");



            // return View();
        }

    }
}
