using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.Entities.Comment;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Application.Services.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _comment;

        public CommentService(ICommentRepository comment)
        {
            _comment = comment;
        }

        public void AddComment(Comment comment, int userid)
        {
            comment.UserId = userid;
            comment.CreateDate = DateTime.Now;
            comment.MessageTitle = string.Empty;
            comment.MessageBody= string.Empty;
            comment.IsSeen = false;
            comment.IsDelete = false;

            _comment.AddComment(comment);
        }

    }
}
