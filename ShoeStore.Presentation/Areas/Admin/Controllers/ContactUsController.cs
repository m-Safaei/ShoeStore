
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

            //Change Message State
            if (detail != null)
            {
                await _service.ChangeMessageState(Id, cancellationToken);
            }

            return View(detail);
        }

        public async Task<IActionResult> DeleteContactUs(int id, CancellationToken cancellation)
        {
            var res = await _service.DeleteContactUs(id, cancellation);
            if (res)
            {
                TempData["SuccessMessage"] = "Success";
            }
            else
            {
                TempData["ErrorMessage"] = "failed";
            }

            return RedirectToAction(nameof(ListOfContactUs));
        }

    }
}
