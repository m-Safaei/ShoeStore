using ShoeStore.Domain.Entities.Product;

namespace ShoeStore.Application.Services.Interface;

public interface IProductService
{

    Task<Product?> GetProductByIdAsync(int Id);
    Task<ProductItem?> GetProductItemByIdAsync(int Id);

}


