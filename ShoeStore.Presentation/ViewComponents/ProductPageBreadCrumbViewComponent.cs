using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;

namespace ShoeStore.Presentation.ViewComponents
{
    public class ProductPageBreadCrumbViewComponent : ViewComponent
    {
        private readonly IProductCategoryService _categoryService;
        public ProductPageBreadCrumbViewComponent(IProductCategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public async Task<IViewComponentResult> InvokeAsync(int childCategoryId,CancellationToken cancellation = default)
        {
            return View("ProductPageBreadCrumb", await _categoryService.GetProductPageBreadCrumbDTO(childCategoryId,cancellation));
        }
    }
}
