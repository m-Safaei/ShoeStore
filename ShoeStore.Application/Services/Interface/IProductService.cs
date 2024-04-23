using ShoeStore.Domain.DTOs.AdminSide.Product;
using ShoeStore.Domain.DTOs.SiteSide.Product;
using ShoeStore.Domain.DTOs.SiteSide.ProductCategory;
using ShoeStore.Domain.Entities.Product;

namespace ShoeStore.Application.Services.Interface;

public interface IProductService
{
    Task<Product?> GetProductByIdAsync(int Id, CancellationToken cancellation);
    Task<Product?> GetProductByIdAsync(int Id);

    Task<ProductItem?> GetProductItemByIdAsync(int Id, CancellationToken cancellation);
    Task<ProductPageDTO?> GetProductPageDTO(int productId, CancellationToken cancellation);
    Task<ICollection<ProductPostDTO>?> GetProductPostDTOsByCategoryId(int categoryId, int count, CancellationToken cancellation);
    Task<CategoryPageDTO?> GetCategoryPageDTOByName(string categoryName, int pageNumber, string order, CancellationToken cancellation);
    Task<ICollection<ProductPostDTO>?> GetNewProductDTOs(int count, CancellationToken cancellation);
    Task<ICollection<ProductPostDTO>?> GetOnSaleProductDTOs(int count, CancellationToken cancellation);
    Task<(ICollection<ProductPostDTO>?, int TotalCount)> GetProductDTOsAndCountForCategoryPage(int categoryId
        , int pageNumber, string order, CancellationToken cancellation);
    Task<CategoryPageDTO?> GetCategoryPageDTOById(int categoryId, int pageNumber, string order, CancellationToken cancellation);
    Task<ICollection<ProductListDTO>?> GetProductListDTOs(CancellationToken cancellation);
    Task<int> CreateProduct(CreateProductDTO model, CancellationToken cancellation);
    Task<ProductDetailsDTO?> GetProductDetailsDTO(int productId, CancellationToken cancellation);
    Task<ICollection<SizeAdminSideDTO>?> GetAvailableSizeDTOs(int productId, CancellationToken cancellation);
    Task<bool> AddProductFeauture(int productId, string featureTitle, string featureDescription, CancellationToken cancellation);
    Task<bool> RemoveProductFeature(int productFeatureId, CancellationToken cancellation);
    Task<bool> AddProductItem(int productId, int sizeId, int count, CancellationToken cancellation);
    Task<bool> RemoveProductItem(int productItemId, CancellationToken cancellation);
    Task<CreateProductDTO?> GetCreateProductDTOById(int productId, CancellationToken cancellation);
    Task<bool> EditProduct(CreateProductDTO productDTO, CancellationToken cancellation);
    Task<bool> RemoveProductAndItsItemsAndFeatures(int productId, CancellationToken cancellation);
}
