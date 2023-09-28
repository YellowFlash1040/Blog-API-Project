using BlogProj.Shared.Interfaces.Repositories;
using BlogProj.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogProj.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private DataBaseContext DbContext { get; }
        public PostRepository(DataBaseContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<int> CreatePostAsync(Post post)
        {
            await DbContext.AddAsync(post);
            await DbContext.SaveChangesAsync();

            return post.Id;
        }

        public async Task<bool> DeletePostByIdAsync(int id)
        {
            var post = await DbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);
            if (post != null)
            {
                DbContext.Posts.Remove(post);
                await DbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            var posts = await DbContext.Posts.ToListAsync();

            return posts;
        }

        public async Task<List<Post>> GetAllPostsRelatedToBlogAsync(int blogId)
        {
            var posts = await DbContext.Posts.Where(p => p.Blog.Id == blogId).ToListAsync();

            return posts;
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            var post = await DbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);

            return post;
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            if (DbContext.Posts.Any(p => p.Id == post.Id))
            {
                DbContext.Posts.Update(post);
                await DbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}