
using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.SiteSide.ContactUs;

namespace ShoeStore.Presentation.Areas.Admin.Controllers
{
    public class ContactUsController : AdminBaseController
    {
        #region Ctor
        private readonly IContactUsService _service;
        public ContactUsController(IContactUsService service)
        {
            _service = service;
        }
        #endregion
        public async Task<IActionResult> ListOfContactUs(CancellationToken cancellationToken)
        {
            var list = await _service.GetListOfContactUs(cancellationToken);
            return View(list);
        }

        public async Task<IActionResult> ContactUsDetail(int Id, CancellationToken cancellationToken)
        {
            var detail = await _service.FillContactUsAdminDetailDTO(Id, cancellationToken);

            return View(detail);
        }



    }
}
