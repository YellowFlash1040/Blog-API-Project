using BlogProj.Shared.Dtos.CommentDtos;

namespace BlogProj.Shared.Interfaces.Services
{
    public interface ICommentService
    {
        Task<int> CreateCommentAsync(CommentCreate commentCreate);
        Task<bool> DeleteCommentAsync(CommentDelete commentDelete);
        Task<bool> UpdateCommentAsync(CommentUpdate commentUpdate);
        Task<CommentGet> GetCommentAsync(int Id);
        Task<List<CommentGet>> GetAllCommentsAsync();
    }
}