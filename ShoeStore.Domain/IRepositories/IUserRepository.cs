using ShoeStore.Domain.DTOs.AdminSide.User;
using ShoeStore.Domain.DTOs.SiteSide.Account;
using ShoeStore.Domain.Entities.Role;
using ShoeStore.Domain.Entities.User;

namespace ShoeStore.Domain.IRepositories;

public interface IUserRepository
{
    Task<bool> DoesExistUserByMobile(string mobile, CancellationToken cancellation);

    Task AddUserAsync(User user, CancellationToken cancellation);

    Task SaveChangeAsync(CancellationToken cancellation);
    Task<UserDto?> GetUserByMobileAsync(string mobile, CancellationToken cancellation);

    Task<User?> GetUserByIdAsync(int userId, CancellationToken cancellation);

    User? GetUserById(int userId);

    void UpdateUser(User user);
    Task<UserProfileDto?> GetUserProfileById(int id);

    #region Admin Side Methods

    Task<List<ListOfUsersDto>> ListOfUsers(CancellationToken cancellation);

    Task<List<int>> GetListOfUserRolesIdByUserId(int userId, CancellationToken cancellation);

    Task<List<UserRole>> GetListOfUserRolesByUserId(int userId, CancellationToken cancellation);

    void DeleteRangeOfUserRoles(List<UserRole> userRoles);

    #endregion
}

