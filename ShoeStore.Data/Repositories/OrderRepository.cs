using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.Entities.Order;
using ShoeStore.Domain.Entities.Product;
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
        SaveChanges();
    }
    public bool IsExistOrderForUserInToday(int id)
    {
        return _dbContext.Orders.Any(p => p.UserId == id && p.CreateDate.Day == DateTime.Now.Day &&
        p.CreateDate.Year == DateTime.Now.Year && p.CreateDate.Month == DateTime.Now.Month && p.Isfainally == false);
    }
    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
    public Order GetOrderForCart(int userId)
    {
        return _dbContext.Orders.SingleOrDefault(p=>p.UserId==userId);
    }
    public bool IsExistOrderItemFromUserFromToday(int OrderId,int productId)
    {
        return _dbContext.orderItems.Any(p => p.ProductItemId == productId && p.OrderId == OrderId);
    }
    public void AddOrderItem(OrderItem orderItem)
    {
        _dbContext.orderItems.Add(orderItem);
        SaveChanges();
    }

}
