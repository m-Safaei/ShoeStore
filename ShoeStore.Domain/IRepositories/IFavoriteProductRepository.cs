using ShoeStore.Domain.DTOs.SiteSide.FavoriteProduct;
using ShoeStore.Domain.Entities.FavoriteProduct;

namespace ShoeStore.Domain.IRepositories;
public interface IFavoriteProductRepository
{
    Task AddFavoriteProduct(FavoriteProduct favoriteProduct, CancellationToken cancellation);

    Task<bool> DoesExistFavoriteProduct(int? productId, int userId, CancellationToken cancellation);

    Task SaveChanges(CancellationToken cancellation);

    Task<List<FavoriteProductDto>> GetListOfFavoriteProduct(CancellationToken cancellation);

    Task<FavoriteProduct?> GetFavoriteProduct(int productId,int userId, CancellationToken cancellation);

    void DeleteFavoriteProduct(FavoriteProduct favoriteProduct);
}

