using ShoeStore.Domain.DTOs.SiteSide.Main;

namespace ShoeStore.Application.Services.Interface;

public interface IHomeService
{
    Task<MainIndexDTO> FillMainIndexDTO(CancellationToken cancellation);
}
