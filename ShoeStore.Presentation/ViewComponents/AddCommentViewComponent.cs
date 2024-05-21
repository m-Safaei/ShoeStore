using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Application.Utilities;
using ShoeStore.Domain.DTOs.SiteSide.Comment;

namespace ShoeStore.Presentation.ViewComponents
{
    public class AddCommentViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;
        public AddCommentViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CommentDTO newComment, CancellationToken cancellation = default)
        {

            return View("AddComment", 
                await _commentService.AddComment(newComment, User.GetUserId(), cancellation));
        }
    }
}
