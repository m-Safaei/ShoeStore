using Microsoft.EntityFrameworkCore;
using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.DTOs.SiteSide.Category;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShoeStoreDbContext _context;

        public CategoryRepository(ShoeStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> GetCategoriesByParentId(int parentId, CancellationToken cancellation)
        {
            return await _context.ProductCategories.Where(p => p.ParentId == parentId)
                .Select(p => new CategoryDto()
                {
                    Id = p.Id,
                    Title = p.Title,
                })
                .ToListAsync(cancellation);
        }
    }
}
