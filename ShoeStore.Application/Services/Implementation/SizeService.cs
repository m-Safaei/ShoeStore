using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.AdminSide.Product;
using ShoeStore.Domain.Entities.Product;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Application.Services.Implementation;

public class SizeService : ISizeService
{
    private readonly ISizeRepository _sizeRepository;
    public SizeService(ISizeRepository sizeRepository)
    {
        _sizeRepository = sizeRepository;
    }


    public async Task<ICollection<SizeAdminSideDTO>?> GetListOfSizeDTOs(CancellationToken cancellation)
    {
        return await _sizeRepository.GetListOfSizeDTOs(cancellation);
    }


    public async Task<bool> CreateSize(SizeAdminSideDTO sizeDTO , CancellationToken cancellation)
    {
        var sizeExists = await _sizeRepository.SizeExistsWithSizeNumber(sizeDTO.SizeNumber,cancellation);
        if (sizeExists) return false;

        Size size = new() { CreateDate =  DateTime.Now, SizeNumber = sizeDTO.SizeNumber};

        _sizeRepository.AddSize(size);
        await _sizeRepository.SaveChangesAsync(cancellation);

        return true;
    }


    public async Task<SizeAdminSideDTO?> GetSizeDTOById(int sizeId,CancellationToken cancellation)
    {
        return await _sizeRepository.GetSizeAdminSideDTOById(sizeId,cancellation);
    }


    public async Task<bool> EditSize(SizeAdminSideDTO sizeDTO , CancellationToken cancellation)
    {
        var sizeExists = await _sizeRepository.AnotherSizeExistsWithSizeNumber(sizeDTO.SizeNumber,sizeDTO.Id, cancellation);
        if (sizeExists) return false;

        var size = await _sizeRepository.GetSizeByIdAsync(sizeDTO.Id, cancellation);
        if (size == null) return false;

        size.SizeNumber = sizeDTO.SizeNumber;
        _sizeRepository.UpdateSize(size);
        await _sizeRepository.SaveChangesAsync(cancellation);
        return true;
    }


    public async Task<bool> DeleteSize(SizeAdminSideDTO sizeDTO , CancellationToken cancellation)
    {
        var size = await _sizeRepository.GetSizeByIdAsync(sizeDTO.Id, cancellation);
        if (size == null) return false;

        size.IsDelete = true;
        _sizeRepository.UpdateSize(size);
        await _sizeRepository.SaveChangesAsync(cancellation);
        return true;
    }
}
