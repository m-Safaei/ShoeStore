using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.Entities.Comment;
using ShoeStore.Domain.Entities.Product;
using ShoeStore.Domain.IRepositories;
using System.Linq;

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
            if (!newComment.IsSeen && !newComment.IsDelete) 
            {
                _context.Comment.ToList().Add(newComment);
                _context.SaveChanges();
            }
        }

        public void AddProductComment(Comment newComment, int productId)
        {
            if (newComment.ProductId == productId)
                AddNewComment(newComment);
        }

        public void AddBlogComment(Comment newComment, int blogId)
        {
            if (newComment.BlogId == blogId)
                AddNewComment(newComment);
        }

        public void DeleteComment(Comment commentId)
        {
            throw new NotImplementedException();
        }

    }
}
