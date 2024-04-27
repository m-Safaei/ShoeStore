using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;

namespace ShoeStore.Presentation.ViewComponents
{
    public class ListOfCommentsViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;
        public ListOfCommentsViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellation = default)
        {
            return View("ListOfComments", await _commentService.GetListOfProductComments(cancellation));
        }
    }
}
