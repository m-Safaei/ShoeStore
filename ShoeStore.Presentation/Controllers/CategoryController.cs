using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;

namespace ShoeStore.Presentation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductService _productService;
        public CategoryController(IProductService productService)
        {
            _productService = productService;
        }


        public async Task<IActionResult> Index(int categoryId, int pageNumber = 1, string order = "New", CancellationToken cancellation = default)
        {
            var model = await _productService.GetCategoryPageDTOById(categoryId, pageNumber, order,cancellation);
            if (model == null) return Redirect("/Product/ProductNotFound");
            return View(model);
        }


        public async Task<IActionResult> ProductListByCategoryName(string categoryName, int pageNumber = 1, string order = "New", CancellationToken cancellation = default)
        {
            var model = await _productService.GetCategoryPageDTOByName(categoryName, pageNumber, order, cancellation);
            if (model == null) return Redirect("/Product/ProductNotFound");
            return RedirectToAction(nameof(Index), new { categoryId=model.CategoryId, pageNumber=pageNumber, order=order});
        }
    }
}
