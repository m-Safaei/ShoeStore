using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;

namespace ShoeStore.Presentation.ViewComponents;

public class NewProductsViewComponent : ViewComponent
{
    private readonly IProductService _productService;
    public NewProductsViewComponent(IProductService productService)
    {
        _productService = productService;
    }


    public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellation=default)
    {
        return View("NewProducts", await _productService.GetNewProductDTOs(6,cancellation));
    }
}
