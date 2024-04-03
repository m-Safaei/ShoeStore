using Microsoft.EntityFrameworkCore;
using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.DTOs.SiteSide.ProductCategory;
using ShoeStore.Domain.Entities.ProductCategory;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Data.Repositories;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly ShoeStoreDbContext _context;
    public ProductCategoryRepository(ShoeStoreDbContext context)
    {
        _context = context;
    }

    public void AddProductCategory(ProductCategory productCategory)
    {
        _context.ProductCategories.Add(productCategory);
    }

    public async Task<List<ProductCategory>> GetListOfProductCategorisAsync(CancellationToken cancellation)
    {
        return await _context.ProductCategories.Where(p => !p.IsDelete).ToListAsync();
    }

    public async Task<ProductCategory?> GetProductCategoryByIdAsync(int Id, CancellationToken cancellation)
    {
        return await _context.ProductCategories.FirstOrDefaultAsync(p => p.Id == Id && !p.IsDelete);
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync(cancellation);
    }

    public void UpdateProductCategory(ProductCategory productCategory)
    {
        _context.ProductCategories.Update(productCategory);
    }

    public async Task<ICollection<CategoryDTO>> GetCategoriesByParentId(int parentId, CancellationToken cancellation)
    {
        return await _context.ProductCategories.Where(p => p.ParentId == parentId)
            .Select(p => new CategoryDTO()
            {
                Id = p.Id,
                Title = p.Title,
            })
            .ToListAsync(cancellation);
    }

    public async Task<ICollection<ParentCategoryDTO>> GetParentCategories(CancellationToken cancellation)
    {
        return await _context.ProductCategories.Where(p => p.ParentId == null)
            .Select(p => new ParentCategoryDTO()
            {
                Id = p.Id,
                Title = p.Title,
            })
            .ToListAsync(cancellation);
    }
}
