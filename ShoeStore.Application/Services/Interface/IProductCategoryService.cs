﻿using ShoeStore.Domain.DTOs.AdminSide.Category;
using ShoeStore.Domain.DTOs.SiteSide.Product;
using ShoeStore.Domain.DTOs.SiteSide.ProductCategory;

namespace ShoeStore.Application.Services.Interface;

public interface IProductCategoryService
{
    Task<ICollection<CategoryDTO>> GetCategoriesByParentId(int parentId, CancellationToken cancellation);
    Task<ICollection<ParentCategoryDTO>> GetParentWithChildCategory(CancellationToken cancellation);
    Task<ICollection<CategoryListDTO>?> GetDTOsForListOfCategories(CancellationToken cancellation);
    Task CreateCategory(CreateCategoryDTO categoryDTO, CancellationToken cancellation);
    Task<bool> DeleteCategory(int categoryId, CancellationToken cancellation);
    Task<EditCategoryDTO?> GetEditCategoryDTOById(int categoryId, CancellationToken cancellation);
    Task<bool> EditCategory(EditCategoryDTO categryDTO, CancellationToken cancellation);
    Task<ICollection<ChildCategoryListDTO>?> GetChildCategories(CancellationToken cancellation);
    Task<ProductPageBreadCrumbDTO?> GetProductPageBreadCrumbDTO(int childCategoryId, CancellationToken cancellation);
}
