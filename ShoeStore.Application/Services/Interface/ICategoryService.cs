using ShoeStore.Domain.DTOs.SiteSide.Category;

namespace ShoeStore.Application.Services.Interface
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetCategoriesByParentId(int parentId, CancellationToken cancellation);
    }
}
