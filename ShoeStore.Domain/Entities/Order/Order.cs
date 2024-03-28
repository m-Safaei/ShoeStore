#region using
using ShoeStore.Domain.Common;
using ShoeStore.Domain.Entities.User;
namespace ShoeStore.Domain.Entities.Order;
#endregion

public class Order:BaseEntity
{
    #region Entites
    public int UserId { get; set; }
    public bool Isfainally { get; set; }
    #endregion

    #region Navigations
    public User.User User { get; set; }
    public List<OrderItem> Items { get; set;}
    #endregion

}
