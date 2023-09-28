using BlogProj.Shared.Dtos.BlogDtos;

namespace BlogProj.Shared.Interfaces.Services
{
    public interface IBlogService
    {
        Task<int> CreateBlogAsync(BlogCreate blog);
        Task<bool> UpdateBlogAsync(BlogUpdate blog);
        Task<bool> DeleteBlogAsync(BlogDelete blog);
        Task<BlogGet> GetBlogAsync(int id);
        Task<List<BlogGet>> GetAllBlogsAsync();
    }
}