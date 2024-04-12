using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.AdminSide.Role;
using ShoeStore.Domain.Entities.Role;
using ShoeStore.Domain.IRepositories;

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
            if (role.RoleUniqueName == "Admin")
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
}

