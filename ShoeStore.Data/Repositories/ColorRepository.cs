using Microsoft.EntityFrameworkCore;
using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.Entities.Color_Size;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Data.Repositories;

public class ColorRepository : IColorRepository
{
    private readonly ShoeStoreDbContext _context;
    public ColorRepository(ShoeStoreDbContext context)
    {
        _context = context;
    }

    public void AddColor(Color color)
    {
        _context.Colors.Add(color);
    }

    public async Task<Color?> GetColorByIdAsync(int Id, CancellationToken cancellation)
    {
        return await _context.Colors.FirstOrDefaultAsync(p => p.Id == Id && !p.IsDelete);
    }

    public async Task<List<Color>> GetListOfColorsAsync(CancellationToken cancellation)
    {
        return await _context.Colors.Where(p => !p.IsDelete).ToListAsync();
    }

    public async Task SaveChangesAsync(CancellationToken cancellation)
    {
        await _context.SaveChangesAsync();
    }

    public void UpdateColor(Color color)
    {
        _context.Colors.Update(color);
    }
}
