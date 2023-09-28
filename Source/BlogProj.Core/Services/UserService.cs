using AutoMapper;
using BlogProj.Shared.Dtos.UserDtos;
using BlogProj.Shared.Interfaces.Repositories;
using BlogProj.Shared.Interfaces.Services;
using BlogProj.Shared.Models;

namespace BlogProj.Core.Services
{
    public class UserService : IUserService
    {
        private IMapper Mapper { get; }
        private IUserRepository UserRepository { get; }

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            Mapper = mapper;
            UserRepository = userRepository;
        }


        public async Task<int> CreateUserAsync(UserCreate userCreate)
        {
            var user = Mapper.Map<User>(userCreate);
            var userId = await UserRepository.CreateUserAsync(user);

            return userId;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var result = await UserRepository.DeleteUserByIdAsync(id);

            return result;
        }

        public async Task<List<UserGet>> GetAllUsersAsync()
        {
            var users = await UserRepository.GetAllUsersAsync();
            var userGet_List = Mapper.Map<List<UserGet>>(users);

            return userGet_List;
        }

        public async Task<UserGet> GetUserAsync(int id)
        {
            var user = await UserRepository.GetUserByIdAsync(id);
            var userGet = Mapper.Map<UserGet>(user);

            return userGet;
        }

        public async Task<bool> UpdateUserAsync(UserUpdate userUpdate)
        {
            var user = Mapper.Map<User>(userUpdate);
            var result = await UserRepository.UpdateUserAsync(user);

            return result;
        }
    }
}