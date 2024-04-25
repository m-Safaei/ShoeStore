using ShoeStore.Domain.Entities.Comment;

namespace ShoeStore.Domain.IRepositories
{
    public interface ICommentRepository
    {
        void AddNewComment(Comment newComment);
        void AddBlogComment(int BlogId, int pageId);
        void AddProductComment(int ProductId, int pageId);
        void DeleteComment(List<Comment> comment);
        void SaveChange();

    }
}
