﻿using ShoeStore.Application.Services.Interface;
using ShoeStore.Application.Utilities;
using ShoeStore.Domain.DTOs.AdminSide.User;
using ShoeStore.Domain.DTOs.SiteSide.Account;
using ShoeStore.Domain.Entities.User;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Application.Services.Implementation;

public class UserService : IUserService
{

    #region Ctor

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    #endregion

    #region General Methods

    public async Task<bool> DoesExistUserByMobile(string mobile, CancellationToken cancellation)
    {
        return await _userRepository.DoesExistUserByMobile(mobile.Trim(), cancellation);
    }

    public User FillUserEntity(UserRegisterDto userDto)
    {
        //Object mapping 
        User user = new()
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Mobile = userDto.Mobile.Trim(),
            Password = PasswordHasher.EncodePasswordMd5(userDto.Password)
        };
        return user;
    }

    public async Task AddUserAsync(User user, CancellationToken cancellation)
    {
        await _userRepository.AddUserAsync(user, cancellation);
    }
    public async Task<bool> RegisterUser(UserRegisterDto userDto, CancellationToken cancellation)
    {
        //Check if User Exist
        if (await DoesExistUserByMobile(userDto.Mobile, cancellation))
        {
            return false;
        }

        //Fill Entity
        User user = FillUserEntity(userDto);

        //Add User
        await AddUserAsync(user, cancellation);

        return true;
    }

    public async Task<UserDto?> GetUserByMobileAsync(string mobile, CancellationToken cancellation)
    {
        return await _userRepository.GetUserByMobileAsync(mobile, cancellation);
    }

    #endregion

    #region Admin Side Methods

    public async Task<List<ListOfUsersDto>> ListOfUsers(CancellationToken cancellation)
    {
        return await _userRepository.ListOfUsers(cancellation);
    }

    #endregion

}

