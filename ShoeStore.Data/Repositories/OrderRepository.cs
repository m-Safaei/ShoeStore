using Microsoft.EntityFrameworkCore;
using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.Entities.Order;
using ShoeStore.Domain.Entities.Product;
using ShoeStore.Domain.IRepositories;
using ShoeStore.Domain.DTOs.SiteSide.Order;
namespace ShoeStore.Data.Repositories;
using System.Collections.Generic;

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
    public Order GetOrderByOrderItemId(int OrderItemId) 
    {
        return _dbContext.orderItems.
                            Include(p => p.Order)
                           .Where(p => p.Id == OrderItemId)
                           .Select(p => p.Order)
                           .FirstOrDefault();

    }
    public List<Order> GetOrder(int UserID)
    {
      return  _dbContext.Orders.Where(e=>e.UserId==UserID).ToList();
    }
    public async Task<bool> IsOrderInLastStepOfShoping(int orderid,int Userid)
    {
       return await _dbContext.Orders.AnyAsync(p=>p.Isfainally==false&&p.UserId==Userid);
    }
    #endregion
    #region OrderItem
    public bool IsExistOrderItemFromUserFromToday(int OrderId,int productItemId)
    {

      //  return _dbContext.orderItems.Any(p => p.ProductId == productId && p.OrderId == OrderId);
        return _dbContext.orderItems.Any(p =>  p.OrderId == OrderId&&p.ProductItemId== productItemId);

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
        return _dbContext.orderItems.SingleOrDefault(p => p.OrderId == orderid) ;
    }
    public OrderItem GetOrderItemById(int id)
    {
        return _dbContext.orderItems.SingleOrDefault(p => p.Id == id);
    }
    public List<OrderItem> GetOrderItemByOrderId(int OrderId)
    {
        return _dbContext.orderItems.Where(p => p.OrderId == OrderId).ToList();
    }
    public async Task RemoveProductFromShopCart(OrderItem orderItem)
    {
        _dbContext.orderItems.Remove(orderItem);
        SaveChanges();
    }
    #endregion

}
