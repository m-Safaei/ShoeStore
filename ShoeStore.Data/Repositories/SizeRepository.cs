using Microsoft.EntityFrameworkCore;
using ShoeStore.Data.AppDbContext;
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

    public async Task<List<Size>> GetListOfSizesAsync(CancellationToken cancellation)
    {
        return await _context.Sizes.Where(p => !p.IsDelete).ToListAsync();
    }

    public async Task<Size?> GetSizeByIdAsync(int Id, CancellationToken cancellation)
    {
        return await _context.Sizes.FirstOrDefaultAsync(p=> p.Id == Id && !p.IsDelete);
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync();
    }

    public void UpdateColor(Size size)
    {
        _context.Sizes.Update(size);
    }
}
