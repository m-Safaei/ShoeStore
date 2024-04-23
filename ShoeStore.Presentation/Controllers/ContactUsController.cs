using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.SiteSide.ContactUs;

namespace ShoeStore.Presentation.Controllers;

public class ContactUsController : Controller
{
    #region Ctor
    private readonly IContactUsService _serivce;
    public ContactUsController(IContactUsService service)
    {
        _serivce = service;
    }

    #endregion

    #region ContactUs
    [HttpGet]
    public IActionResult ContactUs()
    {
        return View();
    }
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult ContactUs(ContactUsDTO contactUsDTO)
    {
        if(ModelState.IsValid) 
        { 
             _serivce.AddContactUs(contactUsDTO);

             TempData["SuccessMessage"] = "عملیات باموفقیت انجام شد";
            return RedirectToAction("Index","Home");
        }
        return View(contactUsDTO);
    }

    #endregion
}
