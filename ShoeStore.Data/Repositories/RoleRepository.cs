using Microsoft.EntityFrameworkCore;
using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.DTOs.AdminSide.Role;
using ShoeStore.Domain.Entities.Role;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Data.Repositories;

public class RoleRepository : IRoleRepository
{

    #region Ctor

    private readonly ShoeStoreDbContext _context;

    public RoleRepository(ShoeStoreDbContext context)
    {
        _context = context;
    }

    #endregion

    public async Task<List<Role>> GetUserRolesByUserIdAsync(int userId, CancellationToken cancellation)
    {
        return await _context.UserRoles.Where(p => p.UserId == userId)
                                       .Select(p => p.Role)
                                       .ToListAsync(cancellation);
    }

    public List<Role> GetUserRolesByUserId(int userId)
    {
        return _context.UserRoles.Where(p => p.UserId == userId)
                                 .Select(p => p.Role).ToList();
    }

    public async Task<List<RoleDto>> GetLitOfRoles(CancellationToken cancellation)
    {
        return await _context.Roles.Where(p => !p.IsDelete)
                                    .Select(p => new RoleDto()
                                    {
                                        RoleId = p.Id,
                                        RoleTitle = p.RoleTitle,
                                        RoleUniqueName = p.RoleUniqueName,
                                        CreateDate = p.CreateDate
                                    })
                                    .ToListAsync(cancellation);
    }

    public async Task<List<RoleListDto>> ListOfRoles(CancellationToken cancellation)
    {
        return await _context.Roles.Where(p => !p.IsDelete)
                                   .Select(p => new RoleListDto()
                                   {
                                       RoleId = p.Id,
                                       RoleTitle = p.RoleTitle,
                                   })
                                   .ToListAsync(cancellation);
    }

    public async Task<string> GetRoleTitleById(int roleId, CancellationToken cancellation)
    {
        return await _context.Roles.Where(p => !p.IsDelete && p.Id == roleId).Select(p => p.RoleTitle)
            .SingleOrDefaultAsync(cancellation);
    }

    public async Task<bool> DoesExistAnyRoleByRoleUniqueName(string roleUniqueName, CancellationToken cancellation)
    {
        return await _context.Roles
            .AnyAsync(p => !p.IsDelete && p.RoleUniqueName.Equals(roleUniqueName), cancellation);
    }

    public async Task AddRole(Role role, CancellationToken cancellation)
    {
        await _context.Roles.AddAsync(role, cancellation);
    }

    public async Task SaveChanges(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync(cancellation);
    }

    public async Task<Role?> GetRoleById(int roleId, CancellationToken cancellation)
    {
        return await _context.Roles
            .FirstOrDefaultAsync(p => !p.IsDelete && p.Id == roleId, cancellation);
    }

    public async Task<bool> DoesExistAnyRoleByRoleUniqueName(string roleUniqueName, int roleId, CancellationToken cancellation)
    {
        return await _context.Roles.AnyAsync(p => !p.IsDelete &&
                                                  p.Id != roleId &&
                                                  p.RoleUniqueName.Equals(roleUniqueName), cancellation);
    }

    public void UpdateRole(Role role)
    {
        _context.Roles.Update(role);
    }

    public async Task AddUserSelectedRole(UserRole userRole, CancellationToken cancellation)
    {
        await _context.UserRoles.AddAsync(userRole, cancellation);
    }
}

