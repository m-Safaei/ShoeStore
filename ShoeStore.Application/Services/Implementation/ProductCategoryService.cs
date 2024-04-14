using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.AdminSide.Category;
using ShoeStore.Domain.DTOs.SiteSide.ProductCategory;
using ShoeStore.Domain.Entities.ProductCategory;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Application.Services.Implementation;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<ICollection<CategoryDTO>> GetCategoriesByParentId(int parentId, CancellationToken cancellation)
    {
        return await _productCategoryRepository.GetCategoryDTOsByParentId(parentId, cancellation);
    }

    public async Task<ICollection<ParentCategoryDTO>> GetParentWithChildCategory(CancellationToken cancellation)
    {
        var parentCategories = await _productCategoryRepository.GetParentCategories(cancellation);
        foreach (var parentCategory in parentCategories)
        {
            parentCategory.ChildCategories = await _productCategoryRepository.GetCategoryDTOsByParentId(parentCategory.Id, cancellation);
        }
        return parentCategories;
    }



    public async Task<ICollection<CategoryListDTO>?> GetDTOsForListOfCategories(CancellationToken cancellation)
    {
        var categories = await _productCategoryRepository.GetListOfProductCategorisAsync(cancellation);
        var parentCategories = categories.Where(p => p.ParentId == null).ToList();
        List<CategoryListDTO> returnModel = new();

        foreach (var parentCategory in parentCategories)
        {
            CategoryListDTO item = new()
            {
                ParentCategoryId = parentCategory.Id,
                ParentCategoryName = parentCategory.Title,
                ChildCategories = categories.Where(p => p.ParentId == parentCategory.Id)
                .Select(p => new ChildCategoryListDTO() { Id = p.Id, Name = p.Title }).ToList()
            };
            returnModel.Add(item);
        }

        return returnModel;
    }


    public async Task CreateCategory(CreateCategoryDTO categoryDTO, CancellationToken cancellation)
    {
        ProductCategory productCategory = new()
        {
            CreateDate = DateTime.Now,
            ParentId = categoryDTO.ParentId,
            Title = categoryDTO.CategoryName
        };
        _productCategoryRepository.AddProductCategory(productCategory);
        await _productCategoryRepository.SaveChangesAsync(cancellation);
    }


    public async Task<bool> DeleteCategory(int categoryId, CancellationToken cancellation)
    {
        var category = await _productCategoryRepository.GetProductCategoryByIdAsync(categoryId, cancellation);

        if (category == null) return false;

        category.IsDelete = true;
        _productCategoryRepository.UpdateProductCategory(category);

        if (category.ParentId != null)
        {
            var childCategories = await _productCategoryRepository.GetCategoriesByParentId(categoryId, cancellation);
            if (childCategories != null && childCategories.Any())
            {
                foreach (var childCategory in childCategories)
                {
                    childCategory.IsDelete = true;
                    _productCategoryRepository.UpdateProductCategory(childCategory);
                }
            }

        }

        await _productCategoryRepository.SaveChangesAsync(cancellation);
        return true;
    }


    public async Task<EditCategoryDTO?> GetEditCategoryDTOById(int categoryId, CancellationToken cancellation)
    {
        return await _productCategoryRepository.GetEditCategoryDTOById(categoryId, cancellation);
    }
}
