using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.AdminSide.Role;
using ShoeStore.Domain.Entities.Role;
using ShoeStore.Domain.IRepositories;
using System.Data;

namespace ShoeStore.Application.Services.Implementation;

public class RoleService : IRoleService
{

    #region Ctor

    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;

    public RoleService(IRoleRepository roleRepository, IUserRepository userRepository)
    {
        _roleRepository = roleRepository;
        _userRepository = userRepository;
    }

    #endregion

    public async Task<List<Role>> GetUserRolesByUserIdAsync(int userId, CancellationToken cancellation)
    {
        return await _roleRepository.GetUserRolesByUserIdAsync(userId, cancellation);
    }

    public List<Role> GetUserRolesByUserId(int userId)
    {
        return _roleRepository.GetUserRolesByUserId(userId);
    }

    public bool IsUserAdmin(int userId)
    {
        var user = _userRepository.GetUserById(userId);

        if (user.SuperAdmin) return true;

        var userRoles = GetUserRolesByUserId(userId);

        foreach (var role in userRoles)
        {
            if (role.RoleUniqueName.ToLower() == "admin")
            {
                return true;
            }
        }

        return false;
    }

    public async Task<List<RoleDto>> GetLitOfRoles(CancellationToken cancellation)
    {
        return await _roleRepository.GetLitOfRoles(cancellation);
    }

    public async Task<List<RoleListDto>> ListOfRoles(CancellationToken cancellation)
    {
        return await _roleRepository.ListOfRoles(cancellation);
    }

    public async Task<bool> CreateNewRole(CreateRoleDto newRole, CancellationToken cancellation)
    {
        //Does exist any Role by RoleUniqueName
        bool doesExistRoleUniqueName =
            await _roleRepository.DoesExistAnyRoleByRoleUniqueName(newRole.RoleUniqueName.Trim().ToLower(), cancellation);
        if (doesExistRoleUniqueName) return false;

        //Fill Role Entity
        Role role = new Role()
        {
            RoleTitle = newRole.RoleTitle,
            RoleUniqueName = newRole.RoleUniqueName.Trim().ToLower(),
        };

        await _roleRepository.AddRole(role, cancellation);
        await _roleRepository.SaveChanges(cancellation);

        return true;
    }

    public async Task<EditRoleDto?> FillEditRoleDto(int roleId, CancellationToken cancellation)
    {
        // Get Role by Id
        var role = await _roleRepository.GetRoleById(roleId, cancellation);
        if (role == null) return null;

        return new EditRoleDto()
        {
            RoleId = roleId,
            RoleTitle = role.RoleTitle,
            RoleUniqueName = role.RoleUniqueName,
        };

    }

    public async Task<bool> EditRole(EditRoleDto role, CancellationToken cancellation)
    {
        //Get old Role by Id
        var oldRole = await _roleRepository.GetRoleById(role.RoleId, cancellation);
        if (oldRole == null) return false;
        //Does Exist any Role By This UniqueName
        bool doesExistRoleUniqueName = await _roleRepository.DoesExistAnyRoleByRoleUniqueName(
                                                                                   role.RoleUniqueName.Trim().ToLower(),
                                                                                   role.RoleId,
                                                                                   cancellation);
        if (doesExistRoleUniqueName) return false;

        oldRole.RoleTitle = role.RoleTitle;
        oldRole.RoleUniqueName = role.RoleUniqueName.Trim().ToLower();
        _roleRepository.UpdateRole(oldRole);

        await _roleRepository.SaveChanges(cancellation);
        return true;

    }

    public async Task<bool> DeleteRole(int roleId, CancellationToken cancellation)
    {
        //Get Role by Id
        var role = await _roleRepository.GetRoleById(roleId, cancellation);
        if (role == null || role.IsDelete) return false;

        role.IsDelete = true;
        _roleRepository.UpdateRole(role);
        await _roleRepository.SaveChanges(cancellation);
        return true;
    }
}

