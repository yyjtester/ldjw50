using System.ComponentModel.DataAnnotations;

namespace mvc2.Models;

public class Signup
{

    [Required(ErrorMessage = "Please enter your First Name")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Please enter your Last Name")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Please enter Email")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Please enter Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Please re-enter Password")]
    [DataType(DataType.Password)]
    public string Repeat { get; set; } = null!;
    
    public string UserRole { get; set; } = null!;

}