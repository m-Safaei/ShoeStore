using Microsoft.EntityFrameworkCore;
using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.Entities.Category;
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
        await _context.SaveChangesAsync();
    }

    public void UpdateProductCategory(ProductCategory productCategory)
    {
        _context.ProductCategories.Update(productCategory);
    }
}
