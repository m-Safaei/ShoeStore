using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;

namespace ShoeStore.Presentation.ViewComponents
{
    public class RelatedProductsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;
        public RelatedProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId,CancellationToken cancellation=default)
        {
            var productPostDTOs = await _productService.GetProductPostDTOsByCategoryId(categoryId, 6, cancellation);
            return View("RelatedProducts",productPostDTOs);
        }
    }
}
