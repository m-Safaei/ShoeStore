using Microsoft.AspNetCore.Mvc.Filters;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Application.Utilities;

namespace ShoeStore.Presentation.Areas.Admin.ActionFilterAttributes;

public class CheckUserIsAdmin: ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var service = (IRoleService)context.HttpContext.RequestServices.GetService(typeof(IRoleService))!;

        base.OnActionExecuting(context);

        var userId = context.HttpContext.User.GetUserId();

        var result = service.IsUserAdmin(userId);
        if (result == false)
        {
            context.HttpContext.Response.Redirect("/");
        }
    }
}

