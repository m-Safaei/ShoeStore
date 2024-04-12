using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.AdminSide.Role;

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

    public async Task<IActionResult> ListOfRoles(CancellationToken cancellationToken = default)
    {
        return View(await _roleService.GetLitOfRoles(cancellationToken));
    }

    #endregion

    #region Create Role

    public IActionResult CreateRole()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateRole(CreateRoleDto role, CancellationToken cancellation = default)
    {
        if (ModelState.IsValid)
        {
            var res = await _roleService.CreateNewRole(role, cancellation);
            if (res)
            {
                return RedirectToAction(nameof(ListOfRoles));
            }

            TempData["CreateRoleError"] = "Duplicate RoleUniqueName";
        }
        return View(role);
    }

    #endregion

    #region Edit Role



    #endregion

    #region Delete Role



    #endregion
}

