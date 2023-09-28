using BlogProj.Shared.Interfaces.Repositories;
using BlogProj.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogProj.Data.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private DataBaseContext DbContext { get; }
        public BlogRepository(DataBaseContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<bool> DeleteBlogByIdAsync(int id)
        {
            var blog = await DbContext.Blogs.FirstOrDefaultAsync(b => b.Id == id);
            if (blog != null)
            {
                DbContext.Blogs.Remove(blog);
                await DbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            var blogs = await DbContext.Blogs.ToListAsync();
            return blogs;
        }

        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            var blog = await DbContext.Blogs.FirstOrDefaultAsync(b => b.Id == id);
                
            return blog;
        }

        public async Task<bool> UpdateBlogAsync(Blog blog)
        {
            if(DbContext.Blogs.Any(b => b.Id == blog.Id)) 
            {
                DbContext.Blogs.Update(blog);
                await DbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<int> CreateBlogAsync(Blog blog)
        {
            await DbContext.AddAsync(blog);
            await DbContext.SaveChangesAsync();

            return blog.Id;
        }
    }
}