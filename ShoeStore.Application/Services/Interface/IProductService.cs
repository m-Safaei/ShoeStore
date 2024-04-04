using ShoeStore.Domain.Entities.Product;

namespace ShoeStore.Application.Services.Interface;

public interface IProductService
{

    Task<Product?> GetProductByIdAsync(int Id);


    Task<Product?> GetProductByIdAsync(int Id, CancellationToken cancellation);
    Task<ProductItem?> GetProductItemByIdAsync(int Id, CancellationToken cancellation);

}


