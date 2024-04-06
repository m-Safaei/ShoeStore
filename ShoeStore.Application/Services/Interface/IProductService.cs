using ShoeStore.Domain.DTOs.SiteSide.Product;
using ShoeStore.Domain.Entities.Product;

namespace ShoeStore.Application.Services.Interface;

public interface IProductService
{
    Task<Product?> GetProductByIdAsync(int Id, CancellationToken cancellation);
    Task<ProductItem?> GetProductItemByIdAsync(int Id, CancellationToken cancellation);
    Task<ProductPageDTO?> GetProductPageDTO(int productId, CancellationToken cancellation);
}
