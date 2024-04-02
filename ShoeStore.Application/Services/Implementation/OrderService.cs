#region Using
using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.Entities.Order;
using ShoeStore.Domain.Entities.User;
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
}
