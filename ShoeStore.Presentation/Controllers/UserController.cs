using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Application.Utilities;
using ShoeStore.Domain.DTOs.SiteSide.Account;

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

        #region Edit Profile

        public async Task<IActionResult> EditProfile(int id, CancellationToken cancellation)
        {
            var user = await _userService.FillEditProfileSiteSideDto(id, cancellation);
            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(EditProfileSiteSideDto model, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.Password) && !string.IsNullOrEmpty(model.RePassword))
                {
                    var res = await _userService.EditProfileSiteSide(model, cancellation);
                    if (res)
                    {
                        TempData["SuccessMessage"] = "عملیات باموفقیت انجام شد";
                        return RedirectToAction(nameof(UserProfile));
                    }
                    TempData["ErrorMessage"] = "عملیات ناموفق";
                }

                TempData["PasswordField"] = "فیلد پسورد الزامی است";
            }
            return View(model);
        }
        #endregion
    }
}
