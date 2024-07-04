using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.SiteSide.Comment;
using ShoeStore.Domain.Entities.Comment;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Application.Services.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;

        public CommentService(ICommentRepository commentRepository,IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }

        public async Task AddComment(CommentDTO comment, CancellationToken cancellation)
        {
            var user = await _userRepository.GetUserByIdAsync(comment.UserId, cancellation);
            var userName = user.FirstName + " " + user.LastName;

            Comment newComment = new Comment()
            {
                UserId = comment.UserId,
                UserName = userName,
                ProductId = comment.ProductId,
                MessageTitle = comment.MessageTitle,
                MessageBody = comment.MessageBody,
                IsDelete = false,
                IsSeen = false
            };

            _commentRepository.AddComment(newComment,cancellation);
        }

        public async Task<List<Comment>> GetListOfProductComments(CancellationToken cancellation)
        {
            return await _commentRepository.GetListOfProductComments(cancellation);
        }

        public async Task<List<Comment>> GetListOfBlogComments()
        {
            return await _commentRepository.GetListOfBlogComments();
        }

    }
}
