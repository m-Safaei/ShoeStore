using ShoeStore.Domain.DTOs.AdminSide.Product;
using ShoeStore.Domain.DTOs.SiteSide.Product;
using ShoeStore.Domain.Entities.Product;

namespace ShoeStore.Domain.IRepositories;

public interface ISizeRepository
{
    Task<List<Size>> GetListOfSizesAsync(CancellationToken cancellation);
    Task<Size?> GetSizeByIdAsync(int Id, CancellationToken cancellation);
    void AddSize(Size size);
    void UpdateSize(Size size);
    Task SaveChangesAsync(CancellationToken cancellation);
    Task<ICollection<SizeDTO>?> GetSizeDTOsByProductId(int productId, CancellationToken cancellation);
    Task<ICollection<SizeAdminSideDTO>?> GetAvailableSizeDTOs(int productId, CancellationToken cancellation);
}
