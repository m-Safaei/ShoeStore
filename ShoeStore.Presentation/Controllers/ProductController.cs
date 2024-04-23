using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> Index(int productId, CancellationToken cancellation = default)
        {
            var pageModel = await _productService.GetProductPageDTO(productId, cancellation);

            if(pageModel == null) { return RedirectToAction(nameof(ProductNotFound)); }

            ViewData["Sizes"] = new SelectList(pageModel.SizeDTOs, "ProductItemId", "SizeNumber");
            

            return View(pageModel);
        }

        public IActionResult ProductNotFound()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult TestForAddToShopCart(int productItemId, int count)
        {
            //Add to ShopCard
            //return Redirect(/ShopCard/Index);
            return View();
        }


        
        public IActionResult TestForAddToFavorite(int productId)
        {
            //Add to Favorite ...
            return RedirectToAction(nameof(Index),productId);
        }
    }
}
