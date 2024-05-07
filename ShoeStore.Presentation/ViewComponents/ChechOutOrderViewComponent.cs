using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Application.Utilities;

namespace ShoeStore.Presentation.ViewComponents;
[ViewComponent(Name = "ChechOutOrder")]
public class ChechOutOrderViewComponent : ViewComponent
{
    public readonly IOrderService _orderService;
    public ChechOutOrderViewComponent(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellation=default)
    {
        return View("ChechOutOrder", await _orderService.FillInvoiceSiteSideViewModelAsync(User.GetUserId(), cancellation));
    }
}
