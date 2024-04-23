using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.SiteSide.FavoriteProduct;
using ShoeStore.Domain.Entities.FavoriteProduct;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Application.Services.Implementation;
public class FavoriteProductService : IFavoriteProductService
{

    #region Ctor

    private readonly IFavoriteProductRepository _favoriteProductRepository;

    public FavoriteProductService(IFavoriteProductRepository favoriteProductRepository)
    {
        _favoriteProductRepository = favoriteProductRepository;
    }

    #endregion

    public async Task<bool> AddFavoriteProduct(int? userId, int productId, CancellationToken cancellation)
    {
        //Check if exist
        if (await _favoriteProductRepository.DoesExistFavoriteProduct(userId, productId, cancellation))
        {
            return false;
        }

        FavoriteProduct favoriteProduct = new()
        {
            ProductId = productId,
            UserId = userId,
        };

        await _favoriteProductRepository.AddFavoriteProduct(favoriteProduct, cancellation);
        await _favoriteProductRepository.SaveChanges(cancellation);
        return true;
    }

    public async Task<List<FavoriteProductDto>> GetListOfFavoriteProduct(CancellationToken cancellation)
    {
        return await _favoriteProductRepository.GetListOfFavoriteProduct(cancellation);
    }

    public async Task<bool> DeleteFavoriteProduct(int productId, int userId, CancellationToken cancellation)
    {
        var favoriteProduct = await _favoriteProductRepository.GetFavoriteProduct(productId, userId, cancellation);
        if (favoriteProduct == null) return false;

        _favoriteProductRepository.DeleteFavoriteProduct(favoriteProduct);
        await _favoriteProductRepository.SaveChanges(cancellation);

        return true;
    }
}
