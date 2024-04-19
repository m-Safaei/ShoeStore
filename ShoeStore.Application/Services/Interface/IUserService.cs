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
    Task<bool> DeleteUser(int userId, CancellationToken cancellation);

    Task<bool> AddUserAdminSide(AddUserAdminSideDto userDto, List<int>? selectedRoles, CancellationToken cancellation);

    Task<UserProfileDto?> GetUserProfileById(int id);

    Task<EditProfileSiteSideDto?> FillEditProfileSiteSideDto(int userId, CancellationToken cancellation);

    Task<bool> EditProfileSiteSide(EditProfileSiteSideDto model, CancellationToken cancellation);
}

