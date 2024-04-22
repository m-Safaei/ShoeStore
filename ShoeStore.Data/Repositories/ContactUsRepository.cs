using Microsoft.EntityFrameworkCore;
using ShoeStore.Application.Utilities;
using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.DTOs.SiteSide.ContactUs;
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

    #endregion

    public void AddContactUsToDatabase(ContactUs contactUs)
    {
        _context.ContactUs.Add(contactUs);
    }

    public void SaveChange()
    {
        _context.SaveChanges();
    }

    public async Task<List<ContactUsAdminDTO>> GetListOfContactUs(CancellationToken cancellation)
    {
        return await _context.ContactUs.OrderByDescending(p => p.CreateDate).Select(p => new ContactUsAdminDTO()
        {
            Id = p.Id,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Mobile = p.Mobile,
            CreateDate = p.CreateDate,
            Messege = p.Messege,
        })
            .ToListAsync();
    }

    public async Task<ContactUs?> GetCotnactUsByIdAsync(int Id, CancellationToken cancellationToken)
    {
        return await _context.ContactUs.FindAsync(Id);
    }

}
