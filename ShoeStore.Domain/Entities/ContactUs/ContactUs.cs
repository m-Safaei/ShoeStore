
using ShoeStore.Domain.Common;

namespace ShoeStore.Domain.Entities.ContactUs;

public class ContactUs : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Messege { get; set; }
    public bool IsSeen { get; set; }

}
