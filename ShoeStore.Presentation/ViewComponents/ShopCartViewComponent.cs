using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Application.Utilities;
namespace ShoeStore.Presentation.ViewComponents;
public class ShopCartViewComponent: ViewComponent
{
    public readonly IOrderService _orderService;
    public ShopCartViewComponent(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellation = default)
    {
        return View("ShopCart", await _orderService.FillInvoiceSiteSideViewModelAsync(User.GetUserId(), cancellation));
    }
}
