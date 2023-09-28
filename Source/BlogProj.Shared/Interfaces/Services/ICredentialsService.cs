using BlogProj.Shared.Dtos.Credentials;
using BlogProj.Shared.Dtos.CredentialsDtos;

namespace BlogProj.Shared.Interfaces.Services
{
    public interface ICredentialsService
    {
        Task<int> CreateCreadentialsAsync(CredentialsCreate credentialsCreate);
        Task<bool> UpdateCredentialsAsync(CredentialsUpdate credentialsUpdate);
        Task<bool> DeleteCredentialsAsync(CredentialsDelete credentialsDelete);
        Task<CredentialsGet> GetCredentialsAsync(int Id);
        Task<List<CredentialsGet>> GetAllCredentialsAsync();
    }
}