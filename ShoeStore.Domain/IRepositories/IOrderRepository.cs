#region MyRegion
using ShoeStore.Domain.DTOs.SiteSide.Order;
using ShoeStore.Domain.Entities.Order;
using ShoeStore.Domain.Entities.User;

namespace ShoeStore.Domain.IRepositories;
#endregion
public interface IOrderRepository
{
    void AddOrderToTheCart(Order order);
    bool IsExistOrderForUserInToday(int id);
    Order GetOrderForCart(int userId);
    Order GetOrderByOrderItemId(int OrderItemId);
    Task<bool> IsOrderInLastStepOfShoping(int orderid, int Userid);
    List<Order> GetOrder(int UserID);
    Task UpdateOrder(int UserId);

    #region orderItem
    bool IsExistOrderItemFromUserFromToday(int OrderId, int productId);
    void AddOrderItem(OrderItem orderItem);
    void UpdateOrderItem(OrderItem orderItem);
    OrderItem GetOrderItem(int orderid,int productid);
    OrderItem GetOrderItemById(int orderid);
    Task RemoveProductFromShopCart(OrderItem orderItem);

    List<OrderItem> GetOrderItemByOrderId(int OrderId);
    #endregion

    void AddLocation(Location location);


}
