using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.SiteSide.Product;
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

    public async Task<Product?> GetProductByIdAsync(int Id)
    {
        return await _productRepository.GetProductByIdAsync(Id);
    }

    public Task<Product?> GetProductByIdAsync(int Id, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductItem?> GetProductItemByIdAsync(int Id, CancellationToken cancellation)
    {
        return await _productItemRepository.GetProductItemByIdAsync(Id, cancellation);
    }

    public async Task<ProductPageDTO?> GetProductPageDTO(int productId, CancellationToken cancellation)
    {
        var product = await GetProductByIdAsync(productId, cancellation);
        if (product == null) { return null; }
        return new ProductPageDTO()
        {
            ProductId = product.Id,
            Name = product.Name,
            Description = product.Description,
            ProductCategoryId = product.ProductCategoryId,
            ProductImages = product.ProductImages,
        };
    }

    
}
