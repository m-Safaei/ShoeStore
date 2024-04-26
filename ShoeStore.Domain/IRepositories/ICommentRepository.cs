using ShoeStore.Domain.Entities.Comment;

namespace ShoeStore.Domain.IRepositories
{
    public interface ICommentRepository
    {
        void AddNewComment(Comment newComment);
        Task<List<Comment>> GetListOfProductComments();
        Task<List<Comment>> GetListOfBlogComments();
    }
}
