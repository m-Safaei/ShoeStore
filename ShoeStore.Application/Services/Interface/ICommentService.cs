using ShoeStore.Domain.DTOs.SiteSide.Comment;

namespace ShoeStore.Application.Services.Interface
{
    public interface ICommentService
    {
        public string AddCommentTitle(CommentDTO commentTitle);
        public string AddComment(CommentDTO comment);
    }
}
