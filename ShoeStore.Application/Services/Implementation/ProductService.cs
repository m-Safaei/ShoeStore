using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.Entities.Product;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Application.Services.Implementation;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductItemRepository _productItemRepository;
    public ProductService(IProductRepository productRepository, IProductItemRepository productItemRepository)
    {
        _productRepository = productRepository;
        _productItemRepository = productItemRepository;
    }

    public async Task<Product?> GetProductByIdAsync(int Id, CancellationToken cancellation)
    {
        return await _productRepository.GetProductByIdAsync(Id, cancellation);
    }

    public async Task<ProductItem?> GetProductItemByIdAsync(int Id,CancellationToken cancellation)
    {
        return await _productItemRepository.GetProductItemByIdAsync(Id, cancellation);
    }
}
