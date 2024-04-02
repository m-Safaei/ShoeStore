using ShoeStore.Domain.Entities.ContactUs;

namespace ShoeStore.Domain.IRepositories;

public interface IContactUsRepository
{
    void AddContactUsToDatabase(ContactUs contactUs);
    void SaveChange();

}
