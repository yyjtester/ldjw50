using System.ComponentModel.DataAnnotations;

namespace mvc2.Models;

public class Login
{
    [Required(ErrorMessage = "Please enter Email")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Please enter Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

}