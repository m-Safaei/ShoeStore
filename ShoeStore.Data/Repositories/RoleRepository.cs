using ShoeStore.Data.AppDbContext;
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
}

