using ShoeStore.Domain.Common;

namespace ShoeStore.Domain.Entities.Role;

public class UserRole: BaseEntity
{
    #region Properties

    public int UserId { get; set; }

    public int RoleId { get; set; }

    #endregion

    #region Navigation Properties

    public User.User User { get; set; }
    public Role Role { get; set; }

    #endregion
}

