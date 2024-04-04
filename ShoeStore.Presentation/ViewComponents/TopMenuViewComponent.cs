using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;

namespace ShoeStore.Presentation.ViewComponents
{
    public class TopMenuViewComponent : ViewComponent
    {
        private readonly IProductCategoryService _productCategoryService;
        public TopMenuViewComponent(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellation=default)
        {
            return View("TopMenu", await _productCategoryService.GetParentWithChildCategory(cancellation));
        }
    }
}
