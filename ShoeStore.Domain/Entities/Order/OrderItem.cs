#region using
using ShoeStore.Domain.Common;
using ShoeStore.Domain.Entities.Product;
namespace ShoeStore.Domain.Entities.Order;
#endregion
public class OrderItem:BaseEntity
{
    #region Entites
  public int OrderId { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public bool Isdelete { get; set; }=false;   
    #endregion
    #region Navigations

    public Order Order { get; set; }
    public Product.Product Product { get; set; }
    public List<ProductItem> ProductItem { get; set; }
    public User.User UserId { get; set; }
    #endregion
}
