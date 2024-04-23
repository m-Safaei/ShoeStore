using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Implementation;
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

            TempData["CreateRoleError"] = "نقش وارد شده تکراری است";
        }
        return View(role);
    }

    #endregion

    #region Edit Role

    public async Task<IActionResult> EditRole(int roleId, CancellationToken cancellation = default)
    {
        var model =await _roleService.FillEditRoleDto(roleId, cancellation);
        if (model == null) return NotFound();

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditRole(EditRoleDto role, CancellationToken cancellation = default)
    {
        if (ModelState.IsValid)
        {
            bool res = await _roleService.EditRole(role, cancellation);
            if (res)
            {
                return RedirectToAction(nameof(ListOfRoles));
            }
            TempData["CreateRoleError"] = "نقش وارد شده تکراری است";
        }
        return View(role);
    }
    #endregion

    #region Delete Role

    public async Task<IActionResult> DeleteRole(int roleId, CancellationToken cancellation)
    {
        var res = await _roleService.DeleteRole(roleId, cancellation);
        if (res)
        {
            TempData["SuccessMessage"] = "عملیات باموفقیت انجام شد";
        }
        else
        {
            TempData["ErrorMessage"] = "عملیات ناموفق";
        }

        return RedirectToAction(nameof(ListOfRoles));
    }

    #endregion
}

