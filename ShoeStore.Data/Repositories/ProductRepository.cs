using Microsoft.EntityFrameworkCore;
using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.DTOs.SiteSide.Product;
using ShoeStore.Domain.Entities.Product;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ShoeStoreDbContext _context;
    public ProductRepository(ShoeStoreDbContext context)
    {
        _context = context;
    }

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
    }

    public async Task<List<Product>> GetListOfProductsAsync(CancellationToken cancellation)
    {
        return await _context.Products.Where(p=> !p.IsDelete).ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int Id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == Id && !p.IsDelete);
    }

    public async Task<Product?> GetProductByIdAsync(int Id,CancellationToken cancellation)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == Id && !p.IsDelete);
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync();
    }

    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
    }

    public async Task<ICollection<ProductPostDTO>?> GetProductPostDTOsByCategoryId(int categoryId,int count , CancellationToken cancellation)
    {
        return await _context.Products.Where(p=> p.ProductCategoryId == categoryId && !p.IsDelete)
            .Select(p=> new ProductPostDTO() { ProductId=p.Id, Name=p.Name,Price=p.Price,ProductImage=p.ProductImage})
            .Take(count).ToListAsync(cancellation);

    }
}
