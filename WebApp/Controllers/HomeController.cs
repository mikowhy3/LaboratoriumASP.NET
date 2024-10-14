using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    
    /*
     *
     * Utworz metode Calculator oraz widok, w nim wyswietl tylko napis Kalkulator
     * Dodaj link w nawigacji aplikacji do metody calculator
     *
     *
     *
     *
     * ZAD 2
     *
     * NAPISZ METODE AGE, KTORA PRZYJMUJE PARAMETR Z DATA URODZIN I WYSWIETLA WIEK
     * W LATACH, MIESIACACH I DNIACH.
     */
    

    public IActionResult Age(int year, int month, int day)
    {
        try
        {
            // Zbudowanie daty z trzech parametrów
            DateTime parametr = new DateTime(year, month, day);
        
            // Aktualna data
            DateTime currentDateTime = DateTime.Now;

            // Oblicz różnicę między datą obecną a podaną datą
            TimeSpan wynik = currentDateTime - parametr;

            // Oblicz lata, miesiące i dni
            int years = currentDateTime.Year - parametr.Year;
            int months = (currentDateTime.Year - parametr.Year)*12+(currentDateTime.Month - parametr.Month);

            // Przekazanie wartości do ViewBag
            ViewBag.years = years;
            ViewBag.months = months;
            ViewBag.wynik = wynik;  // Całkowita różnica czasu

            // Przekierowanie do widoku
            return View();
        }
        catch (Exception ex)
        {
            // Obsługa błędów np. niepoprawna data
            ViewBag.ErrorMessage = "Wprowadzono nieprawidłową datę.";
            return View();
        }
    }


    
    public IActionResult Calculator(Operator? op, double? x, double? y)
    {

        //https://localhost:7172/Home/Calculator?ap=add&x=4&y=1,5
       // var op=Request.Query["op"];
        
        //var x=double.Parse(Request.Query["x"]);
        
       // var y=double.Parse(Request.Query["y"]);


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
            case Operator.Add:
                result = x + y;
                ViewBag.Operator = "+";
                break;
            
            case Operator.Sub:
                result = x - y;
                ViewBag.Operator = "-";
                break;
            
            case Operator.Mul:
                result = x * y;
                ViewBag.Operator = "*";
                break;
            
            case Operator.Div:
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
    public IActionResult About()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public enum Operator
{
 Add,Sub,Mul,Div
}

/*

*/