using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc2.Models;
using mvc2.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace mvc2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _configuration;

    public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login(Login user)
    {
        if (!AuthenticateUser(user.Email, user.Password))
        {
            ViewData["Message"] = "Incorrect email or password";
            return View();
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }
    }
            /*//email = "yj@gmail.com";
            //password = "djejdeo23";
            string sql = "SELECT * FROM account WHERE account_email = '" + email + "' AND account_password = '" + password + "'";

            string select = string.Format(sql, email, password);
            DataTable ds = DBUtl.GetTable(sql);

                if (ds.Rows.Count == 1)
                {
                    // Login successful
                    //return Json(new { success = true });
                    return View("Index");
                    
                }
                else
                {
                    // Login failed
                    //return Json(new { success = false });
                    return View("Login");
                    

                }

    }*/

    

    private static bool AuthenticateUser(string Email, string Password)
    {

        string sql = @"SELECT * FROM account WHERE account_email = '{0}' AND account_password = '{1}'";
        string select = string.Format(sql, Email, Password);
        DataTable ds = DBUtl.GetTable(select);
        if (ds.Rows.Count == 1)
        {
            return true;
        }
        return false;
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
    public IActionResult Donations_D()
    {
        return View();
    }

    public IActionResult Request()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
