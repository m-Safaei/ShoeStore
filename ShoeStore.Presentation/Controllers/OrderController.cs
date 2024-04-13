#region MyRegion
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.Entities.Order;
using ShoeStore.Domain.Entities.Product;
using ShoeStore.Domain.Entities.User;

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
    int _userId = 4;
    int _id =2;
    public async Task<IActionResult> AddToShopCart(int? Id,CancellationToken cancellationToken=default)
    {
        if (_id == null)
        {
          return NotFound();
        }
        //int _userId:int =
        

        Product _product = await _productService.GetProductByIdAsync(_id, cancellationToken);
        
        if (_orderService.IsExistOrderForUserInToday(_userId))
        {
            Order order = _orderService.GetOrderForCart(_userId);
            if (_orderService.IsExistOrderItemFromUserFromToday(order.Id, _product.Id))
            {
                _orderService.AddOneMoreProductToTheShopCart(order.Id,_product.Id);
            }
            else
            {
               _orderService.AddProductToOrderItem(_product.Id, order.Id,_product.Price);
            }
        }
        else
        {
            int OrderId = _orderService.AddOrderToTheShopCart(_userId);
        }
        return View();

    }
    public async Task<IActionResult> PlusProductOrderItem(int id)
    {
        int OrderItemID = 1;
        //if (id==null)
        //{
        //    return NotFound();
        //}
        _orderService.PlusProductToTheOrderItem(OrderItemID);
        return View();
    }
    public async Task<IActionResult> MinusProductOrderItem(int id)
    {
        int OrderItemID = 1;
        //if (id==null)
        //{
        //    return NotFound();
        //}
        _orderService.MinusProductToTheOrderItem(OrderItemID);
        return View();
    }
    //public async Task<IActionResult> ShopCart()
    //{
    //    Order order=_orderService.GetOrderForCart(_userId);

    //}
}
