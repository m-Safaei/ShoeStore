using Microsoft.EntityFrameworkCore;
using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.DTOs.AdminSide.Category;
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

    public async Task<int> GetProductCategoryIdByNameAsync(string categoryName,CancellationToken cancellation)
    {
        return await _context.ProductCategories.Where(p => p.Title==categoryName && !p.IsDelete)
            .Select(p=> p.Id).FirstOrDefaultAsync(cancellation);
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync(cancellation);
    }

    public void UpdateProductCategory(ProductCategory productCategory)
    {
        _context.ProductCategories.Update(productCategory);
    }

    public async Task<ICollection<CategoryDTO>> GetCategoryDTOsByParentId(int parentId, CancellationToken cancellation)
    {
        return await _context.ProductCategories.Where(p => p.ParentId == parentId && !p.IsDelete)
            .Select(p => new CategoryDTO()
            {
                Id = p.Id,
                Title = p.Title,
            })
            .ToListAsync(cancellation);
    }

    public async Task<ICollection<ProductCategory>?> GetCategoriesByParentId(int parentId , CancellationToken cancellation)
    {
        return await _context.ProductCategories.Where(p => p.ParentId == parentId && !p.IsDelete).ToListAsync(cancellation);
    }

    public async Task<ICollection<ParentCategoryDTO>> GetParentCategories(CancellationToken cancellation)
    {
        return await _context.ProductCategories.Where(p => p.ParentId == null && !p.IsDelete)
            .Select(p => new ParentCategoryDTO()
            {
                Id = p.Id,
                Title = p.Title,
            })
            .ToListAsync(cancellation);
    }


    public async Task<ICollection<ChildCategoryListDTO>?> GetChildCategories(CancellationToken cancellation)
    {
        return await _context.ProductCategories.Where(p => p.ParentId != null && !p.IsDelete)
            .Select(p => new ChildCategoryListDTO()
            {
                Id = p.Id,
                Name = p.Title,
            })
            .ToListAsync(cancellation);
    }


    public async Task<bool?> IsParentCategory(int categoryId, CancellationToken cancellation)
    {
        var category = await _context.ProductCategories.Where(p => p.Id == categoryId && !p.IsDelete)
            .SingleOrDefaultAsync(cancellation);
        if (category == null) return null;
        return category.ParentId == null;
    }

    public async Task<string?> GetCategoryNameById(int categoryId,CancellationToken cancellation)
    {
        return await _context.ProductCategories.Where(p=>p.Id==categoryId && !p.IsDelete).Select(p=> p.Title).FirstOrDefaultAsync(cancellation);
    }


    public async Task<EditCategoryDTO?> GetEditCategoryDTOById(int categoryId,CancellationToken cancellation)
    {
        return await _context.ProductCategories.Where(p => p.Id == categoryId && !p.IsDelete)
            .Select(p => new EditCategoryDTO() { Id = p.Id, Name = p.Title, ParentId = p.ParentId ,CreateDate=p.CreateDate}).SingleOrDefaultAsync(cancellation);
    }
}
