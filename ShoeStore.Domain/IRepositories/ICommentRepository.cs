using ShoeStore.Domain.Entities.Comment;

namespace ShoeStore.Domain.IRepositories
{
    public interface ICommentRepository
    {
        void AddNewComment(Comment newComment);
        void AddProductComment(Comment newComment, int productId, int pageId);
        void AddBlogComment(Comment newComment, int blogId, int pageId);
        void DeleteComment(Comment commentId);

    }
}
