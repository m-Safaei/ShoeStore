using ShoeStore.Domain.DTOs.SiteSide.FavoriteProduct;

namespace ShoeStore.Application.Services.Interface;
public interface IFavoriteProductService
{
    Task<bool> AddFavoriteProduct(int? userId, int productId, CancellationToken cancellation);

    Task<List<FavoriteProductDto>> GetListOfFavoriteProduct(CancellationToken cancellation);

    Task<bool> DeleteFavoriteProduct(int productId, int userId, CancellationToken cancellation);
}

