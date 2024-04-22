using ShoeStore.Domain.DTOs.SiteSide.ContactUs;
using ShoeStore.Domain.Entities.ContactUs;

namespace ShoeStore.Application.Services.Interface;

public interface IContactUsService
{
    void AddContactUs(ContactUsDTO contactUs);
    Task<List<ContactUsAdminDTO>> GetListOfContactUs(CancellationToken cancellation);
    Task<ContactUsDetailAdminDTO?> FillContactUsAdminDetailDTO(int Id,CancellationToken cancellationToken);

}
