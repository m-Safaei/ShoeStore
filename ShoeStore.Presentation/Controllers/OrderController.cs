#region MyRegion
using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.Entities.Order;
using ShoeStore.Domain.Entities.Product;
using ShoeStore.Application.Utilities;

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
    int _id =6;
    #region Add to Cart
    public async Task<IActionResult> AddToShopCart(int? Id, CancellationToken cancellationToken = default)
    {
        #region Model State Validation
        if (_id == null)
        {
            return NotFound();
        }
        #endregion
        //Get ProductItem By ProductItemID
        ProductItem productItem = await _productService.GetProductItemByIdAsync(_id, cancellationToken);
        //Get Produc By ProductItemID
        Product _product = await _productService.GetProductByIdAsync(_id, cancellationToken);
        #region Initial Order
        // Is Exit Any Order For Current User Today
        if (_orderService.IsExistOrderForUserInToday(_userId))
        {
            Order order = _orderService.GetOrderForCart(_userId);
            if (_orderService.IsExistOrderItemFromUserFromToday(order.Id, productItem.ProductId))
            {
                _orderService.AddOneMoreProductToTheShopCart(order.Id, productItem.ProductId);
            }
            else
            {
                _orderService.AddProductToOrderItem(productItem.Id, order.Id, 10);
            }
        }
        else
        {
            int OrderId = _orderService.AddOrderToTheShopCart(_userId);
            _orderService.AddProductToOrderItem(productItem.Id, OrderId, 10);
        }
        #endregion
       
        return View();

    }
    #endregion
    #region Plus Product OrderItem
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

    #endregion
    #region Minus Product OrderItem
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

    #endregion
    //public async Task<IActionResult> ShopCart()
    //{
    //    Order order=_orderService.GetOrderForCart(_userId);

    //}
   
}
