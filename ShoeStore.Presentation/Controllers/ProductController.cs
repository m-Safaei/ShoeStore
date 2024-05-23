using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Application.Utilities;
using ShoeStore.Domain.DTOs.SiteSide.Comment;

namespace ShoeStore.Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;
        public ProductController(IProductService productService, ICommentService commentService)
        {
            _productService = productService;
            _commentService = commentService;
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


        [HttpPost,ValidateAntiForgeryToken,Authorize]
        public async Task<IActionResult> AddCommentForProduct(CommentDTO comment, CancellationToken cancellation = default)
        {
            if (User.Identity.IsAuthenticated)
            {
                //Add Comment For Product
                if (ModelState.IsValid)
                    await _commentService.AddComment(comment, cancellation);

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Login", "Account");
        }

    }
}
