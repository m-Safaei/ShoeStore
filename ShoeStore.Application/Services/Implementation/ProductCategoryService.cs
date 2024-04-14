using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.AdminSide.Category;
using ShoeStore.Domain.DTOs.SiteSide.ProductCategory;
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
        return await _productCategoryRepository.GetCategoriesByParentId(parentId, cancellation);
    }

    public async Task<ICollection<ParentCategoryDTO>> GetParentWithChildCategory(CancellationToken cancellation)
    {
        var parentCategories = await _productCategoryRepository.GetParentCategories(cancellation);
        foreach (var parentCategory in parentCategories)
        {
            parentCategory.ChildCategories = await _productCategoryRepository.GetCategoriesByParentId(parentCategory.Id,cancellation);
        }
        return parentCategories;
    }


    //تو اینترفیس اضافه کن
    public async Task<ICollection<CategoryListDTO>?> GetDTOsForListOfCategories(CancellationToken cancellation)
    {
        var categories = await _productCategoryRepository.GetListOfProductCategorisAsync(cancellation);
        var parentCategories = categories.Where(p=> p.ParentId==null).ToList();
        List<CategoryListDTO> returnModel = new();

        foreach(var parentCategory in parentCategories)
        {
            CategoryListDTO item = new()
            {
                ParentCategoryId = parentCategory.Id,
                ParentCategoryName = parentCategory.Title,
                ChildCategories = categories.Where(p=> p.ParentId==parentCategory.Id)
                .Select(p=> new ChildCategoryListDTO() { Id=p.Id,Name=p.Title}).ToList()
            };
            returnModel.Add(item);
        }

        return returnModel;
    }
}
