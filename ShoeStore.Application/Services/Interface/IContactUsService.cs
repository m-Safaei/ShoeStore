using ShoeStore.Domain.DTOs.SiteSide.ContactUs;

namespace ShoeStore.Application.Services.Interface;

public interface IContactUsService
{
    void AddContactUs(ContactUsDTO contactUs);
}
