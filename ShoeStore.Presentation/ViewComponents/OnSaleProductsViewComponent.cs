using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;

namespace ShoeStore.Presentation.ViewComponents;

public class OnSaleProductsViewComponent : ViewComponent
{
    private readonly IProductService _productService;
    public OnSaleProductsViewComponent(IProductService productService)
    {
        _productService = productService;
    }


    public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellation = default)
    {
        return View("OnSaleProducts", await _productService.GetOnSaleProductDTOs(6, cancellation));
    }
}
