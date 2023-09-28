using BlogProj.Shared.Models;

namespace BlogProj.Shared.Interfaces.Repositories
{
    public interface ICredentialsRepository
    {
        Task<int> CreateCredentialsAsync(Credentials credentials);
        Task<bool> DeleteCredentialsAsync(int Id);
        Task<bool> UpdateCreadentialsAsync(Credentials credentials);
        Task<Credentials> GetCredentialsAsync(int Id);
        Task<List<Credentials>> GetAllCredentialsAsync();
    }
}