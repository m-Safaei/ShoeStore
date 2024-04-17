using ShoeStore.Domain.DTOs.AdminSide.Role;
using ShoeStore.Domain.Entities.Role;

namespace ShoeStore.Application.Services.Interface;

public interface IRoleService
{
    Task<List<Role>> GetUserRolesByUserIdAsync(int userId, CancellationToken cancellation);

    bool IsUserAdmin(int userId);

    List<Role> GetUserRolesByUserId(int userId);

    Task<List<RoleDto>> GetLitOfRoles(CancellationToken cancellation);

    Task<bool> CreateNewRole(CreateRoleDto newRole, CancellationToken cancellation);

    Task<EditRoleDto?> FillEditRoleDto(int roleId, CancellationToken cancellation);

    Task<bool> EditRole(EditRoleDto role, CancellationToken cancellation);

    Task<List<RoleListDto>> ListOfRoles(CancellationToken cancellation);

    Task<bool> DeleteRole(int roleId, CancellationToken cancellation);

}

