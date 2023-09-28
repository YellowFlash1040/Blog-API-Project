using BlogProj.Shared.Models;

namespace BlogProj.Shared.Interfaces.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment> GetCommentByIdAsync(int id);
        Task<List<Comment>> GetAllCommentsAsync();
        Task<int> CreateCommentAsync(Comment comment);
        Task<bool> DeleteCommentByIdAsync(int id);
        Task<bool> UpdateCommentAsync(Comment comment);
    }
}