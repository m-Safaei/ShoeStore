using ShoeStore.Domain.DTOs.AdminSide.Product;

namespace ShoeStore.Application.Services.Interface;

public interface ISizeService
{
    Task<ICollection<SizeAdminSideDTO>?> GetListOfSizeDTOs(CancellationToken cancellation);
    Task<bool> CreateSize(SizeAdminSideDTO sizeDTO, CancellationToken cancellation);
    Task<SizeAdminSideDTO?> GetSizeDTOById(int sizeId, CancellationToken cancellation);
    Task<bool> EditSize(SizeAdminSideDTO sizeDTO, CancellationToken cancellation);
    Task<bool> DeleteSize(SizeAdminSideDTO sizeDTO, CancellationToken cancellation);
}
