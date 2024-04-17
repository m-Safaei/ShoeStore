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
    #region Order
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
        return _dbContext.Orders.SingleOrDefault(p=>p.UserId==userId&&p.Isfainally==false);
    }
    #endregion

    #region OrderItem
    public bool IsExistOrderItemFromUserFromToday(int OrderId,int productId)
    {
      //  return _dbContext.orderItems.Any(p => p.ProductId == productId && p.OrderId == OrderId);
        return _dbContext.orderItems.Any(p =>  p.OrderId == OrderId);
    }
    public void AddOrderItem(OrderItem orderItem)
    {
        _dbContext.orderItems.Add(orderItem);
        SaveChanges();
    }
   public void UpdateOrderItem(OrderItem orderItem)
    {
        _dbContext.orderItems.Update(orderItem);
        SaveChanges();
    }
   public OrderItem GetOrderItem(int orderid, int productid)
    {
   return    _dbContext.orderItems.SingleOrDefault(p => p.OrderId == orderid && p.ProductId == productid);
        return _dbContext.orderItems.SingleOrDefault(p => p.OrderId == orderid) ;
    }
    public OrderItem GetOrderItemById(int id)
    {
        return _dbContext.orderItems.SingleOrDefault(p => p.Id == id);
    }
    #endregion

}
