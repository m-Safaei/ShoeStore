using ShoeStore.Domain.DTOs.SiteSide.ContactUs;
using ShoeStore.Domain.Entities.ContactUs;

namespace ShoeStore.Domain.IRepositories;

public interface IContactUsRepository
{
    void AddContactUsToDatabase(ContactUs contactUs);
    void SaveChange();
    Task<List<ContactUsAdminDTO>> GetListOfContactUs(CancellationToken cancellation);
    Task<ContactUs?> GetCotnactUsByIdAsync(int Id,CancellationToken cancellationToken);
}
