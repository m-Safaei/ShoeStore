using Microsoft.AspNetCore.Mvc;
using ShoeStore.Application.Services.Interface;

namespace ShoeStore.Presentation.ViewComponents;

public class CategoryViewComponent : ViewComponent
{

    #region Ctor
    
    private readonly ICategoryService _categoryService;

    public CategoryViewComponent(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    #endregion
    public async Task<IViewComponentResult> InvokeAsync(int parentId, CancellationToken cancellation)
    {
        return View("Category",await _categoryService.GetCategoriesByParentId(parentId,cancellation));
    }
}

