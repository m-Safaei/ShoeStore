using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.AdminSide.Category;

namespace ShoeStore.Presentation.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        private readonly IProductCategoryService _categoryService;
        public CategoryController(IProductCategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public async Task<IActionResult> ListOfCategories(CancellationToken cancellation = default)
        {
            var model = await _categoryService.GetDTOsForListOfCategories(cancellation);
            return View(model);
        }


        public IActionResult CreateCategory(int? parentId,string? parentName)
        {
            CreateCategoryDTO model = new();
            if (parentId != null)
            {
                model.ParentId = parentId;
                model.ParentName = parentName;
            }

            return View(model);
        }


        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO categoryDTO , CancellationToken cancellation=default)
        {
            if(ModelState.IsValid)
            {
                await _categoryService.CreateCategory(categoryDTO, cancellation);
                return RedirectToAction(nameof(ListOfCategories));
            }
            return View(categoryDTO);
        }
    }
}
