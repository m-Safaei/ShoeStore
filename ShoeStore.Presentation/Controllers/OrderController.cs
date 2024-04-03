#region MyRegion
using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Implementation;
using ShoeStore.Application.Services.Interface;

namespace ShoeStore.Presentation.Controllers;
#endregion
public class OrderController : Controller
{
    #region ctor
    public readonly IUserService _userService;
    public OrderController (IUserService userService)
    {
        _userService = userService;
    }
    #endregion
    //public IActionResult AddToShopCart(int Id)
    //{
    //    if (Id==null)
    //    {
    //        return NotFound();
    //    }
    //    var _user = _userService.GetUserByMobileAsync(User.Identity.Name);
     
    //}
}
