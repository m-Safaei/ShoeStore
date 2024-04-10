using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;

namespace ShoeStore.Presentation.Areas.Admin.Controllers;

public class RoleController : AdminBaseController
{

    #region Ctor
    
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    #endregion

    #region List Of Roles

    public async Task<IActionResult> ListOfRoles(CancellationToken cancellationToken=default)
    {
        return View(await _roleService.GetLitOfRoles(cancellationToken));
    }

    #endregion

    #region Create Role



    #endregion

    #region Edit Role



    #endregion

    #region Delete Role

    

    #endregion
}

