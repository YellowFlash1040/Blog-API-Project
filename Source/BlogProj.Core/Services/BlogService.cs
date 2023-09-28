using AutoMapper;
using BlogProj.Shared.Dtos.BlogDtos;
using BlogProj.Shared.Interfaces.Repositories;
using BlogProj.Shared.Interfaces.Services;
using BlogProj.Shared.Models;

namespace BlogProj.Core.Services
{
    public class BlogService : IBlogService
    {
        private IMapper Mapper { get; }
        private IBlogRepository BlogRepository { get; }

        public BlogService(IMapper mapper, IBlogRepository blogRepository)
        {
            Mapper = mapper;
            BlogRepository = blogRepository;
        }

        public async Task<int> CreateBlogAsync(BlogCreate blogCreate)
        {
            var blog_Entity = Mapper.Map<Blog>(blogCreate);
            var blogId = await BlogRepository.CreateBlogAsync(blog_Entity);

            return blogId;
        }

        public async Task<bool> DeleteBlogAsync(BlogDelete blog)
        {
            var result = await BlogRepository.DeleteBlogByIdAsync(blog.Id);

            return result;
        }

        public async Task<List<BlogGet>> GetAllBlogsAsync()
        {
            var blogs = await BlogRepository.GetAllBlogsAsync();
            var blogGet_List = Mapper.Map<List<BlogGet>>(blogs);

            return blogGet_List;
        }

        public async Task<BlogGet> GetBlogAsync(int id)
        {
            var blog = await BlogRepository.GetBlogByIdAsync(id);
            var blogGet = Mapper.Map<BlogGet>(blog);

            return blogGet;
        }

        public async Task<bool> UpdateBlogAsync(BlogUpdate blogUpdate)
        {
            var blog = Mapper.Map<Blog>(blogUpdate);
            var result = await BlogRepository.UpdateBlogAsync(blog);

            return result;
        }
    }
}