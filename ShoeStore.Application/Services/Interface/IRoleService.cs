using ShoeStore.Domain.Entities.Role;

namespace ShoeStore.Application.Services.Interface;

public interface IRoleService
{
    Task<List<Role>> GetUserRolesByUserIdAsync(int userId, CancellationToken cancellation);

    bool IsUserAdmin(int userId);

    List<Role> GetUserRolesByUserId(int userId);
}

