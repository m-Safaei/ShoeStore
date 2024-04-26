using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.Entities.Comment;
using ShoeStore.Domain.Entities.User;
using System.Xml.Linq;

namespace ShoeStore.Presentation.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
    }


    /*
    [HttpGet]
    public IActionResult ShowComment(int id, int pageId = 1)
    {
        return View();
    }
    
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult ShowComment(int id, int pageId = 1)
    {
        return View();
    }

    [HttpGet]
    public IActionResult CreateProductComment()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult CreateProductComment(Comment comment)
    {

        return View();
    }

    [HttpGet]
    public IActionResult CreateBlogComment()
    {
        return View();
    }

    [HttpPost,ValidateAntiForgeryToken]
    public IActionResult CreateBlogComment(Comment comment)
    {
        
        return View();
    }
    */

}
