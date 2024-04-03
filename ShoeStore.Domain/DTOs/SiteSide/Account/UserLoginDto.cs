using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.DTOs.SiteSide.Account;

public class UserLoginDto
{
    [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره موبایل معتبر نیست")]
    public string Mobile { get; set; }

    [StringLength(50, MinimumLength = 3, ErrorMessage = "پسوورد معتبر نیست")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "کلمه‌ی عبور و تکرار آن یکسان نیستند")]
    public string RePassword { get; set; }

    public string? ReturnUrl { get; set; }
}

