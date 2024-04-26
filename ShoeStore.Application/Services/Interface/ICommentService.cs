using ShoeStore.Domain.DTOs.SiteSide.Comment;

namespace ShoeStore.Application.Services.Interface
{
    public interface ICommentService
    {
        void AddComment(CommentDTO comment);
    }
}
