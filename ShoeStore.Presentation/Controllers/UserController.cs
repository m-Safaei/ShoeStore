using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShoeStore.Presentation.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public IActionResult UserProfile()
        {
            return View();
        }
    }
}
