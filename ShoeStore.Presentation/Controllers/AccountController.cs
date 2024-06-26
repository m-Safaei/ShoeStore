﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.SiteSide.Account;
using ShoeStore.Domain.Entities.User;
using System.Security.Claims;
using ShoeStore.Application.Utilities;

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
    [HttpGet("Register")]
    public IActionResult Register()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    [HttpPost("Register"), ValidateAntiForgeryToken]
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
                    TempData["SuccessMessage"] = "عملیات باموفقیت انجام شد";
                    return Redirect(userDto.ReturnUrl);
                }

                TempData["SuccessMessage"] = "عملیات باموفقیت انجام شد";
                return RedirectToAction("Index", "Home");
            }

            TempData["InfoMessage"] = "کاربری با شماره موبایل وارد شده در سیستم وجود دارد.";
        }


        return View(userDto);
    }
    #endregion

    #region Login

    [HttpGet("Login")]
    public IActionResult Login(string? ReturnUrl)
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }

        UserLoginDto returnModel = new UserLoginDto();
        if (!string.IsNullOrEmpty(ReturnUrl))
        {
            returnModel.ReturnUrl = ReturnUrl;
        }
        return View(returnModel);
    }

    [HttpPost("Login"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UserLoginDto userDto, CancellationToken cancellation = default)
    {
        if (ModelState.IsValid)
        {
            var user = await _userService.GetUserByMobileAsync(userDto.Mobile.Trim(), cancellation);

            if (user != null)
            {
                var password = PasswordHasher.EncodePasswordMd5(userDto.Password);

                if (user.Password == password)
                {
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
                    authProps.IsPersistent = userDto.RememberMe;

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps);

                    if (!string.IsNullOrEmpty(userDto.ReturnUrl))
                    {
                        TempData["SuccessMessage"] = "عملیات باموفقیت انجام شد";
                        return Redirect(userDto.ReturnUrl);
                    }

                    TempData["SuccessMessage"] = "عملیات باموفقیت انجام شد";
                    return RedirectToAction("Index", "Home");
                }

                TempData["WrongPassword"] = "پسورد وارد شده اشتباه است";
            }
            else
            {
                TempData["NotFoundUser"] = "کاربری با مشخصات وارد شده یافت نشد.";
            }
            
        }
        return View(userDto);
    }

    #endregion

    #region Logout

    [HttpGet("Logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }

    #endregion
}

