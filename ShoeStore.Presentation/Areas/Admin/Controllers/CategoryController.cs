using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;

namespace ShoeStore.Presentation.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        private readonly IProductCategoryService _categoryService;
        public CategoryController(IProductCategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public async Task<IActionResult> ListOfCategories(CancellationToken cancellation=default)
        {
            var model = await _categoryService.GetDTOsForListOfCategories(cancellation);
            return View(model);
        }


    }
}
