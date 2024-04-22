namespace ShoeStore.Domain.DTOs.SiteSide.ContactUs;

public class ContactUsAdminDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mobile { get; set; }
    public DateTime CreateDate { get; set; }
    public string Messege { get; set; }
    public bool IsSeen { get; set; }

}
