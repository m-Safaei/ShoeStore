#region MyRegion
using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.Entities.Order;
using ShoeStore.Domain.Entities.Product;
using ShoeStore.Application.Utilities;
using Microsoft.AspNetCore.Authorization;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Presentation.Controllers;
#endregion
public class OrderController : Controller
{
    
    #region ctor
    public readonly IUserService _userService; 
    public readonly IProductService _productService;
    public readonly IOrderService _orderService;
    public readonly IProductItemRepository _productItemRepository;
    public OrderController (IUserService userService, IProductService productService,IOrderService orderService,IProductItemRepository productItemRepository)
    {
        _userService = userService;
        _productService = productService;
        _orderService = orderService;
        _productItemRepository = productItemRepository;
    }
    #endregion     
    [Authorize]
    #region Add to Cart
    public async Task<IActionResult> AddToShopCart(int productItemId,int Count, CancellationToken cancellationToken = default)
    {
        #region Model State Validation
        if (productItemId == null)
        {
            return NotFound();
        }
        #endregion
        #region Get UserId
         int UserId =User.GetUserId();
        #endregion

        //Get Produc By ProductItemID
        //Product _product = await _productService.GetProductByIdAsync(ProductId, cancellationToken);
        //Get ProductItem By ProductItemID
        Product product =await _productService.GetProductByProductItemId(productItemId, cancellationToken);
       // var productItems = 1;

        #region Initial Order
        // Is Exit Any Order For Current User Today
        if (_orderService.IsExistOrderForUserInToday(UserId))
        {
            Order order = _orderService.GetOrderForCart(UserId);
            if (_orderService.IsExistOrderItemFromUserFromToday(order.Id, product.Id))
            {
                _orderService.AddOneMoreProductToTheShopCart(order.Id, product.Id);
            }
            else
            {
                _orderService.AddProductToOrderItem(productItemId, order.Id,product.Price, Count);
            }
        }
        else
        {
            int Orderid = _orderService.AddOrderToTheShopCart(User.GetUserId());
            var order = _orderService.GetOrderForCart(Orderid);
            _orderService.AddProductToOrderItem(productItemId, order.Id,product.Price, Count);
        }
        #endregion
       
        return View();

    }
    #endregion
    #region Plus Product OrderItem
    public async Task<IActionResult> PlusProductOrderItem(int id)
    {
        
        int OrderItemID = 2;
        //if (id==null)
        //{
        //    return NotFound();
        //}
        Order order = _orderService.GetOrderByOrderItemId(OrderItemID);
        if (await  _orderService.IsOrderInLastStepOfShoping(order.Id, User.GetUserId()))
        {
            _orderService.PlusProductToTheOrderItem(OrderItemID);
        }

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
        Order order = _orderService.GetOrderByOrderItemId(OrderItemID);
        if (await _orderService.IsOrderInLastStepOfShoping(order.Id, User.GetUserId()))
        {
            _orderService.MinusProductToTheOrderItem(OrderItemID);
        }
        return View();
    }

    #endregion
    #region Delete Product From ShopCart
    public async Task<IActionResult> RemoveProductFromShopCart(int id)
    {
       
        if (id == 0)
        {
            return NotFound();
        }
       await _orderService.RemoveProductFromShopCart(id);
        return View();
    }
    #endregion
    #region ShopCart
    public async Task<IActionResult> ShopCart()
    {
        //Get Last Order User
         var order =await _orderService.FillInvoiceSiteSideViewModel(User.GetUserId());
        if (order == null)
        {
            User.GetUserId();
        }
        return View(order);
    }
    #endregion


}
