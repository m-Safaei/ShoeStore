using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Application.Services.Implementation;

public class RoleService : IRoleService
{

    #region Ctor
    
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    #endregion
}

