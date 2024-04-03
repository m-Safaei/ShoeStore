using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.Entities.Order;
using ShoeStore.Domain.IRepositories;
namespace ShoeStore.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    #region ctor
    public readonly ShoeStoreDbContext _dbContext;
    public OrderRepository(ShoeStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    #endregion
    public void AddOrderToTheCart(Order order)
    {
        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();
    }
}
