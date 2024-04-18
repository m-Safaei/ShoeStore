using ShoeStore.Domain.DTOs.SiteSide.Product;
using ShoeStore.Domain.Entities.Product;

namespace ShoeStore.Domain.IRepositories;

public interface IProductFeatureRepository
{
    Task<ICollection<ProductFeatureDTO>?> GetProductFeatureDTOsByProductId(int productId, CancellationToken cancellation);
    Task<ProductFeature?> GetProductFeatureById(int productFeatureId, CancellationToken cancellation);
    void RemoveProductFeature(ProductFeature productFeature);
    void AddProductFeature(ProductFeature productFeature);
    Task SaveChangesAsync(CancellationToken cancellation);
    Task<ICollection<ProductFeature>?> GetProductFeaturesByProductId(int productId, CancellationToken cancellation);
}
