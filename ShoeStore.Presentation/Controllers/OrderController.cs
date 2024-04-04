#region MyRegion
using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.Entities.Order;
using ShoeStore.Domain.Entities.Product;

namespace ShoeStore.Presentation.Controllers;
#endregion
public class OrderController : Controller
{
    #region ctor
    public readonly IUserService _userService; 
    public readonly IProductService _productService;
    public readonly IOrderService _orderService;
    public OrderController (IUserService userService, IProductService productService,IOrderService orderService)
    {
        _userService = userService;
        _productService = productService;
        _orderService = orderService;
    }
    #endregion
    public async Task<IActionResult> AddToShopCart(int? Id)
    {
        //if (Id == null)
        //{
        //    return NotFound();
        //}
        int _userId = 2;
  
        //Product _product =await _productService.GetProductByIdAsync((int)Id);
        //if (_orderService.IsExistOrderForUserInToday(_userId))
        //{
        //    Order order=_orderService.GetOrderForCart(_userId);
        //    if (_orderService.IsExistOrderItemFromUserFromToday(order.Id, _product.Id))
        //    {

        //    }
        //    else
        //    {
                
        //        _orderService.AddProductToOrderItem(_product.Id,order.Id,);
        //    }
        //}
        //else
        //{
        //    int OrderId = _orderService.AddOrderToTheShopCart(_userId);
        //}
        return View();

    }
}
