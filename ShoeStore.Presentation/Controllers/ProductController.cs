using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;

namespace ShoeStore.Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //public async Task<IActionResult> Index(int productId,CancellationToken cancellation=default)
        //{
        //    var pageModel = await _productService.GetProductPageDTO(productId, cancellation);
        //    return View(pageModel);
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}
