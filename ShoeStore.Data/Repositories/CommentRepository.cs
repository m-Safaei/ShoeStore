using Microsoft.EntityFrameworkCore;
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

        public void AddComment(Comment Comment)
        {
            if (Comment != null) 
            {
                _context.Comments.Add(Comment);
                _context.SaveChanges();
            }
        }

        public async Task<List<Comment>> GetListOfProductComments(CancellationToken cancellation) 
        {
            return await _context.Comments.Where(p => !p.IsDelete && p.ProductId != null).ToListAsync(cancellation);
        }

        public async Task<List<Comment>> GetListOfBlogComments()
        {
            return await _context.Comments.Where(p => !p.IsDelete && p.BlogId != null).ToListAsync();
        }

    }
}
