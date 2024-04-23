using ShoeStore.Domain.Entities.Comment;

namespace ShoeStore.Domain.IRepositories
{
    public interface ICommentRepository
    {
        void AddComment(Comment comment);
        void Savechanges();

    }
}
