using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.SiteSide.ContactUs;
using ShoeStore.Domain.Entities.ContactUs;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Application.Services.Implementation;

public class ContactUsService : IContactUsService
{
	#region Ctor
	private readonly IContactUsRepository _contactUsRepository;
    public ContactUsService(IContactUsRepository contactUsRepository)
    {
        _contactUsRepository = contactUsRepository;
    }

    public void AddContactUs(ContactUsDTO contactUs)
    {
        ContactUs contact = new ContactUs()
        {
            FirstName = contactUs.FirstName,
            LastName = contactUs.LastName,
            Email = contactUs.Email,
            Messege = contactUs.Messege,
            Mobile = contactUs.Mobile,
           CreateDate  = DateTime.Now,
        };
        _contactUsRepository.AddContactUsToDatabase(contact);
        _contactUsRepository.SaveChange();
    }
    #endregion

}
