using ShoeStore.Domain.DTOs.AdminSide.Category;
using ShoeStore.Domain.DTOs.SiteSide.Product;
using ShoeStore.Domain.DTOs.SiteSide.ProductCategory;
using ShoeStore.Domain.Entities.ProductCategory;

namespace ShoeStore.Domain.IRepositories;

public interface IProductCategoryRepository
{
    Task<List<ProductCategory>> GetListOfProductCategorisAsync(CancellationToken cancellation);
    Task<ProductCategory?> GetProductCategoryByIdAsync(int Id,CancellationToken cancellation);
    Task<int> GetProductCategoryIdByNameAsync(string categoryName, CancellationToken cancellation);
    void AddProductCategory(ProductCategory productCategory);
    void UpdateProductCategory(ProductCategory productCategory);
    Task SaveChangesAsync(CancellationToken cancellation);
    Task<ICollection<CategoryDTO>> GetCategoryDTOsByParentId(int parentId, CancellationToken cancellation);
    Task<ICollection<ProductCategory>?> GetCategoriesByParentId(int parentId, CancellationToken cancellation);
    Task<ICollection<ParentCategoryDTO>> GetParentCategories(CancellationToken cancellation);
    Task<ICollection<ChildCategoryListDTO>?> GetChildCategories(CancellationToken cancellation);
    Task<bool?> IsParentCategory(int categoryId, CancellationToken cancellation);
    Task<string?> GetCategoryNameById(int categoryId, CancellationToken cancellation);
    Task<EditCategoryDTO?> GetEditCategoryDTOById(int categoryId, CancellationToken cancellation);
    Task<ProductPageBreadCrumbDTO?> GetBreadCrumbDTO(int childCategoryId, CancellationToken cancellation);
}
