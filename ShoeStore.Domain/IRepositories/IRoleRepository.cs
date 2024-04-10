using ShoeStore.Domain.DTOs.AdminSide.Role;
using ShoeStore.Domain.Entities.Role;

namespace ShoeStore.Domain.IRepositories;

public interface IRoleRepository
{
    Task<List<Role>> GetUserRolesByUserIdAsync(int userId, CancellationToken cancellation);

    List<Role> GetUserRolesByUserId(int userId);

    Task<List<RoleDto>> GetLitOfRoles(CancellationToken cancellation);
}

