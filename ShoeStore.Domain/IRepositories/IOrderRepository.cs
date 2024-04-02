#region MyRegion
using ShoeStore.Domain.Entities.Order;
using ShoeStore.Domain.Entities.User;

namespace ShoeStore.Domain.IRepositories;
#endregion
public interface IOrderRepository
{
    void AddOrderToTheCart(Order order);
}
