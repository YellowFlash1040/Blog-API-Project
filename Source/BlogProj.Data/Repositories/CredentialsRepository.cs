using BlogProj.Shared.Interfaces.Repositories;
using BlogProj.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogProj.Data.Repositories
{
    public class CredentialsRepository : ICredentialsRepository
    {
        public DataBaseContext DataBaseContext { get; }

        public CredentialsRepository(DataBaseContext dataBaseContext)
        {
            DataBaseContext = dataBaseContext;
        }


        public async Task<int> CreateCredentialsAsync(Credentials credentials)
        {
            await DataBaseContext.Credentials.AddAsync(credentials);
            await DataBaseContext.SaveChangesAsync();

            return credentials.Id;
        }

        public async Task<bool> DeleteCredentialsAsync(int Id)
        {
            var credentials = await DataBaseContext.Credentials.FirstOrDefaultAsync(c => c.Id == Id);
            if (credentials != null)
            {
                DataBaseContext.Credentials.Remove(credentials);
                await DataBaseContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<List<Credentials>> GetAllCredentialsAsync()
        {
            var allCredentials = await DataBaseContext.Credentials.ToListAsync();

            return allCredentials;
        }

        public async Task<Credentials> GetCredentialsAsync(int Id)
        {
            var credentials = await DataBaseContext.Credentials.FirstOrDefaultAsync(c => c.Id == Id);

            return credentials;
        }

        public async Task<bool> UpdateCreadentialsAsync(Credentials credentials)
        {
            if (await DataBaseContext.Credentials.AnyAsync(c => c.Id == credentials.Id))
            {
                DataBaseContext.Credentials.Update(credentials);
                await DataBaseContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}