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

        public void AddNewComment(Comment newComment)
        {
            if (newComment != null) 
            {
                _context.Comments.Add(newComment);
                _context.SaveChanges();
            }
        }

        public async Task<List<Comment>> GetListOfProductComments() 
        {
            return await _context.Comments.Where(p => !p.IsDelete && p.ProductId != null).ToListAsync();
        }

        public async Task<List<Comment>> GetListOfBlogComments()
        {
            return await _context.Comments.Where(p => !p.IsDelete && p.BlogId != null).ToListAsync();
        }

    }
}
