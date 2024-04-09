﻿using ShoeStore.Domain.DTOs.SiteSide.Product;
using ShoeStore.Domain.Entities.Product;

namespace ShoeStore.Application.Services.Interface;

public interface IProductService
{
    Task<Product?> GetProductByIdAsync(int Id, CancellationToken cancellation);
    Task<Product?> GetProductByIdAsync(int Id);

    Task<ProductItem?> GetProductItemByIdAsync(int Id, CancellationToken cancellation);
    Task<ProductPageDTO?> GetProductPageDTO(int productId, CancellationToken cancellation);
    Task<ICollection<ProductPostDTO>?> GetProductPostDTOsByCategoryId(int categoryId, int count, CancellationToken cancellation);
    Task<ICollection<ProductPostDTO>?> GetNewProductDTOs(int count, CancellationToken cancellation);
    Task<ICollection<ProductPostDTO>?> GetOnSaleProductDTOs(int count, CancellationToken cancellation);
}
