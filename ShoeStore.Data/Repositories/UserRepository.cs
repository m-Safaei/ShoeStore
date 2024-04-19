using Microsoft.EntityFrameworkCore;
using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.DTOs.AdminSide.User;
using ShoeStore.Domain.DTOs.SiteSide.Account;
using ShoeStore.Domain.Entities.Role;
using ShoeStore.Domain.Entities.User;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Data.Repositories;

public class UserRepository : IUserRepository
{

    #region Ctor

    private readonly ShoeStoreDbContext _context;
    private readonly IRoleRepository _roleRepository;

    public UserRepository(ShoeStoreDbContext context, IRoleRepository roleRepository)
    {
        _context = context;
        _roleRepository = roleRepository;
    }

    #endregion

    #region General Methods

    public async Task<bool> DoesExistUserByMobile(string mobile, CancellationToken cancellation)
    {
        return await _context.Users.AnyAsync(p => p.Mobile == mobile, cancellation);
    }

    public async Task AddUserAsync(User user, CancellationToken cancellation)
    {
        await _context.Users.AddAsync(user, cancellation);
        await SaveChangeAsync(cancellation);

    }

    public async Task SaveChangeAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync(cancellation);
    }

    public async Task<UserDto?> GetUserByMobileAsync(string mobile, CancellationToken cancellation)
    {
        return await _context.Users.Select(p => new UserDto()
        {
            Id = p.Id,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Mobile = p.Mobile,
            Password = p.Password
        })
            .SingleOrDefaultAsync(p => p.Mobile == mobile, cancellation);
    }

    public async Task<User?> GetUserByIdAsync(int userId, CancellationToken cancellation)
    {
        return await _context.Users.FindAsync(userId, cancellation);
    }

    public User? GetUserById(int userId)
    {
        return _context.Users.Find(userId);
    }

    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
    }

    public async Task<UserProfileDto?> GetUserProfileById(int id)
    {
        return await _context.Users.Where(p => !p.IsDelete && p.Id == id)
                                    .Select(p => new UserProfileDto()
                                    {
                                        Id = p.Id,
                                        Mobile = p.Mobile,
                                        UserAvatar = p.UserAvatar
                                    })
                                    .SingleOrDefaultAsync();
    }
    #endregion

    #region Admin Side Methods

    public async Task<List<ListOfUsersDto>> ListOfUsers(CancellationToken cancellation)
    {
        var users = await _context.Users.Where(p => !p.IsDelete)
            .OrderByDescending(p => p.CreateDate)
            .Select(p => new ListOfUsersDto()
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Mobile = p.Mobile,
                CreateDate = p.CreateDate,
                UserAvatar = p.UserAvatar,
            })
            .ToListAsync(cancellation);


        foreach (var user in users)
        {
            List<int>? roleIds = _context.UserRoles.Where(p => p.UserId == user.Id)
                                                   .Select(p => p.RoleId).ToList();

            List<string> roleTitles = new List<string>();

            if (roleIds != null && roleIds.Any())
            {
                foreach (var roleId in roleIds)
                {
                    string roleTitle = await _roleRepository.GetRoleTitleById(roleId, cancellation);
                    roleTitles.Add(roleTitle);
                }
            }
            user.RoleTitles = roleTitles;
        }

        return users;
    }

    public async Task<List<int>> GetListOfUserRolesIdByUserId(int userId, CancellationToken cancellation)
    {
        return await _context.UserRoles.Where(p => p.UserId == userId)
                                       .Select(p => p.RoleId)
                                       .ToListAsync(cancellation);
    }

    public async Task<List<UserRole>> GetListOfUserRolesByUserId(int userId, CancellationToken cancellation)
    {
        return await _context.UserRoles.Where(p => p.UserId == userId).ToListAsync(cancellation);
    }

    public void DeleteRangeOfUserRoles(List<UserRole> userRoles)
    {
        _context.UserRoles.RemoveRange(userRoles);
    }
    #endregion

}

