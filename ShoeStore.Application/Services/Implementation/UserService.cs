using ShoeStore.Application.Services.Interface;
using ShoeStore.Application.Utilities;
using ShoeStore.Domain.DTOs.AdminSide.User;
using ShoeStore.Domain.DTOs.SiteSide.Account;
using ShoeStore.Domain.Entities.Role;
using ShoeStore.Domain.Entities.User;
using ShoeStore.Domain.IRepositories;
using System.Reflection;

namespace ShoeStore.Application.Services.Implementation;

public class UserService : IUserService
{

    #region Ctor

    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
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

    public async Task<EditUserAdminSideDto?> FillEditUserAdminSideDto(int userId, CancellationToken cancellation)
    {
        // Get user by id
        var user = await _userRepository.GetUserByIdAsync(userId, cancellation);
        if (user == null) return null;

        //Fill Dto
        EditUserAdminSideDto model = new()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Mobile = user.Mobile,
            Id = userId,
            UserOriginalAvatar = user.UserAvatar,
            CurrentUserRolesId = await _userRepository.GetListOfUserRolesIdByUserId(userId, cancellation)
        };


        return model;
    }

    public async Task<bool> EditUserAdminSide(EditUserAdminSideDto model, List<int>? selectedRoles, CancellationToken cancellation)
    {
        // Get user by id
        var originUser = await _userRepository.GetUserByIdAsync(model.Id, cancellation);
        if (originUser == null) return false;

        // Update Properties
        originUser.Mobile = model.Mobile;
        originUser.FirstName = model.FirstName;
        originUser.LastName = model.LastName;

        if (model.UserAvatar != null)
        {
            //Save New Image
            originUser.UserAvatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.UserAvatar.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/UserAvatar", originUser.UserAvatar);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                model.UserAvatar.CopyTo(stream);
            }
        }

        List<UserRole> userRoles = await _userRepository.GetListOfUserRolesByUserId(model.Id, cancellation);


        if (userRoles != null && userRoles.Any())
        {
            _userRepository.DeleteRangeOfUserRoles(userRoles);
        }
        // Update User roles
        if (selectedRoles != null && selectedRoles.Any())
        {
            foreach (var roleId in selectedRoles)
            {
                UserRole userRole = new()
                {
                    UserId = model.Id,
                    RoleId = roleId,
                };
                await _roleRepository.AddUserSelectedRole(userRole, cancellation);
            }
        }

        _userRepository.UpdateUser(originUser);
        await _userRepository.SaveChangeAsync(cancellation);
        return true;
    }

    public async Task<bool> DeleteUser(int userId, CancellationToken cancellation)
    {
        // Get user by id
        var user = await _userRepository.GetUserByIdAsync(userId, cancellation);
        if (user == null || user.IsDelete) return false;

        user.IsDelete = true;
        _userRepository.UpdateUser(user);
        await _userRepository.SaveChangeAsync(cancellation);
        return true;
    }

    public async Task<bool> AddUserAdminSide(AddUserAdminSideDto userDto, List<int>? selectedRoles, CancellationToken cancellation)
    {
        //Check if User Exist
        if (await DoesExistUserByMobile(userDto.Mobile, cancellation))
        {
            return false;
        }

        //Fill Entity
        User user = FillUserEntityAdminSide(userDto);

        if (userDto.UserAvatar != null)
        {
            //Save New Image
            user.UserAvatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(userDto.UserAvatar.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/UserAvatar", user.UserAvatar);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                userDto.UserAvatar.CopyTo(stream);
            }
        }

        //Add User
        await AddUserAsync(user, cancellation);
        // Add User roles
        if (selectedRoles != null && selectedRoles.Any())
        {
            foreach (var roleId in selectedRoles)
            {
                UserRole userRole = new()
                {
                    UserId = user.Id,
                    RoleId = roleId,
                };
                await _roleRepository.AddUserSelectedRole(userRole, cancellation);
            }
        }
        await _userRepository.SaveChangeAsync(cancellation);
        return true;
    }

    public User FillUserEntityAdminSide(AddUserAdminSideDto userDto)
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
    #endregion

}

