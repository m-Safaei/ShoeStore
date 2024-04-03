using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using System.Diagnostics;

namespace ShoeStore.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            return View();
        }


        
    }
}
