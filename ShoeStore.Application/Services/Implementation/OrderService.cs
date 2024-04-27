#region Using
using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.SiteSide.Order;
using ShoeStore.Domain.Entities.Order;
using ShoeStore.Domain.Entities.Product;
using ShoeStore.Domain.IRepositories;
namespace ShoeStore.Application.Services.Implementation;
#endregion
public class OrderService : IOrderService
{
    #region ctor
    public readonly IOrderRepository _orderRepository;
    public readonly IProductRepository _productRepository;
    public readonly ISizeRepository _sizeRepository;
    public readonly IProductItemRepository _productItemRepository;
    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository,ISizeRepository sizeRepository, IProductItemRepository productItemRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _sizeRepository = sizeRepository;
        _productItemRepository = productItemRepository;
    }
    #endregion
    public int AddOrderToTheShopCart(int userId)
    {
        Order order = new Order()
        {
            Isfainally = false,
           UserId = userId,
        };
       _orderRepository.AddOrderToTheCart(order);
        return userId;
    }
    public bool IsExistOrderForUserInToday(int id)
    {
        return _orderRepository.IsExistOrderForUserInToday(id);  
    }
    public Order GetOrderForCart(int userId)
    {
    return _orderRepository.GetOrderForCart(userId);
    
    }
    public bool IsExistOrderItemFromUserFromToday(int OrderId, int productId)
    {
        return _orderRepository.IsExistOrderItemFromUserFromToday(OrderId,productId);
    }
    public void AddProductToOrderItem(int productItemId, int orderId, decimal Price,int count)
    {
        OrderItem orderItem = new OrderItem()
        {
            ProductItemId = productItemId,
            OrderId = orderId,
            Price = Price,
            Count = count,
        };
        _orderRepository.AddOrderItem(orderItem);
    }
    public void AddOneMoreProductToTheShopCart(int orderid, int productid)
    {
        OrderItem orderItem = _orderRepository.GetOrderItem(orderid,productid);
        orderItem.Count =orderItem.Count+1;
        _orderRepository.UpdateOrderItem(orderItem);
    }

    public void PlusProductToTheOrderItem(int id)
    {
      OrderItem orderItem =_orderRepository.GetOrderItemById(id);
      orderItem.Count=orderItem.Count+1;
        _orderRepository.UpdateOrderItem(orderItem);
    }
    public void MinusProductToTheOrderItem(int id)
    {
        OrderItem orderItem = _orderRepository.GetOrderItemById(id);
        orderItem.Count = orderItem.Count - 1;
        _orderRepository.UpdateOrderItem(orderItem);
    }
   public Order GetOrderByOrderItemId(int OrderItemId)
    {
      return  _orderRepository.GetOrderByOrderItemId(OrderItemId);
    }
    public async Task<bool> IsOrderInLastStepOfShoping(int orderid, int Userid)
    {
        return await _orderRepository.IsOrderInLastStepOfShoping(orderid,Userid);
    }
    public async Task RemoveProductFromShopCart(int orderItemid)
    {
        OrderItem orderItem = _orderRepository.GetOrderItemById(orderItemid);
         await _orderRepository.RemoveProductFromShopCart(orderItem);
    }

  public async Task<List<InvoiceSiteSideViewModel>> FillInvoiceSiteSideViewModel(int userId, CancellationToken cancellation)
   {
    var invoices = new List<InvoiceSiteSideViewModel>();
    
    // Get orders by user id.
    var orders = _orderRepository.GetOrder(userId);
    
    foreach (var order in orders)
    {
        if (!order.Isfainally)
        {
            var invoice = new InvoiceSiteSideViewModel
            {
                Order = order,
                InvoiceOrderItem = new List<InvoiceOrderDetailSiteSideViewModel>(),
                IsReturend = false
            };
            
            // Get order items for the current order.
            var orderItems = _orderRepository.GetOrderItemByOrderId(order.Id);
            
            int i = 1;
            
            foreach (var orderItem in orderItems)
            {
                var product = await _productRepository.GetProductByIdAsync(i, cancellation);
                
                var invoiceOrderDetail = new InvoiceOrderDetailSiteSideViewModel
                {
                    OrderDetailID = orderItem.Id,
                    Count = orderItem.Count,
                    Price = orderItem.Price,
                    Product = new InvoiceProductSiteSideViewModel
                    {
                        ProductId = product.Id,
                        ProductTitle = product.Name,
                        ProductImage = product.ProductImage
                    }
                };
                
                invoice.InvoiceOrderItem.Add(invoiceOrderDetail);
            }
            
            invoices.Add(invoice);
        }
    }
    
    return await Task.FromResult(invoices);
   }
    public async Task<InvoiceSiteSideViewModel> FillInvoiceSiteSideViewModelAsync(int userId, CancellationToken cancellation)
    {
        InvoiceSiteSideViewModel invoice = null;
        // Get orders by user id
        var orders = _orderRepository.GetOrder(userId);

        foreach (var order in orders)
        {
            if (!order.Isfainally)
            {
                invoice = new InvoiceSiteSideViewModel
                {
                    Order = order,
                    InvoiceOrderItem = new List<InvoiceOrderDetailSiteSideViewModel>(),
                    IsReturend = false
                };

                // Get order items for the current order
                var orderItems = _orderRepository.GetOrderItemByOrderId(order.Id);
                foreach (var orderItem in orderItems)
                {
                   ProductItem productItem =await _productItemRepository.GetProductItemByIdAsync(orderItem.ProductItemId,cancellation);

                    var product =  _productRepository.GetProductByIdAsync(productItem.ProductId, cancellation);
                   

                    var invoiceOrderDetail = new InvoiceOrderDetailSiteSideViewModel
                    {
                        OrderDetailID = orderItem.Id,
                        Count = orderItem.Count,
                        Price = orderItem.Price,
                        Product = new InvoiceProductSiteSideViewModel
                        {
                            ProductId = product.Id,
                            ProductTitle = product.Result.Name,
                            ProductImage = product.Result.ProductImage
                        }
                    };

                    invoice.InvoiceOrderItem.Add(invoiceOrderDetail);
                }

                break; // Since we only want one invoice, break the loop after the first valid order.
            }
        }

        return await Task.FromResult(invoice);
    }
}
