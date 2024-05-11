using ShoeStore.Domain.DTOs.SiteSide.Comment;
using ShoeStore.Domain.Entities.Comment;

namespace ShoeStore.Application.Services.Interface
{
    public interface ICommentService
    {
        Task AddComment(CommentDTO comment, int userId, CancellationToken cancellation);
        Task<List<Comment>> GetListOfProductComments(CancellationToken cancellation);
        Task<List<Comment>> GetListOfBlogComments();
    }
}
