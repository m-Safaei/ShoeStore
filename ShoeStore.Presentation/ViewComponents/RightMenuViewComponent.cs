using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;

namespace ShoeStore.Presentation.ViewComponents
{
    public class RightMenuViewComponent : ViewComponent
    {
        private readonly IProductCategoryService _productCategoryService;

        public RightMenuViewComponent(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellation = default)
        {
            return View("RightMenu", await _productCategoryService.GetParentWithChildCategory(cancellation));
        }
    }
}
