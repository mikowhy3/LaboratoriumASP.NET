using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: CalculatorController
        public ActionResult Index()
        {
            return View();
        }

        
        public IActionResult Form()
        {
            return View();
        }

        public enum Operator
        {
            Add,Sub,Mul,Div
        }
        // metoda ma przyjmowac ten czasownik
        [HttpPost]
        public IActionResult Result(Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            else
            {
                return View(model);    
            }
            
        }
        
        /*
        // nazwa op musi byc taka sama jak w form czyli tez op bo sie wywali
        public IActionResult Result(Operators? op, double? x, double? y)
        {
            if (x is null || y is null)
            {
                ViewBag.ErrorMessage = "Niepoprawny format x albo y lub ich brak";
                return View("CalculatorError");
            }

            if (op is null)
            {
                ViewBag.ErrorMessage = "Nieznany operator";
                return View("CalculatorError");
            }
       
            double? result = 0.0d;

            switch (op)
            {
                case Operators.Add:
                    result = x + y;
                    ViewBag.Operator = "+";
                    break;
            
                case Operators.Sub:
                    result = x - y;
                    ViewBag.Operator = "-";
                    break;
            
                case Operators.Mul:
                    result = x * y;
                    ViewBag.Operator = "*";
                    break;
            
                case Operators.Div:
                    result = x / y;
                    ViewBag.Operator = ":";
                    break;
            
           
            }

            ViewBag.Result = result;
            ViewBag.X = x;
            ViewBag.Y = y;
            //ViewBag.Operator = op;
            return View();
        }
        */
        
    }
}
