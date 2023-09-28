using BlogProj.Shared.Interfaces.Repositories;
using BlogProj.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogProj.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataBaseContext DbContext { get; }
        public UserRepository(DataBaseContext dBContext)
        {
            DbContext = dBContext;
        }

        public async Task<int> CreateUserAsync(User user)
        {
            await DbContext.Users.AddAsync(user);
            await DbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            var user = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                DbContext.Remove(user);
                await DbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await DbContext.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            if (await DbContext.Users.AnyAsync(u => u.Id == user.Id))
            {
                DbContext.Users.Update(user);
                await DbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}