using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.DTOs.SiteSide.Account;
public record EditProfileSiteSideDto
{
    public int Id { get; set; }

    [StringLength(40, MinimumLength = 3, ErrorMessage = "نام باید بیشتر از 2 کاراکتر داشته باشد")]
    public string FirstName { get; set; }

    [StringLength(40, MinimumLength = 3, ErrorMessage = "نام خانوادگی باید بیشتر از 2 کاراکتر داشته باشد")]
    public string LastName { get; set; }

    [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره موبایل معتبر نیست")]
    public string Mobile { get; set; }

    [StringLength(50, MinimumLength = 3, ErrorMessage = "پسوورد معتبر نیست")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "کلمه‌ی عبور و تکرار آن یکسان نیستند")]
    public string? RePassword { get; set; }

    public string? UserOriginalAvatar { get; set; }

    public IFormFile? UserAvatar { get; set; }
}

