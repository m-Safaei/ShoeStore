using ShoeStore.Data.AppDbContext;
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
}

