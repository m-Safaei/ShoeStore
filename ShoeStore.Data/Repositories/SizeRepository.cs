using Microsoft.EntityFrameworkCore;
using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.DTOs.AdminSide.Product;
using ShoeStore.Domain.DTOs.SiteSide.Product;
using ShoeStore.Domain.Entities.Product;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Data.Repositories;

public class SizeRepository : ISizeRepository
{
    private readonly ShoeStoreDbContext _context;
    public SizeRepository(ShoeStoreDbContext context)
    {
        _context = context;
    }

    public void AddSize(Size size)
    {
        _context.Sizes.Add(size);
    }

    public async Task<List<Size>?> GetListOfSizesAsync(CancellationToken cancellation)
    {
        return await _context.Sizes.Where(p => !p.IsDelete).ToListAsync(cancellation);
    }

    public async Task<Size?> GetSizeByIdAsync(int Id, CancellationToken cancellation)
    {
        return await _context.Sizes.FirstOrDefaultAsync(p=> p.Id == Id && !p.IsDelete , cancellation);
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync(cancellation);
    }

    public void UpdateSize(Size size)
    {
        _context.Sizes.Update(size);
    }

    public async Task<ICollection<SizeDTO>?> GetSizeDTOsByProductId(int productId , CancellationToken cancellation)
    {
        return await _context.ProductItems.Where(p=> p.ProductId == productId && !p.IsDelete && p.Count>1)
                .Select(p=> new SizeDTO() { SizeNumber = p.Size.SizeNumber,ProductItemId=p.Id }).ToListAsync(cancellation);
    }


    public async Task<ICollection<SizeAdminSideDTO>?> GetAvailableSizeDTOs(int productId ,CancellationToken cancellation)
    {
        var selectedSizes = await _context.ProductItems.Where(p=> p.ProductId == productId && !p.IsDelete).Select(p=> p.SizeId).ToListAsync(cancellation);

        return await _context.Sizes.Where(p => !p.IsDelete && !selectedSizes.Contains(p.Id))
            .Select(p => new SizeAdminSideDTO() { Id = p.Id, SizeNumber = p.SizeNumber }).ToListAsync(cancellation);
    }


    public async Task<ICollection<SizeAdminSideDTO>?> GetListOfSizeDTOs(CancellationToken cancellation)
    {
        return await _context.Sizes.Where(p => !p.IsDelete)
            .Select(p=> new SizeAdminSideDTO() { Id=p.Id,SizeNumber=p.SizeNumber}).ToListAsync(cancellation);
    }

    public async Task<bool> SizeExistsWithSizeNumber(float sizeNumber, CancellationToken cancellation)
    {
        return await _context.Sizes.AnyAsync(p => p.SizeNumber == sizeNumber && !p.IsDelete, cancellation);
    }


    public async Task<bool> AnotherSizeExistsWithSizeNumber(float sizeNumber,int sizeId, CancellationToken cancellation)
    {
        return await _context.Sizes.AnyAsync(p => p.SizeNumber == sizeNumber && !p.IsDelete && p.Id != sizeId, cancellation);
    }


    public async Task<SizeAdminSideDTO?> GetSizeAdminSideDTOById(int sizeId,CancellationToken cancellation)
    {
        return await _context.Sizes.Where(p => p.Id == sizeId && !p.IsDelete)
            .Select(p => new SizeAdminSideDTO() { Id = p.Id, SizeNumber = p.SizeNumber })
            .SingleOrDefaultAsync(cancellation);
    }
}
