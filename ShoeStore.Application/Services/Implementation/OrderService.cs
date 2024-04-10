#region Using
using ShoeStore.Application.Services.Interface;
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
            UserId=userId
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
    public void AddProductToOrderItem(int productItemId, int orderId, decimal Price)
    {
        OrderItem orderItem = new OrderItem()
        {
            ProductItemId = productItemId,
            OrderId = orderId,
            Price = Price,
            Count = 1
        };
        _orderRepository.AddOrderItem(orderItem);
    }


}
