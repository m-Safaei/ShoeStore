using Microsoft.AspNetCore.Mvc;

namespace ShoeStore.Presentation.ViewComponents;

public class CategoryViewComponent : ViewComponent
{
    #region Ctor

    public CategoryViewComponent()
    {
        
    }

    #endregion
    public async Task<IViewComponentResult> InvokeAsync(int CategoryId, CancellationToken cancellation)
    {
        return View("Category");
    }
}

