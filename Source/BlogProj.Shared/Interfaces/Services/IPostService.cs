using BlogProj.Shared.Dtos.PostDtos;

namespace BlogProj.Shared.Interfaces.Services
{
    public interface IPostService
    {
        Task<int> CreatePostAsync(PostCreate postCreate);
        Task<bool> UpdatePostAsync(PostUpdate postUpdate);
        Task<bool> DeletePostAsync(PostDelete postDelete);
        Task<PostGet> GetPostAsync(int Id);
        Task<List<PostGet>> GetAllPostsAsync();
    }
}