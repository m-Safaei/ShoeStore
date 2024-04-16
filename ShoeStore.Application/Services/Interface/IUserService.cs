using ShoeStore.Domain.DTOs.AdminSide.User;
using ShoeStore.Domain.DTOs.SiteSide.Account;
using ShoeStore.Domain.Entities.User;

namespace ShoeStore.Application.Services.Interface;

public interface IUserService
{
    Task<bool> DoesExistUserByMobile(string mobile, CancellationToken cancellation);

    User FillUserEntity(UserRegisterDto userDto);

    Task AddUserAsync(User user, CancellationToken cancellation);

    Task<bool> RegisterUser(UserRegisterDto userDto, CancellationToken cancellation);

    Task<UserDto?> GetUserByMobileAsync(string mobile, CancellationToken cancellation);

    Task<List<ListOfUsersDto>> ListOfUsers(CancellationToken cancellation);

    Task<EditUserAdminSideDto?> FillEditUserAdminSideDto(int userId, CancellationToken cancellation);

    Task<bool> EditUserAdminSide(EditUserAdminSideDto model, List<int>? selectedRoles, CancellationToken cancellation);
}

