using Microsoft.EntityFrameworkCore;
using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.DTOs.SiteSide.Product;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Data.Repositories;

public class ProductFeatureRepository : IProductFeatureRepository
{
    private readonly ShoeStoreDbContext _context;
    public ProductFeatureRepository(ShoeStoreDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<ProductFeatureDTO>?> GetProductFeatureDTOsByProductId(int productId,CancellationToken cancellation)
    {
        return await _context.ProductFeatures.Where(p=> p.ProductId == productId).Select(p=> new ProductFeatureDTO() 
                                        { FeatureTitle = p.FeatureTitle, FeatureDescription = p.FeatureDescription,}).ToListAsync(cancellation);
    }
}
