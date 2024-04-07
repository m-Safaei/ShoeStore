using ShoeStore.Domain.Entities.Role;

namespace ShoeStore.Application.Services.Interface;

public interface IRoleService
{
    Task<List<Role>> GetUserRolesByUserId(int userId, CancellationToken cancellation);

    bool IsUserAdmin(int userId);
}

