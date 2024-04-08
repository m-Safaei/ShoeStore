#region MyRegion
using ShoeStore.Domain.Entities.Order;
using ShoeStore.Domain.Entities.User;

namespace ShoeStore.Domain.IRepositories;
#endregion
public interface IOrderRepository
{
    void AddOrderToTheCart(Order order);
    bool IsExistOrderForUserInToday(int id);
    Order GetOrderForCart(int userId);



    #region orderItem
    bool IsExistOrderItemFromUserFromToday(int OrderId, int productId);
    void AddOrderItem(OrderItem orderItem);
    void UpdateOrderItem(OrderItem orderItem);
    OrderItem GetOrderItem(int orderid,int productid);
    OrderItem GetOrderItemById(int orderid);
    #endregion




}
