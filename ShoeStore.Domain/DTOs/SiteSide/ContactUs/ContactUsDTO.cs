using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.DTOs.SiteSide.ContactUs;

public class ContactUsDTO
{
    [StringLength(40, MinimumLength = 3, ErrorMessage = "نام باید بیشتر از 2 کاراکتر داشته باشد")]
    public string FirstName { get; set; }

    [StringLength(40, MinimumLength = 3, ErrorMessage = "نام خانوادگی باید بیشتر از 2 کاراکتر داشته باشد")]
    public string LastName { get; set; }

    [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره موبایل معتبر نیست")]
    public string Mobile { get; set; }

    [EmailAddress(ErrorMessage = "ایمیل معتبر نیست")]
    public string Email { get; set; }

    [StringLength(500, MinimumLength = 5, ErrorMessage = "متن پیام باید بیشتر از 5 کاراکتر داشته باشد")]
    public string Messege { get; set; }
}
