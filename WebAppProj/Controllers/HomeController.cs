using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc2.Models;

namespace mvc2.Controllers;

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

    public IActionResult Login()
    {
        return View();
    }
    public IActionResult LearningHub()
    {
        return View();
    }
    public IActionResult Connections()
    {
        return View();
    }
    public IActionResult Signup()
    {
        return View();
    }
    public IActionResult About()
    {
        return View();
    }
    public IActionResult Requests_R()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
