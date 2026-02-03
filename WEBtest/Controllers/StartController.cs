using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEBtest.Models;

namespace WEBtest.Controllers
{
    public class StartController : Controller
    {
        public IActionResult Index(string name, int age)
        {
            return Content("Hello!");
        }

        public IActionResult Hello()
        {
            string answer = "";
            var time = DateTime.Now;
            if (time.Hour >= 0 && time.Hour < 6)
            {
                answer = "Доброй ночи";
            }
            if (time.Hour >= 6 && time.Hour < 12)
            {
                answer = "Доброе утро";
            }
            if (time.Hour >= 12 && time.Hour < 18)
            {
                answer = "Добрый день";
            }
            if (time.Hour >= 18 && time.Hour < 24)
            {
                answer = "Добрый вечер";
            }
            return Content(answer);
        }
    }
}
