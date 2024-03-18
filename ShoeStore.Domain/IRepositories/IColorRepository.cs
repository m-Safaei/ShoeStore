using ShoeStore.Domain.Entities.Color_Size;

namespace ShoeStore.Domain.IRepositories;

public interface IColorRepository
{
    Task<List<Color>> GetListOfColorsAsync(CancellationToken cancellation);
    Task<Color?> GetColorByIdAsync(int Id, CancellationToken cancellation);
    void AddColor(Color color);
    void UpdateColor(Color color);
    Task SaveChangesAsync(CancellationToken cancellation);
}
