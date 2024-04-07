using ShoeStore.Domain.DTOs.SiteSide.Account;
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
}

