using ShoeStore.Domain.DTOs.SiteSide.Comment;
using ShoeStore.Domain.Entities.Comment;

namespace ShoeStore.Application.Services.Interface
{
    public interface ICommentService
    {
        void AddComment(CommentDTO comment);
        Task<List<Comment>> GetListOfProductComments(CancellationToken cancellation);
        Task<List<Comment>> GetListOfBlogComments();
    }
}
