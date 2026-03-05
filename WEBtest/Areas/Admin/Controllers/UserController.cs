using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEBtest.Areas.Admin.Models;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBtest.Interfaces;
using WEBtest.Models;

namespace WEBtest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserRepository _usersRepository;
        private readonly IRoleRepository _rolesRepository;
        private readonly IRegistrationsRepository _registrationRepository;


        public UserController(IUserRepository usersRepository, IRoleRepository rolesRepository, IRegistrationsRepository registrationRepository)
        {
            _usersRepository = usersRepository;
            _rolesRepository = rolesRepository;
            _registrationRepository = registrationRepository;

        }
        public IActionResult Index()
        {
            //var roles2 = _usersRepository.GetAll();
            var roles = _registrationRepository.GetAll();


            //var roles = _registrationRepository.GetAll();

            return View(roles);                     // Роли полтзователей
        }
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(Registration registration,User user)
        {
            if (_usersRepository.TryGetByLogin(registration.Login) != null)
            {
                ModelState.AddModelError("",
                    "Такой пользователь уже существует!");
            }

            if (!ModelState.IsValid)
            {
                return View(registration);
            }

            _registrationRepository.Add(registration);
            //_usersRepository.Add(user);

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Detail(Guid id, Registration registration)   ///!!!
        {

         //   Registration? TryGetById(int registrationId);

            var user = _registrationRepository.TryGetById(registration.Id);
           // var user = _usersRepository.TryGetById(id);

            return View(user);
        }
        public IActionResult Delete(Guid id)
        {
            _usersRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(Guid id)
        {
            var existingUser = _usersRepository.TryGetById(id);

            return View(existingUser);
        }


        [HttpPost]
        public IActionResult Update(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            _usersRepository.Update(user);

            return RedirectToAction(nameof(Detail), new { _usersRepository.TryGetByLogin(user.Login)?.Id });
        }

        public IActionResult ChangePassword(Guid id)
        {
            var existingUser = _usersRepository.TryGetById(id);

            var changePassword = new ChangePassword()
            {
                Login = existingUser?.Login
            };

            return View(changePassword);
        }


        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (changePassword.Login == changePassword.Password)
            {
                ModelState.AddModelError("",
                    "Имя и пароль не должны совпадать");
            }

            if (!ModelState.IsValid)
            {
                return View(changePassword);
            }

            _usersRepository.ChangePassword(changePassword.Login, changePassword.Password);

            return RedirectToAction(nameof(Detail), new { _usersRepository.TryGetByLogin(changePassword.Login)?.Id });
        }

        public IActionResult ChangeRole(Guid id)
        {
            var existingUser = _usersRepository.TryGetById(id);  // изменение роли из _usersRepository



            var changeRole = new ChangeRole()
            {
                Login = existingUser?.Login,
                Role = existingUser?.Role?.ToString(),
                Roles = _rolesRepository.GetAll().Select(role => new SelectListItem() { Value = role.Name.ToString(), Text = role.Name }).ToList()
            };


            return View(changeRole);
        }



        [HttpPost]
        public IActionResult ChangeRole(ChangeRole changeRole)
        {
            if (!ModelState.IsValid)
            {
                return View(changeRole);
            }

            _usersRepository.ChangeRole(changeRole.Login, _rolesRepository.TryGetByName(changeRole.Role));

            return RedirectToAction(nameof(Detail), new { _usersRepository.TryGetByLogin(changeRole.Login)?.Id });
        }
    }
}
