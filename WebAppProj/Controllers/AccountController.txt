using mvc2.Utils;
using mvc2.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Data;

namespace mvc2.Controllers;

public class AccountController : Controller
{

        [AllowAnonymous]
    public IActionResult Login(string returnUrl = null!)
    {
        TempData["ReturnUrl"] = returnUrl;
        return View("Login");
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login(Login user)
    {
        if (!AuthenticateUser(user.email, user.password, out ClaimsPrincipal principal))
        {
            ViewData["Message"] = "Incorrect Email or Password";
            ViewData["MsgType"] = "warning";
            return View();
        } 
        else 
        {
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            if (TempData["returnUrl"] != null)
            {
                string returnUrl = TempData["returnUrl"]!.ToString()!;
                if (Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
            }

            return RedirectToAction("Home", "Index");
        }
    }  

    private static bool AuthenticateUser(string email, string password, out ClaimsPrincipal principal)
    {
        principal = null!;

        string sql = @"SELECT * FROM account WHERE account_email = '"+ email +"' AND password = '"+ password +"'";
        string select = string.Format(sql, email, password);
        DataTable ds = DBUtl.GetTable(select);
        if (ds.Rows.Count == 1)
        {
            return true;
        }
        return false;
    }

    /*private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
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

    public IActionResult Register()
    {
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home"); // Redirect to the home page after logout
    }*/
}