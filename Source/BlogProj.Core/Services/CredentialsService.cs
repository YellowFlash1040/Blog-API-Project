using AutoMapper;
using BlogProj.Shared.Dtos.Credentials;
using BlogProj.Shared.Dtos.CredentialsDtos;
using BlogProj.Shared.Interfaces.Repositories;
using BlogProj.Shared.Interfaces.Services;
using BlogProj.Shared.Models;

namespace BlogProj.Core.Services
{
    public class CredentialsService : ICredentialsService
    {
        private IMapper Mapper { get; }
        private ICredentialsRepository CredentialsRepository { get; }

        public CredentialsService(IMapper mapper, ICredentialsRepository credentialsRepository)
        {
            Mapper = mapper;
            CredentialsRepository = credentialsRepository;
        }


        public async Task<int> CreateCreadentialsAsync(CredentialsCreate credentialsCreate)
        {
            var credentials = Mapper.Map<Credentials>(credentialsCreate);
            var credentialsId = await CredentialsRepository.CreateCredentialsAsync(credentials);

            return credentialsId;
        }

        public async Task<bool> DeleteCredentialsAsync(CredentialsDelete credentials)
        {
            var result = await CredentialsRepository.DeleteCredentialsAsync(credentials.Id);

            return result;
        }

        public async Task<List<CredentialsGet>> GetAllCredentialsAsync()
        {
            var credentials = await CredentialsRepository.GetAllCredentialsAsync();
            var credentialsGet_List = Mapper.Map<List<CredentialsGet>>(credentials);

            return credentialsGet_List;
        }

        public async Task<CredentialsGet> GetCredentialsAsync(int Id)
        {
            var credentials = await CredentialsRepository.GetCredentialsAsync(Id);
            var credentialsGet = Mapper.Map<CredentialsGet>(credentials);

            return credentialsGet;
        }

        public async Task<bool> UpdateCredentialsAsync(CredentialsUpdate credentialsUpdate)
        {
            var credentials = Mapper.Map<Credentials>(credentialsUpdate);
            var result = await CredentialsRepository.UpdateCreadentialsAsync(credentials);

            return result;
        }
    }
}