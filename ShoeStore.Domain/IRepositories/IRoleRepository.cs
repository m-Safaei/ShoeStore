﻿using ShoeStore.Domain.DTOs.AdminSide.Role;
using ShoeStore.Domain.Entities.Role;

namespace ShoeStore.Domain.IRepositories;

public interface IRoleRepository
{
    Task<List<Role>> GetUserRolesByUserIdAsync(int userId, CancellationToken cancellation);

    List<Role> GetUserRolesByUserId(int userId);

    Task<List<RoleDto>> GetLitOfRoles(CancellationToken cancellation);

    Task<bool> DoesExistAnyRoleByRoleUniqueName(string roleUniqueName, CancellationToken cancellation);

    Task AddRole(Role role, CancellationToken cancellation);

    Task SaveChanges(CancellationToken cancellation);

    Task<Role?> GetRoleById(int roleId, CancellationToken cancellation);

    Task<bool> DoesExistAnyRoleByRoleUniqueName(string roleUniqueName,int roleId, CancellationToken cancellation);

    void UpdateRole(Role role);
}

