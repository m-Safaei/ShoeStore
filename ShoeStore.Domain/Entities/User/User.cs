#region Using
using ShoeStore.Domain.Common;
using ShoeStore.Domain.Entities.Order;
using ShoeStore.Domain.Entities.Role;

namespace ShoeStore.Domain.Entities.User;
#endregion
public class User : BaseEntity
{
    #region Properties

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public string Mobile { get; set; }
    public string Password { get; set; }
    public bool IsDelete { get; set; }
    public bool SuperAdmin { get; set; }
    public string? UserAvatar { get;set; }

    #endregion

    #region Relations
     public List<Order.Order> Orders { get; set; }

     public ICollection<UserRole> UserRoles { get; set; }

    #endregion
}

