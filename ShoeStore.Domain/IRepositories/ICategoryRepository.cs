using ShoeStore.Domain.DTOs.SiteSide.Category;
using ShoeStore.Domain.Entities.ProductCategory;

namespace ShoeStore.Domain.IRepositories
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetCategoriesByParentId(int parentId, CancellationToken cancellation);
    }
}
