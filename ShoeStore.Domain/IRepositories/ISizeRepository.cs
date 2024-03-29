﻿using ShoeStore.Domain.Entities.Color_Size;

namespace ShoeStore.Domain.IRepositories;

public interface ISizeRepository
{
    Task<List<Size>> GetListOfSizesAsync(CancellationToken cancellation);
    Task<Size?> GetSizeByIdAsync(int Id, CancellationToken cancellation);
    void AddSize(Size size);
    void UpdateColor(Size size);
    Task SaveChangesAsync(CancellationToken cancellation);
}
