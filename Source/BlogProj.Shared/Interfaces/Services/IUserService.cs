using BlogProj.Shared.Dtos.UserDtos;

namespace BlogProj.Shared.Interfaces.Services
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(UserCreate user);
        Task<bool> UpdateUserAsync(UserUpdate user);
        Task<bool> DeleteUserAsync(int id);
        Task<UserGet> GetUserAsync(int id);
        Task<List<UserGet>> GetAllUsersAsync();
    }
}