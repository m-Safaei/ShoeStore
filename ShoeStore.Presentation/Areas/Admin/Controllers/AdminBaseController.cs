using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoeStore.Presentation.Areas.Admin.ActionFilterAttributes;

namespace ShoeStore.Presentation.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
[CheckUserIsAdmin]
public class AdminBaseController : Controller
{
  
}

