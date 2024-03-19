using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.DTOs.SiteSide.Account;

public class UserRegisterDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mobile { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "کلمه‌ی عبور و تکرار آن یکسان نیستند")]
    public string RePassword { get; set; }
    public string? ReturnUrl { get; set; }
}

