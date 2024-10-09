using System.Diagnostics;
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
     */
    
    
    public IActionResult Calculator()
    {

        //https://localhost:7172/Home/Calculator?ap=add&x=4&y=1,5
        var op=Request.Query["op"];
        
        var x=double.Parse(Request.Query["x"]);
        
        var y=double.Parse(Request.Query["y"]);

        var result = 0.0d;

        switch (op)
        {
            case "add":
                result = x + y;
                ViewBag.Operator = "+";
                break;
            
            case "sub":
                result = x - y;
                ViewBag.Operator = "-";
                break;
            
            case "mul":
                result = x * y;
                ViewBag.Operator = "*";
                break;
            
            case "div":
                result = x / y;
                ViewBag.Operator = ":";
                break;
        }
        ViewBag.Resukt = result;
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