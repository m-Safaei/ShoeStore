using ShoeStore.Domain.Entities.Comment;

namespace ShoeStore.Domain.IRepositories
{
    public interface ICommentRepository
    {
        void AddComment(Comment Comment);
        Task<List<Comment>> GetListOfProductComments(CancellationToken cancellation);
        Task<List<Comment>> GetListOfBlogComments();
    }
}
