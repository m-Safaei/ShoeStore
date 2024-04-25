using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.SiteSide.Comment;
using ShoeStore.Domain.DTOs.SiteSide.Account;
using ShoeStore.Domain.Entities.Comment;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Application.Services.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void AddComment(CommentDTO comment, UserDto user)
        {
            Comment newComment = new Comment()
            {
                UserId = user.Id,
                MessageTitle = comment.MessageTitle,
                MessageBody = comment.MessageBody,
                IsDelete = false,
                IsSeen = false
            };

            _commentRepository.AddNewComment(newComment);
            _commentRepository.SaveChange();

        }

        public void DeleteComment(CommentDTO comment)
        {
            throw new NotImplementedException();
        }
        
    }
}
