using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.DTOs.SiteSide.ContactUs;

public class ContactUsDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Messege { get; set; }
}
