using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Application.Utilities;

namespace ShoeStore.Presentation.Areas.Admin.ViewComponents;
public class SidebarUserAvatarViewComponent : ViewComponent
{
    private readonly IUserService _userService;

    public SidebarUserAvatarViewComponent(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellation = default)
    {
        var userId = User.GetUserId();

        return View("SidebarUserAvatar", await _userService.GetAdminAvatar(userId, cancellation));
    }
}

