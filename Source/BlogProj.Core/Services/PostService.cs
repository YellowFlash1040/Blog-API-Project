using AutoMapper;
using BlogProj.Shared.Dtos.PostDtos;
using BlogProj.Shared.Interfaces.Repositories;
using BlogProj.Shared.Interfaces.Services;
using BlogProj.Shared.Models;

namespace BlogProj.Core.Services
{
    public class PostService : IPostService
    {
        private IMapper Mapper { get; }
        private IPostRepository PostRepository { get; }

        public PostService(IMapper mapper, IPostRepository postRepository)
        {
            Mapper = mapper;
            PostRepository = postRepository;
        }


        public async Task<int> CreatePostAsync(PostCreate postCreate)
        {
            var post = Mapper.Map<Post>(postCreate);
            var postId = await PostRepository.CreatePostAsync(post);

            return postId;
        }

        public async Task<bool> DeletePostAsync(PostDelete post)
        {
            var result = await PostRepository.DeletePostByIdAsync(post.Id);

            return result;
        }

        public async Task<List<PostGet>> GetAllPostsAsync()
        {
            var posts = await PostRepository.GetAllPostsAsync();
            var postGet_List = Mapper.Map<List<PostGet>>(posts);

            return postGet_List;
        }

        public async Task<PostGet> GetPostAsync(int Id)
        {
            var post = await PostRepository.GetPostByIdAsync(Id);
            var postGet = Mapper.Map<PostGet>(post);

            return postGet;
        }

        public async Task<bool> UpdatePostAsync(PostUpdate postUpdate)
        {
            var post = Mapper.Map<Post>(postUpdate);
            var result = await PostRepository.UpdatePostAsync(post);

            return result;
        }
    }
}