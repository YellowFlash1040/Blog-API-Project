using BlogProj.Shared.Dtos.Credentials;
using BlogProj.Shared.Dtos.CredentialsDtos;
using BlogProj.Shared.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogProj.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CredentialsController : ControllerBase
    {
        private ICredentialsService CredentialsService { get; }

        public CredentialsController(ICredentialsService credentialsService)
        {
            CredentialsService = credentialsService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCredentials(CredentialsCreate credentials)
        {
            var credentialsId = await CredentialsService.CreateCreadentialsAsync(credentials);

            return Ok(credentialsId);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateCredentials(CredentialsUpdate credentials)
        {
            var result = await CredentialsService.UpdateCredentialsAsync(credentials);

            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteCredentials(CredentialsDelete credentials)
        {
            var result = await CredentialsService.DeleteCredentialsAsync(credentials);

            return Ok(result);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetCredentials(int id)
        {
            var credentials = await CredentialsService.GetCredentialsAsync(id);

            return Ok(credentials);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAllCredentials()
        {
            var allCredentials = await CredentialsService.GetAllCredentialsAsync();

            return Ok(allCredentials);
        }
    }
}