using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.SiteSide.Account;
using ShoeStore.Domain.Entities.User;
using System.Security.Claims;

namespace ShoeStore.Presentation.Controllers;

public class AccountController : Controller
{

    #region Ctor

    private readonly IUserService _userService;
    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    #endregion

    #region Register

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserRegisterDto userDto, CancellationToken cancellation = default)
    {
        if (ModelState.IsValid)
        {
            bool result = await _userService.RegisterUser(userDto, cancellation);
            if (result)
            {
                var user = await _userService.GetUserByMobileAsync(userDto.Mobile, cancellation);

                //Set Cookie
                var claims = new List<Claim>
                    {
                        new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new (ClaimTypes.MobilePhone, user.Mobile),
                        new (ClaimTypes.Name, user.FirstName + " " + user.LastName),
                    };

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(claimIdentity);

                var authProps = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps);

                if (!string.IsNullOrEmpty(userDto.ReturnUrl))
                {
                    return Redirect(userDto.ReturnUrl);
                }

                return RedirectToAction("Index", "Home");
            }
        }

        TempData["ErrorMessage"] = "کاربری با شماره موبایل وارد شده در سیستم وجود دارد.";
        return View();
    }
    #endregion

    #region Login



    #endregion

    #region Logout



    #endregion
}

