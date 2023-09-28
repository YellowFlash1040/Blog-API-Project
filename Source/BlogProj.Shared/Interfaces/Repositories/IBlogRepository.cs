using BlogProj.Shared.Models;

namespace BlogProj.Shared.Interfaces.Repositories
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogsAsync();
        Task<Blog> GetBlogByIdAsync(int id);
        Task<int> CreateBlogAsync(Blog blog);
        Task<bool> DeleteBlogByIdAsync(int id);
        Task<bool> UpdateBlogAsync(Blog blog);
    }
}