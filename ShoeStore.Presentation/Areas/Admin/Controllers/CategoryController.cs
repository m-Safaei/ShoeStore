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


        public async Task<IActionResult> DeleteCategory(int categoryId,CancellationToken cancellation=default)
        {
            var model = await _categoryService.GetEditCategoryDTOById(categoryId, cancellation);
            return View(model);
        }


        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategoryRecord(int categoryId, CancellationToken cancellation = default)
        {
            var res = await _categoryService.DeleteCategory(categoryId, cancellation);
            if (res) return RedirectToAction(nameof(ListOfCategories));
            else return RedirectToAction(nameof(DeleteCategory),categoryId);
        }


        public async Task<IActionResult> EditCategory(int categoryId, CancellationToken cancellation=default)
        {
            var model = await _categoryService.GetEditCategoryDTOById(categoryId, cancellation);
            return View(model);
        }


        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(EditCategoryDTO category, CancellationToken cancellation = default)
        {
            var res = await _categoryService.EditCategory(category, cancellation);
            if (res) return RedirectToAction(nameof(ListOfCategories));
            else return View(category);
        }
    }
}
