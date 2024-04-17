using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.AdminSide.User;

namespace ShoeStore.Presentation.Areas.Admin.Controllers;

public class UsersController : AdminBaseController
{

    #region Ctor

    private readonly IUserService _userService;
    private readonly IRoleService _roleService;

    public UsersController(IUserService userService, IRoleService roleService)
    {
        _userService = userService;
        _roleService = roleService;
    }

    #endregion

    #region List Of Users

    public async Task<IActionResult> ListOfUsers(CancellationToken cancellation = default)
    {
        var users = await _userService.ListOfUsers(cancellation);

        if (users == null && !users.Any()) return NotFound();

        return View(users);
    }

    #endregion

    #region Add User

    public IActionResult AddUser()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddUser(AddUserAdminSideDto user,CancellationToken cancellation)
    {
        return View(user);
    }

    #endregion

    #region Edit User

    public async Task<IActionResult> EditUser(int id, CancellationToken cancellation = default)
    {
        var user = await _userService.FillEditUserAdminSideDto(id, cancellation);
        if (user == null) return NotFound();

        ViewData["Roles"] = await _roleService.ListOfRoles(cancellation);

        return View(user);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditUser(EditUserAdminSideDto model, List<int>? selectedRoles, CancellationToken cancellation)
    {
        if (ModelState.IsValid)
        {
            var res = await _userService.EditUserAdminSide(model, selectedRoles, cancellation);
            if (res)
            {
                TempData["SuccessMessage"] = "Success";
                return RedirectToAction(nameof(ListOfUsers));
            }

            TempData["ErrorMessage"] = "failed";
        }

        ViewData["Roles"] = await _roleService.ListOfRoles(cancellation);
        return View(model);
    }

    #endregion

    #region Delete User

    public async Task<IActionResult> DeleteUser(int userId, CancellationToken cancellation)
    {
        var res = await _userService.DeleteUser(userId, cancellation);
        if (res)
        {
            TempData["SuccessMessage"] = "Success";
        }
        else
        {
            TempData["ErrorMessage"] = "failed";
        }

        return RedirectToAction(nameof(ListOfUsers));
    }

    #endregion
}

