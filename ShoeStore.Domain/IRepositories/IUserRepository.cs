using ShoeStore.Domain.Entities.User;

namespace ShoeStore.Domain.IRepositories;

public interface IUserRepository
{
    Task<bool> DoesExistUserByMobile(string mobile, CancellationToken cancellation);

    Task AddUserAsync(User user, CancellationToken cancellation);

    Task SaveChangeAsync(CancellationToken cancellation);
    Task<User?> GetUserByMobileAsync(string mobile, CancellationToken cancellation);
}

