using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.SiteSide.Main;

namespace ShoeStore.Application.Services.Implementation;

public class HomeService : IHomeService
{
    

    public async Task<MainIndexDTO> FillMainIndexDTO(CancellationToken cancellation)
    {
        return new MainIndexDTO()
        {

        };
    }
}
