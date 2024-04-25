#region Using
using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.SiteSide.Order;
using ShoeStore.Domain.Entities.Order;
using ShoeStore.Domain.IRepositories;
namespace ShoeStore.Application.Services.Implementation;
#endregion
public class OrderService : IOrderService
{
    #region ctor
    public readonly IOrderRepository _orderRepository;
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    #endregion
    public int AddOrderToTheShopCart(int userId)
    {
        Order order = new Order()
        {
            Isfainally = false,
           UserId = userId,
        };
       _orderRepository.AddOrderToTheCart(order);
        return userId;
    }
    public bool IsExistOrderForUserInToday(int id)
    {
        return _orderRepository.IsExistOrderForUserInToday(id);  
    }
    public Order GetOrderForCart(int userId)
    {
    return _orderRepository.GetOrderForCart(userId);
    
    }
    public bool IsExistOrderItemFromUserFromToday(int OrderId, int productId)
    {
        return _orderRepository.IsExistOrderItemFromUserFromToday(OrderId,productId);
    }
    public void AddProductToOrderItem(int productItemId, int orderId, decimal Price,int count)
    {
        OrderItem orderItem = new OrderItem()
        {
            ProductItemId = productItemId,
            OrderId = orderId,
            Price = Price,
            Count = count,
        };
        _orderRepository.AddOrderItem(orderItem);
    }
    public void AddOneMoreProductToTheShopCart(int orderid, int productid)
    {
        OrderItem orderItem = _orderRepository.GetOrderItem(orderid,productid);
        orderItem.Count =orderItem.Count+1;
        _orderRepository.UpdateOrderItem(orderItem);
    }

    public void PlusProductToTheOrderItem(int id)
    {
      OrderItem orderItem =_orderRepository.GetOrderItemById(id);
      orderItem.Count=orderItem.Count+1;
        _orderRepository.UpdateOrderItem(orderItem);
    }
    public void MinusProductToTheOrderItem(int id)
    {
        OrderItem orderItem = _orderRepository.GetOrderItemById(id);
        orderItem.Count = orderItem.Count - 1;
        _orderRepository.UpdateOrderItem(orderItem);
    }
   public Order GetOrderByOrderItemId(int OrderItemId)
    {
      return  _orderRepository.GetOrderByOrderItemId(OrderItemId);
    }
    public async Task<bool> IsOrderInLastStepOfShoping(int orderid, int Userid)
    {
        return await _orderRepository.IsOrderInLastStepOfShoping(orderid,Userid);
    }
    public async Task RemoveProductFromShopCart(int orderItemid)
    {
        OrderItem orderItem = _orderRepository.GetOrderItemById(orderItemid);
         await _orderRepository.RemoveProductFromShopCart(orderItem);
    }
    public async Task<InvoiceSiteSideViewModel> FillInvoiceSiteSideViewModel(int userId)
    {
      return   await  _orderRepository.FillInvoiceSiteSideViewModel(userId);

    }
}
