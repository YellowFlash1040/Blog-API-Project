using BlogProj.Shared.Interfaces.Repositories;
using BlogProj.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogProj.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private DataBaseContext DbContext { get; }
        public CommentRepository(DataBaseContext dbContext)
        {
            DbContext = dbContext;
        }


        public async Task<int> CreateCommentAsync(Comment comment)
        {
            await DbContext.Comments.AddAsync(comment);
            await DbContext.SaveChangesAsync();

            return comment.Id;
        }

        public async Task<bool> DeleteCommentByIdAsync(int id)
        {
            var comment = await DbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (comment != null)
            {
                DbContext.Remove(comment);
                await DbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            var comments = await DbContext.Comments.ToListAsync();
            return comments;
        }

        public async Task<Comment> GetCommentByIdAsync(int id)
        {
            var comment = await DbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);
            return comment;
        }

        public async Task<bool> UpdateCommentAsync(Comment comment)
        {
            if (DbContext.Comments.Any(c => c.Id == comment.Id))
            {
                DbContext.Comments.Update(comment);
                await DbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}