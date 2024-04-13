using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;

namespace ShoeStore.Presentation.Areas.Admin.Controllers;

public class UsersController : AdminBaseController
{

    #region Ctor

    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
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
}

