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
                                        RoleTitle = p.RoleTitle,
                                        RoleUniqueName = p.RoleUniqueName,
                                    })
                                    .ToListAsync(cancellation);
    }
}

