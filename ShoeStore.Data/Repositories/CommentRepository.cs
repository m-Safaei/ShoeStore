using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.Entities.Comment;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ShoeStoreDbContext _context;
        public CommentRepository(ShoeStoreDbContext context)
        {
            _context = context;
        }

        public void AddNewComment(Comment newComment)
        {
            throw new NotImplementedException();
        }

        public void AddProductComment(int ProductId, int pageId)
        {
            throw new NotImplementedException();
        }
        
        public void AddBlogComment(int BlogId, int pageId)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(List<Comment> comment)
        {
            throw new NotImplementedException();
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
