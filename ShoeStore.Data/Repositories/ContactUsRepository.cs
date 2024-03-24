using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.Entities.ContactUs;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Data.Repositories;

public class ContactUsRepository : IContactUsRepository
{
	#region Ctor
	private readonly ShoeStoreDbContext _context;
    public ContactUsRepository(ShoeStoreDbContext context)
    {
        _context = context;
    }

    public void AddContactUsToDatabase(ContactUs contactUs)
    {
        _context.ContactUs.Add(contactUs);
    }

    public void SaveChange()
    {
        _context.SaveChanges();
    }


    #endregion


}
