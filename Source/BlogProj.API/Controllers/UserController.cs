using BlogProj.Shared.Dtos.Credentials;
using BlogProj.Shared.Dtos.ExperimentDtos;
using BlogProj.Shared.Dtos.UserDtos;
using BlogProj.Shared.Interfaces.Services;
using BlogProj.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogProj.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService UserService { get; }

        //
        private ICredentialsService CredentialsService { get; }
        //

        public UserController(IUserService userService, ICredentialsService credentialsService)
        {
            UserService = userService;
            CredentialsService = credentialsService;
        }

        //public UserController(IUserService userService)
        //{
        //    UserService = userService;
        //}

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateUser(UserCreate user)
        {
            var result = await UserService.CreateUserAsync(user);

            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateUser(UserUpdate userUpdate)
        {
            var result = await UserService.UpdateUserAsync(userUpdate);

            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var result = await UserService.DeleteUserAsync(Id);

            return Ok(result);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await UserService.GetUserAsync(id);

            return Ok(user);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await UserService.GetAllUsersAsync();

            return Ok(users);
        }

        //experiments

        [HttpPost]
        [Route("CreateUserWithCredentials")]
        public async Task<IActionResult> CreateUserWithCredentials([FromBody] UserWithCredentials userWithCredentials)
        {
            var user = userWithCredentials.User;
            var credentials = userWithCredentials.Credentials;
            var userCreate = new UserCreate(user.UserName, user.FirstName, user.LastName, user.Age, user.Email,
                AuthorizationType.User);

            var userId = await UserService.CreateUserAsync(userCreate);

            var credentialsCreate = new CredentialsCreate(userId, credentials.Login, credentials.Password);

            await CredentialsService.CreateCreadentialsAsync(credentialsCreate);

            return Ok(userId);
        }
    }
}
