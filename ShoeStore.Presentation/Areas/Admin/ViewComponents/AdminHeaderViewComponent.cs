using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Application.Utilities;

namespace ShoeStore.Presentation.Areas.Admin.ViewComponents;
public class AdminHeaderViewComponent : ViewComponent
{
    private readonly IUserService _userService;

    public AdminHeaderViewComponent(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellation = default)
    {
        var userId = User.GetUserId();

        return View("AdminHeader", await _userService.GetAdminAvatar(userId, cancellation));
    }
}

