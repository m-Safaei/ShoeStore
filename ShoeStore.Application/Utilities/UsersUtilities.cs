using System.Security.Claims;
using System.Security.Principal;

namespace ShoeStore.Application.Utilities;

public static class UsersUtilities
{
    public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        if (claimsPrincipal != null)
        {
            var data = claimsPrincipal.Claims.SingleOrDefault(s => s.Type == ClaimTypes.NameIdentifier);
            if (data != null)
            {
                return Convert.ToInt32(data?.Value);
            }

            return default;
        }

        return default;
    }

    public static int GetUserId(this IPrincipal principal)
    {
        var user = (ClaimsPrincipal)principal;

        return user.GetUserId();
    }

    public static string? GetUserMobilePhone(this ClaimsPrincipal claimsPrincipal)
    {
        if (claimsPrincipal != null)
        {
            var data = claimsPrincipal.Claims.SingleOrDefault(s => s.Type == ClaimTypes.MobilePhone);
            if (data != null)
            {
                return Convert.ToString(data?.Value);
            }

            return default;
        }

        return default;
    }

    public static string? GetUserMobilePhone(this IPrincipal principal)
    {
        var user = (ClaimsPrincipal)principal;

        return user.GetUserMobilePhone();
    }
}

