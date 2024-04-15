using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.AdminSide.Product;

namespace ShoeStore.Presentation.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _categoryService;
        public ProductController(IProductService productService, IProductCategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }


        public async Task<IActionResult> ListOfProducts(CancellationToken cancellation=default)
        {
            var model = await _productService.GetProductListDTOs(cancellation);
            return View(model);
        }

        public async Task<IActionResult> CreateProduct(CancellationToken cancellation=default)
        {
            var categories = await _categoryService.GetChildCategories(cancellation);
            ViewData["Categories"] = new SelectList(categories, "Id", "Name");
            return View();
        }


        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(CreateProductDTO model,CancellationToken cancellation=default)
        {
            if (ModelState.IsValid)
            {
                var productId = await _productService.CreateProduct(model, cancellation);
                RedirectToAction(nameof(ProductDetails), productId);
            }
            return View(model);
        }


        public async Task<IActionResult> ProductDetails(int productId , CancellationToken cancellation=default)
        {
            //GetProduct By Id
            return View();
        }
    }
}
