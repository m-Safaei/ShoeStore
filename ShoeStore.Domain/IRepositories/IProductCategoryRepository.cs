using ShoeStore.Domain.DTOs.SiteSide.ProductCategory;
using ShoeStore.Domain.Entities.ProductCategory;

namespace ShoeStore.Domain.IRepositories;

public interface IProductCategoryRepository
{
    Task<List<ProductCategory>> GetListOfProductCategorisAsync(CancellationToken cancellation);
    Task<ProductCategory?> GetProductCategoryByIdAsync(int Id,CancellationToken cancellation);
    void AddProductCategory(ProductCategory productCategory);
    void UpdateProductCategory(ProductCategory productCategory);
    Task SaveChangesAsync(CancellationToken cancellation);
    Task<ICollection<CategoryDTO>> GetCategoriesByParentId(int parentId, CancellationToken cancellation);
    Task<ICollection<ParentCategoryDTO>> GetParentCategories(CancellationToken cancellation);
}
