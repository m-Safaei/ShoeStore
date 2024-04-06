using Microsoft.EntityFrameworkCore;
using ShoeStore.Data.AppDbContext;
using ShoeStore.Domain.Entities.Color_Size;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Data.Repositories;

public class MaterialRepository : IMaterialRepository
{
    private readonly ShoeStoreDbContext _context;
    public MaterialRepository(ShoeStoreDbContext context)
    {
        _context = context;
    }

    public async Task<Material?> GetMaterialByIdAsync(int Id)
    {
        return await _context.Materials.FirstOrDefaultAsync(p => p.Id == Id);
    }
}
