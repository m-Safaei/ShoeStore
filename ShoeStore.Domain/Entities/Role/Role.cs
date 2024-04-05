using System.ComponentModel.DataAnnotations;
using ShoeStore.Domain.Common;

namespace ShoeStore.Domain.Entities.Role;

public class Role: BaseEntity
{
    #region Properties

    [StringLength(100,MinimumLength = 3)]
    public string RoleTitle { get; set; }

    [StringLength(100,MinimumLength = 3)]
    public string RoleUniqueName { get; set; }

    public bool IsDelete { get; set; }
    #endregion

    #region Navigation Properties

    public ICollection<UserRole> UserRoles { get; set; }

    #endregion
}

