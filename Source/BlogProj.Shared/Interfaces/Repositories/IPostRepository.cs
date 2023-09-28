using BlogProj.Shared.Models;

namespace BlogProj.Shared.Interfaces.Repositories
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAllPostsAsync();

        Task<Post> GetPostByIdAsync(int id);
        Task<int> CreatePostAsync(Post post);
        Task<bool> DeletePostByIdAsync(int id);
        Task<bool> UpdatePostAsync(Post post);
        Task<List<Post>> GetAllPostsRelatedToBlogAsync(int blogId);
    }
}