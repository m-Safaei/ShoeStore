using ShoeStore.Domain.Common;

namespace ShoeStore.Domain.Entities.User;

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



    #endregion
}

