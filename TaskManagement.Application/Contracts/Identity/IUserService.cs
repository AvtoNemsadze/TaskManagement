using TaskManagement.Application.Models.Identity;

namespace TaskManagement.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<UserResponseModel> GetUser(int id);
        Task<List<UserResponseModel>> GetAllUsers();
        Task<List<UserResponseModel>> GetAdministrators();
        Task<bool> DeleteUser(int id);
        Task<bool> UserExistAsync(int userId);
    }
}
