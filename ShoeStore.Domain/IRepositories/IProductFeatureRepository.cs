using ShoeStore.Domain.DTOs.SiteSide.Product;

namespace ShoeStore.Domain.IRepositories;

public interface IProductFeatureRepository
{
    Task<ICollection<ProductFeatureDTO>?> GetProductFeatureDTOsByProductId(int productId, CancellationToken cancellation);
}
