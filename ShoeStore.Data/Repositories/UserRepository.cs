﻿using Microsoft.EntityFrameworkCore;
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

    public UserRepository(ShoeStoreDbContext context)
    {
        _context = context;
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
    #endregion

    #region Admin Side Methods

    public async Task<List<ListOfUsersDto>> ListOfUsers(CancellationToken cancellation)
    {
        return await _context.Users.Where(p => !p.IsDelete)
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

