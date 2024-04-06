using ShoeStore.Domain.Entities.Color_Size;

namespace ShoeStore.Domain.IRepositories;

public interface IMaterialRepository
{
    Task<Material?> GetMaterialByIdAsync(int Id);
}
