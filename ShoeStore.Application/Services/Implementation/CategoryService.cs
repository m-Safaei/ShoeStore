using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.SiteSide.Category;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Application.Services.Implementation
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDto>> GetCategoriesByParentId(int parentId,CancellationToken cancellation)
        {
            return await _categoryRepository.GetCategoriesByParentId(parentId, cancellation);
        }
    }
}
