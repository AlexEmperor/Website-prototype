using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WEBtest.Models;

namespace WEBtest.Controllers
{
    public class CalculatorController : Controller
    {
       /* public IActionResult Index()
        {
            return View();
        }*/
        public IActionResult Index(double a, double b, string c = "+")
        {
            double result = 0;
            switch(c)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    if (b != 0)
                    {
                        result = a / b;
                    }
                    break;
                default:
                    return Content("Ошибка: Некорректная операция. Допустимые операции: +, -, *");
            }

            return Content($"{a} {c} {b} = {result}");
            
        }

    }
}
