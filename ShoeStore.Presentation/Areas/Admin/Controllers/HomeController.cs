using Microsoft.AspNetCore.Mvc;

namespace ShoeStore.Presentation.Areas.Admin.Controllers;

public class HomeController : AdminBaseController
{
    public IActionResult Index()
    {
        return View();
    }
}

