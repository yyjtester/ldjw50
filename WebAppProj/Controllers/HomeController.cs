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
using MySql.Data.MySqlClient;

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

    public IActionResult Login(string returnUrl = null!)
    {
        TempData["ReturnUrl"] = returnUrl;
        return View();
    }

/*    [Authorize]
    public IActionResult Logoff(string returnUrl = null!)
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);
        return RedirectToAction("Index", "Home");
    }*/

    /*[AllowAnonymous]
    [HttpPost]
    public IActionResult Signup(Signup user)
    {
        if (user.)
    }*/

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login(Login user)
    {
        
        if (!AuthenticateUser(user.Email, user.Password))
        {
            //ViewData["Message"] = DBUtl.DB_Message;
            //ViewData["MsgType"] = "warning";
            return View("Login");
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }
    }

    private static bool CreateUser(string FirstName, string LastName, string Email, string Password, string UserRole)
    {
        string connectionString = "server=db4free.net;database=foodaid;user=fypuser;password=d4dHF#G5g6#q;";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string sql = "INSERT INTO account(account_name, account_email, first_name, last_name, user_role, account_password) VALUES(@LastName, @Email, @FirstName, @LastName, @UserRole, @Password);";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@UserRole", UserRole);

                int count = Convert.ToInt32(command.ExecuteScalar());

                return count == 1;
            }
        }
    }

    private static bool AuthenticateUser(string Email, string Password)
    {
        string connectionString = "server=db4free.net;database=foodaid;user=fypuser;password=d4dHF#G5g6#q;";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string sql = "SELECT COUNT(*) FROM account WHERE account_email = @Email AND account_password = @Password";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Password", Password);

                int count = Convert.ToInt32(command.ExecuteScalar());

                return count == 1;
            }
        }
        
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
