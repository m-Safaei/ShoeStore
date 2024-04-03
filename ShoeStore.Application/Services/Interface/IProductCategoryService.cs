﻿using ShoeStore.Domain.DTOs.SiteSide.ProductCategory;

namespace ShoeStore.Application.Services.Interface;

public interface IProductCategoryService
{
    Task<ICollection<CategoryDTO>> GetCategoriesByParentId(int parentId, CancellationToken cancellation);
    Task<ICollection<ParentCategoryDTO>> GetParentWithChildCategory(CancellationToken cancellation);
}