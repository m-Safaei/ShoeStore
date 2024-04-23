using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;

namespace ShoeStore.Presentation.ViewComponents;
public class ListOfFavoriteProductsViewComponent : ViewComponent
{
    private readonly IFavoriteProductService _favoriteProductService;

    public ListOfFavoriteProductsViewComponent(IFavoriteProductService favoriteProductService)
    {
        _favoriteProductService = favoriteProductService;
    }

    public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellation = default)
    {
        return View("ListOfFavoriteProducts", await _favoriteProductService.GetListOfFavoriteProduct(cancellation));
    }
}

