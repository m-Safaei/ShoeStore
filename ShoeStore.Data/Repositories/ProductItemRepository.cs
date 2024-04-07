﻿using Microsoft.EntityFrameworkCore;
using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.Entities.Product;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Data.Repositories;

public class ProductItemRepository : IProductItemRepository
{
    private readonly ShoeStoreDbContext _context;
    public ProductItemRepository(ShoeStoreDbContext context)
    {
        _context = context;
    }

    public void AddProductItem(ProductItem productItem)
    {
        _context.ProductItems.Add(productItem);
    }

    public async Task<List<ProductItem>> GetListOfProductItemsAsync(CancellationToken cancellation)
    {
        return await _context.ProductItems.Where(p => !p.IsDelete).ToListAsync();
    }

    public async Task<ProductItem?> GetProductItemByIdAsync(int Id, CancellationToken cancellation)
    {
        return await _context.ProductItems.FirstOrDefaultAsync(p => p.Id == Id && !p.IsDelete);
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync();
    }

    public void UpdateProductItem(ProductItem productItem)
    {
        _context.ProductItems.Update(productItem);
    }
}
