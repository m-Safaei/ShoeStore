using ShoeStore.Domain.Entities.Color_Size;
using ShoeStore.Domain.Entities.Product;

namespace ShoeStore.Domain.IRepositories;

public interface IProductItemRepository
{
    Task<List<ProductItem>> GetListOfProductItemsAsync(CancellationToken cancellation);
    Task<ProductItem?> GetProductItemByIdAsync(int Id, CancellationToken cancellation);
    void AddProductItem(ProductItem productItem);
    void UpdateProductItem(ProductItem productItem);
    Task SaveChangesAsync(CancellationToken cancellation);
    Task<List<Color?>?> GetExistingColorsByProductId(int productId, CancellationToken cancellation);
}
