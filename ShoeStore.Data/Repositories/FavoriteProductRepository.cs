using Microsoft.EntityFrameworkCore;
using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.DTOs.SiteSide.FavoriteProduct;
using ShoeStore.Domain.Entities.FavoriteProduct;
using ShoeStore.Domain.Entities.Product;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Data.Repositories;
public class FavoriteProductRepository : IFavoriteProductRepository
{

    #region Ctor

    private readonly ShoeStoreDbContext _context;

    public FavoriteProductRepository(ShoeStoreDbContext context)
    {
        _context = context;
    }

    #endregion

    public async Task<List<FavoriteProductDto>> GetListOfFavoriteProduct(CancellationToken cancellation)
    {
        List<int> productIds = await _context.FavoriteProducts
                                       .Select(p => p.ProductId).ToListAsync(cancellation);

        List<FavoriteProductDto> favoriteProducts = new();

        foreach (var productId in productIds)
        {
            FavoriteProductDto? favoriteProduct = await _context.Products
                .Where(p => !p.IsDelete && p.Id == productId)
                .Select(p => new FavoriteProductDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Image = p.ProductImage,
                    Price = p.Price
                })
                .SingleOrDefaultAsync(cancellation);
            favoriteProducts.Add(favoriteProduct);
        }
        return favoriteProducts;
    }

    public async Task<bool> DoesExistFavoriteProduct(int? userId, int productId, CancellationToken cancellation)
    {
        return await _context.FavoriteProducts
            .AsNoTracking()
            .AnyAsync(p => p.UserId == userId && p.ProductId == productId, cancellation);
    }

    public async Task AddFavoriteProduct(FavoriteProduct favoriteProduct, CancellationToken cancellation)
    {
        await _context.FavoriteProducts.AddAsync(favoriteProduct, cancellation);
    }

    public async Task SaveChanges(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync(cancellation);
    }

    public async Task<FavoriteProduct?> GetFavoriteProduct(int productId, int userId, CancellationToken cancellation)
    {
        return await _context.FavoriteProducts.Where(p => p.ProductId == productId && p.UserId == userId)
                                             .SingleOrDefaultAsync(cancellation);
    }

    public void DeleteFavoriteProduct(FavoriteProduct favoriteProduct)
    {
        _context.FavoriteProducts.Remove(favoriteProduct);
    }
}

