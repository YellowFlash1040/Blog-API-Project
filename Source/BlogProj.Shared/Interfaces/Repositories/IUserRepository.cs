using BlogProj.Shared.Models;

namespace BlogProj.Shared.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<int> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync();
        Task<bool> DeleteUserByIdAsync(int id);
        Task<bool> UpdateUserAsync(User user);
    }
}