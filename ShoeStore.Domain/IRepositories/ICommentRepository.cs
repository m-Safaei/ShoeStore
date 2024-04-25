using ShoeStore.Domain.Entities.Comment;

namespace ShoeStore.Domain.IRepositories
{
    public interface ICommentRepository
    {
        void AddNewComment(Comment newComment);
        void AddProductComment(Comment newComment, int productId);
        void AddBlogComment(Comment newComment, int blogId);
        void DeleteComment(Comment commentId);

    }
}
