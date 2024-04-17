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


        public async Task<IActionResult> ListOfProducts(CancellationToken cancellation = default)
        {
            var model = await _productService.GetProductListDTOs(cancellation);
            return View(model);
        }

        public async Task<IActionResult> CreateProduct(CancellationToken cancellation = default)
        {
            var categories = await _categoryService.GetChildCategories(cancellation);
            ViewData["Categories"] = new SelectList(categories, "Id", "Name");
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(CreateProductDTO model, CancellationToken cancellation = default)
        {
            if (ModelState.IsValid)
            {
                var productId = await _productService.CreateProduct(model, cancellation);
                return RedirectToAction(nameof(ProductDetails), new { productId = productId });
            }
            return View(model);
        }


        public async Task<IActionResult> ProductDetails(int productId, CancellationToken cancellation = default)
        {
            var model = await _productService.GetProductDetailsDTO(productId, cancellation);

            if (model == null) return Redirect("NotFound");

            var sizes = await _productService.GetAvailableSizeDTOs(productId, cancellation);

            ViewData["Sizes"] = new SelectList(sizes, "Id", "SizeNumber");

            return View(model);
        }



        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProductFeature(int productId, string featureTitle, string featureDescription, CancellationToken cancellation = default)
        {
            if(ModelState.IsValid)
            {
                var res = await _productService.AddProductFeauture(productId, featureTitle, featureDescription, cancellation);
                if (res) return RedirectToAction(nameof(ProductDetails), new { productId = productId });
                return Redirect("NotFound");
            }
            
            return RedirectToAction(nameof(ProductDetails), new { productId = productId });
        }


        public async Task<IActionResult> DeleteProductFeature(int productFeatureId, int productId, CancellationToken cancellation = default)
        {
            var res = await _productService.RemoveProductFeature(productFeatureId, cancellation);
            if (res) return RedirectToAction(nameof(ProductDetails), new { productId = productId });
            return Redirect("NotFound");
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProductItem(int productId, int sizeId, int count, CancellationToken cancellation = default)
        {
            if(ModelState.IsValid)
            {
                var res = await _productService.AddProductItem(productId, sizeId, count, cancellation);
                if (res) return RedirectToAction(nameof(ProductDetails), new { productId = productId });
                return Redirect("NotFound");
            }
            
            return RedirectToAction(nameof(ProductDetails), new { productId = productId });
        }


        public async Task<IActionResult> DeleteProductItem(int productId, int productItemId, CancellationToken cancellation = default)
        {
            var res = await _productService.RemoveProductItem(productItemId, cancellation);
            if (res) return RedirectToAction(nameof(ProductDetails), new { productId = productId });
            return Redirect("NotFound");
        }


        public async Task<IActionResult> EditProduct(int productId, CancellationToken cancellation = default)
        {
            var model = await _productService.GetCreateProductDTOById(productId, cancellation);
            if (model == null) return Redirect("NotFound");
            var categories = await _categoryService.GetChildCategories(cancellation);
            ViewData["Categories"] = new SelectList(categories, "Id", "Name");
            return View(model);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(CreateProductDTO productDTO, CancellationToken cancellation = default)
        {
            if (ModelState.IsValid)
            {
                var res = await _productService.EditProduct(productDTO, cancellation);
                if (res) return RedirectToAction(nameof(ProductDetails), new { productId = productDTO.Id });
                return Redirect("NotFound");
            }

            return View(productDTO);
        }


        public async Task<IActionResult> DeleteProduct(int productId, CancellationToken cancellation = default)
        {
            var model = await _productService.GetProductDetailsDTO(productId, cancellation);
            if (model == null) return Redirect("NotFound");
            return View(model);
        }


        public async Task<IActionResult> RemoveProduct(int productId, CancellationToken cancellation = default)
        {
            var res = await _productService.RemoveProductAndItsItemsAndFeatures(productId, cancellation);
            if (res) return RedirectToAction(nameof(ListOfProducts));
            return Redirect("NotFound");
        }
    }
}
