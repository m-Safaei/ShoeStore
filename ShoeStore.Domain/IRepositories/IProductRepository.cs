using ShoeStore.Domain.DTOs.AdminSide.Product;
using ShoeStore.Domain.DTOs.SiteSide.Product;
using ShoeStore.Domain.Entities.Product;

namespace ShoeStore.Domain.IRepositories;

public interface IProductRepository
{
    Task<List<Product>> GetListOfProductsAsync(CancellationToken cancellation);
    Task<Product?> GetProductByIdAsync(int Id);
    Task<Product?> GetProductByIdAsync(int Id,CancellationToken cancellation);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    Task SaveChangesAsync(CancellationToken cancellation);
    Task<ICollection<ProductPostDTO>?> GetProductPostDTOsByCategoryId(int categoryId, int count, CancellationToken cancellation);
    Task<ICollection<ProductPostDTO>?> GetNewProductDTOs(int count, CancellationToken cancellation);
    Task<ICollection<ProductPostDTO>?> GetOnSaleProductDTOs(int count, CancellationToken cancellation);
    Task<(ICollection<ProductPostDTO>?, int TotalCount)> GetProductDTOsAndCountForCategoryPageByChildCategory(int childCategoryId
        , int pageNumber, string order, CancellationToken cancellation);
    Task<(ICollection<ProductPostDTO>?, int TotalCount)> GetProductDTOsAndCountForCategoryPageByParentCategory(int parentCategoryId
        , int pageNumber, string order, CancellationToken cancellation);
    Task<ICollection<ProductListDTO>?> GetProductListDTOs(CancellationToken cancellation);
    Task<int> GetProductIdByProduct(Product product, CancellationToken cancellation);
}
