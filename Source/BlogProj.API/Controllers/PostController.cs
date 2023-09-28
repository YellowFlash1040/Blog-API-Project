using AutoMapper;
using BlogProj.Shared.Dtos.PostDtos;
using BlogProj.Shared.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogProj.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private IMapper Mapper { get; }
        private IPostService PostService { get; }

        public PostController(IMapper mapper, IPostService postService)
        {
            Mapper = mapper;
            PostService = postService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreatePost(PostCreate post)
        {
            var postId = await PostService.CreatePostAsync(post);

            return Ok(postId);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdatePost(PostUpdate post)
        {
            var result = await PostService.UpdatePostAsync(post);

            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeletePost(PostDelete post)
        {
            var result = await PostService.DeletePostAsync(post);

            return Ok(result);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await PostService.GetPostAsync(id);

            return Ok(post);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await PostService.GetAllPostsAsync();

            return Ok(posts);
        }
    }
}