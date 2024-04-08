using ShoeStore.Domain.DTOs.SiteSide.Comment;
using ShoeStore.Domain.Entities.Comment;
using System.Security.Cryptography;

namespace ShoeStore.Application.Services.Interface
{
    public interface ICommentService
    {
        void AddComment(Comment comment, int userid);
        //Tuple<List<Comment>, int> GetBlogComment(int BlogId, int pageId);
        //Tuple<List<Comment>, int> GetProductComment(int ProductId, int pageId);

    }
}
