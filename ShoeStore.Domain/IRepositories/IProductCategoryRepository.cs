using ShoeStore.Domain.Entities.Category;

namespace ShoeStore.Domain.IRepositories;

public interface IProductCategoryRepository
{
    Task<List<ProductCategory>> GetListOfProductCategorisAsync(CancellationToken cancellation);
    Task<ProductCategory?> GetProductCategoryByIdAsync(int Id,CancellationToken cancellation);
    void AddProductCategory(ProductCategory productCategory);
    void UpdateProductCategory(ProductCategory productCategory);
    Task SaveChangesAsync(CancellationToken cancellation);
}
