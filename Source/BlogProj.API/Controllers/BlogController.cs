using BlogProj.Shared.Dtos.BlogDtos;
using BlogProj.Shared.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogProj.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private IBlogService BlogService { get; }

        public BlogController(IBlogService blogService)
        {
            BlogService = blogService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateBlog(BlogCreate blog)
        {
            var blogId = await BlogService.CreateBlogAsync(blog);
            
            return Ok(blogId);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateBlog(BlogUpdate blog)
        {
            var result = await BlogService.UpdateBlogAsync(blog); 
            
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteBlog(BlogDelete blog)
        {
            var result = await BlogService.DeleteBlogAsync(blog);

            return Ok(result);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var blog = await BlogService.GetBlogAsync(id);

            return Ok(blog);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogs = await BlogService.GetAllBlogsAsync();

            return Ok(blogs);
        }
    }
}
