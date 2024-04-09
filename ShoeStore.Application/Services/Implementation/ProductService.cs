using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.SiteSide.Product;
using ShoeStore.Domain.Entities.Product;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Application.Services.Implementation;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductItemRepository _productItemRepository;
    private readonly IProductFeatureRepository _productFeatureRepository;
    private readonly ISizeRepository _sizeRepository;
    public ProductService(IProductRepository productRepository, IProductItemRepository productItemRepository, 
                            IProductFeatureRepository productFeatureRepository, ISizeRepository sizeRepository)
    {
        _productRepository = productRepository;
        _productItemRepository = productItemRepository;
        _productFeatureRepository = productFeatureRepository;
        _sizeRepository = sizeRepository;
    }

    public async Task<Product?> GetProductByIdAsync(int Id)
    {
        return await _productRepository.GetProductByIdAsync(Id);
    }

    public async Task<Product?> GetProductByIdAsync(int Id, CancellationToken cancellation)
    {
        return await _productRepository.GetProductByIdAsync(Id,cancellation);
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
            Price = product.Price,
            DiscountPercentage = product.DiscountPercentage,
            ProductImage = product.ProductImage,
            ProductFeatureDTOs = await _productFeatureRepository.GetProductFeatureDTOsByProductId(productId,cancellation),
            SizeDTOs = await _sizeRepository.GetSizeDTOsByProductId(productId,cancellation)
        };
    }


    public async Task<ICollection<ProductPostDTO>?> GetProductPostDTOsByCategoryId(int categoryId,int count, CancellationToken cancellation)
    {
        return await _productRepository.GetProductPostDTOsByCategoryId(categoryId, count, cancellation);
    }


    public async Task<ICollection<ProductPostDTO>?> GetNewProductDTOs(int count, CancellationToken cancellation)
    {
        return await _productRepository.GetNewProductDTOs(count, cancellation);
    }


    public async Task<ICollection<ProductPostDTO>?> GetOnSaleProductDTOs(int count, CancellationToken cancellation)
    {
        return await _productRepository.GetOnSaleProductDTOs(count,cancellation);
    }


}
