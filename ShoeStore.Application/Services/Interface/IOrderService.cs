
using ShoeStore.Domain.Entities.Order;

namespace ShoeStore.Application.Services.Interface;


public interface IOrderService
{
    int AddOrderToTheShopCart(int userId);
}
