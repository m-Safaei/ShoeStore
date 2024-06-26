﻿using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;

namespace ShoeStore.Presentation.Controllers;
public class FavoriteProductController : Controller
{

    #region Ctor

    private readonly IFavoriteProductService _favoriteProductService;

    public FavoriteProductController(IFavoriteProductService favoriteProductService)
    {
        _favoriteProductService = favoriteProductService;
    }

    #endregion


    #region AddFavoriteProduct

    public async Task<IActionResult> AddFavoriteProduct(int? userId, int productId, CancellationToken cancellation)
    {
        if (userId != null && userId != 0)
        {
            var res = await _favoriteProductService.AddFavoriteProduct(userId, productId, cancellation);
            if (!res)
            {
                TempData["ErrorForAddFavoriteProduct"] = "محصول موردنظر در لیست علاقه مندی موجود است";
                return RedirectToAction("Index", "Home");
            }

            TempData["successAddFavoriteProduct"] = "محصول به لیست علاقه مندی اضافه شد";
            return RedirectToAction("Index", "Home");

        }
        return RedirectToAction("Index", "Home");
    }

    #endregion

    public async Task<IActionResult> DeleteFavoriteProduct(int productId, int userId, CancellationToken cancellation)
    {
        var res = await _favoriteProductService.DeleteFavoriteProduct(productId, userId, cancellation);
        if (res)
        {
            TempData["SuccessMessage"] = "عملیات باموفقیت انجام شد";
        }
        else
        {
            TempData["ErrorMessage"] = "عملیات ناموفق";
        }

        return RedirectToAction("UserProfile", "User");
    }
}

