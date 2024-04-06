using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShoeStore.Presentation.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class AdminBaseController : Controller
{
  
}

