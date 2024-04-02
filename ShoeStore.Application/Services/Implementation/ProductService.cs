using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.Entities.Product;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Application.Services.Implementation;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> GetProductByIdAsync(int Id, CancellationToken cancellation)
    {
        return await _productRepository.GetProductByIdAsync(Id, cancellation);
    }
}
