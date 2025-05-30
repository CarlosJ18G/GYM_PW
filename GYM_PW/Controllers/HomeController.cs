using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GYM_PW.Models;
using GYM_PW.Views.ContactView;

namespace GYM_PW.Controllers;

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

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Index1() { return View(); }


    public IActionResult Contactame()
    {
        return View();
    }

    public IActionResult PlanCards()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
