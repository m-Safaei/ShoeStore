#region Using
using ShoeStore.Domain.Entities.Order;
using ShoeStore.Domain.Entities.Product;
namespace ShoeStore.Application.Services.Interface;
#endregion
public interface IOrderService
{
    int AddOrderToTheShopCart(int userId);
    bool IsExistOrderForUserInToday(int id);
    Order GetOrderForCart(int userId);
    #region OrderItem
    bool IsExistOrderItemFromUserFromToday(int OrderId, int productId);
    void AddProductToOrderItem(int productId, int orderId, decimal Price);
    void AddOneMoreProductToTheShopCart(int orderid,int productid);
    void PlusProductToTheOrderItem(int id); 
    void MinusProductToTheOrderItem(int id);

    #endregion



}

