using System.ComponentModel.DataAnnotations;

namespace mvc2.Models;

public class Login
{
    [Required(ErrorMessage = "Please enter Email")]
    public string email { get; set; } = null!;

    [Required(ErrorMessage = "Please enter Password")]
    [DataType(DataType.Password)]
    public string password { get; set; } = null!;

}