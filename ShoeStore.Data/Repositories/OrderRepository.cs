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
    public async Task<bool> IsOrderInLastStepOfShoping(int orderid,int Userid)
    {
       return await _dbContext.Orders.AnyAsync(p=>p.Isfainally==false&&p.UserId==Userid);
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
  // return    _dbContext.orderItems.SingleOrDefault(p => p.OrderId == orderid && p.ProductId == productid);
        return _dbContext.orderItems.SingleOrDefault(p => p.OrderId == orderid) ;
    }
    public OrderItem GetOrderItemById(int id)
    {
        return _dbContext.orderItems.SingleOrDefault(p => p.Id == id);
    }
    public async Task RemoveProductFromShopCart(OrderItem orderItem)
    {
        _dbContext.orderItems.Remove(orderItem);
        SaveChanges();
    }
    public async Task<InvoiceSiteSideViewModel> FillInvoiceSiteSideViewModel(int userId)
    {
        #region MyRegion
        //var OrserId=_dbContext.Orders.Where(e=>!e.Isfainally).FirstOrDefault();
        //return await _dbContext.Orders.Where(p => p.UserId == userId && p.CreateDate.Year == DateTime.Now.Year && p.CreateDate.Month == DateTime.Now.Month && p.CreateDate.Day == DateTime.Now.Day && p.Isfainally == false)
        //       .Select(p => new InvoiceSiteSideViewModel()
        //       {
        //           Order = p,
        //           InvoiceOrderItem = _dbContext.orderItems.Where(s => s.OrderId == OrserId.Id)
        //                            .Select(s => new InvoiceOrderDetailSiteSideViewModel()
        //                            {
        //                                Count=s.Count,
        //                                OrderDetailID=s.Id,
        //                                InvoiceSize=_dbContext.Sizes
        //                                   .Select(c => new InvoiceSizeSiteSideViewModel()
        //                                   {
        //                                     SizeId=c.SizeNumber

        //                                   }).FirstOrDefault(),
        //                               Product=_dbContext.Products
        //                               .Where(pro => !pro.IsDelete && pro.Id ==s.ProductItemId)
        //                                                                           .Select(pro => new InvoiceProductSiteSideViewModel()
        //                                                                           {
        //                                                                               Price = pro.Price,
        //                                                                               ProductId = pro.ProductID,
        //                                                                               ProductImage = pro.ProductImageName,
        //                                                                               ProductTitle = pro.ProductTitle,
        //                                                                           })
        //                                                                           .FirstOrDefault(),

        //                            }).ToList()


        //       }
        #endregion
        // دریافت اولین سفارش نهایی نشده برای کاربر مشخص شده
        var order = await _dbContext.Orders
            .FirstOrDefaultAsync(o => o.UserId == userId && !o.Isfainally);

        if (order == null)
        {
            return null; // اگر سفارشی وجود نداشت، خروجی null خواهد بود.
        }

        // ساخت مدل نمایش صورتحساب با جزئیات سفارش
        var invoice = new InvoiceSiteSideViewModel()
        {
            Order = order,
            InvoiceOrderItem = _dbContext.orderItems
                .Where(oi => oi.OrderId == order.Id)
                .Select(oi => new InvoiceOrderDetailSiteSideViewModel()
                {
                    Count = oi.Count,
                    OrderDetailID = oi.Id,
                    InvoiceSize = _dbContext.ProductItems
                        .Where(pi => !pi.IsDelete && pi.SizeId == oi.ProductItem.SizeId)
                        .Select(pi => new InvoiceSizeSiteSideViewModel()
                        {
                            SizeId = pi.SizeId,
                        })
                        .FirstOrDefault(),
                    Product = _dbContext.Products
                        .Where(p => !p.IsDelete && p.Id == oi.ProductItem.Id)
                        .Select(p => new InvoiceProductSiteSideViewModel()
                        {
                            Price = p.Price,
                            ProductId = p.Id,
                            ProductImage = p.ProductImage,
                            ProductTitle = p.Name
                        })
                        .FirstOrDefault()
                })
                .ToList()
        };

        return invoice; // برگرداندن مدل نمایش صورتحساب
    }
   
    #endregion

}
