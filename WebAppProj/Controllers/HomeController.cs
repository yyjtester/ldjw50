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
    public IActionResult Login(string email, string password)
    {
        // Initialize a connection string based on your appsettings configuration
        string connectionString = _configuration.GetConnectionString("DefaultConnection");

        // Use a using statement to ensure proper disposal of resources
        //using (SqlConnection connection = new SqlConnection(connectionString))
        //{

            // Construct the SQL query with parameters to prevent SQL injection
            string sql = "SELECT * FROM account WHERE account_email = @Email AND account_password = @Password";
            
            int result = DBUtl.ExecSQL(sql, "@Email", email, "@Password", password);

            //using (SqlCommand command = new SqlCommand(sql, connection))
            //{
                
                //command.Parameters.AddWithValue("@Email", email);
                //command.Parameters.AddWithValue("@Password", password);
                
                //connection.Open();

                //using (SqlDataReader reader = command.ExecuteReader())
                //{
                
                //int result = (int)command.ExecuteScalar();

                if (result > 0)
                {
                    // Login successful
                    return Json(new { success = true });
                }
                else
                {
                    // Login failed
                    return Json(new { success = false });
                }
                //}
            //}
            
        //}
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
