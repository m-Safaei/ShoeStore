using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.AdminSide.Product;

namespace ShoeStore.Presentation.Areas.Admin.Controllers
{
    public class SizeController : AdminBaseController
    {
        private readonly ISizeService _sizeService;
        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }



        public async Task<IActionResult> ListOfSizes(CancellationToken cancellation = default)
        {
            var model = await _sizeService.GetListOfSizeDTOs(cancellation);
            return View(model);
        }


        public IActionResult CreateSize()
        {
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSize(SizeAdminSideDTO sizeDTO, CancellationToken cancellation = default)
        {
            if (ModelState.IsValid)
            {
                var res = await _sizeService.CreateSize(sizeDTO, cancellation);
                if (res) return RedirectToAction(nameof(ListOfSizes));
            }

            return View(sizeDTO);
        }


        public async Task<IActionResult> EditSize(int sizeId, CancellationToken cancellation)
        {
            var model = await _sizeService.GetSizeDTOById(sizeId, cancellation);
            if (model == null) return Redirect("NotFound");
            return View(model);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSize(SizeAdminSideDTO sizeDTO, CancellationToken cancellation = default)
        {
            if(ModelState.IsValid)
            {
                var res = await _sizeService.EditSize(sizeDTO, cancellation);
                if (res) return RedirectToAction(nameof(ListOfSizes));
            }

            return View(sizeDTO);
        }


        public async Task<IActionResult> DeleteSize(int sizeId,CancellationToken cancellation = default)
        {
            var model = await _sizeService.GetSizeDTOById(sizeId, cancellation);
            if (model == null) return Redirect("NotFound");
            return View(model);
        }


        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSize(SizeAdminSideDTO sizeDTO ,  CancellationToken cancellation = default)
        {
            var res = await _sizeService.DeleteSize(sizeDTO, cancellation);
            if (res) return RedirectToAction(nameof(ListOfSizes));
            return View(sizeDTO);
        }
    }
}
