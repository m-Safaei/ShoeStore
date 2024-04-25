#region Using
using ShoeStore.Domain.DTOs.SiteSide.Order;
using ShoeStore.Domain.Entities.Order;
using ShoeStore.Domain.Entities.Product;
namespace ShoeStore.Application.Services.Interface;
#endregion
public interface IOrderService
{
    int AddOrderToTheShopCart(int userId);
    bool IsExistOrderForUserInToday(int id);
    Order GetOrderForCart(int userId);
    Order GetOrderByOrderItemId(int OrderItemId);
    Task<bool> IsOrderInLastStepOfShoping(int orderid, int Userid);
    #region OrderItem
    bool IsExistOrderItemFromUserFromToday(int OrderId, int productId);
    void AddProductToOrderItem(int productId, int orderId, decimal Price,int count);
    void AddOneMoreProductToTheShopCart(int orderid,int productid);
    void PlusProductToTheOrderItem(int id); 
    void MinusProductToTheOrderItem(int id);
    Task RemoveProductFromShopCart(int orderItemid);
    Task<List<InvoiceSiteSideViewModel>> FillInvoiceSiteSideViewModel(int userId, CancellationToken cancellation);
    Task<InvoiceSiteSideViewModel> FillInvoiceSiteSideViewModelAsync(int userId, CancellationToken cancellation);
    #endregion



}

