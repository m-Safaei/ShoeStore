using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Application.Utilities;

namespace ShoeStore.Presentation.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        #region Ctor

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion
        public async Task<IActionResult> UserProfile()
        {
            var user = await _userService.GetUserProfileById(User.GetUserId());
            return View(user);
        }
    }
}
