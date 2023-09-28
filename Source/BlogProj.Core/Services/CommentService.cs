using AutoMapper;
using BlogProj.Shared.Dtos.CommentDtos;
using BlogProj.Shared.Interfaces.Repositories;
using BlogProj.Shared.Interfaces.Services;
using BlogProj.Shared.Models;

namespace BlogProj.Core.Services
{
    public class CommentService : ICommentService
    {
        private IMapper Mapper { get; }
        private ICommentRepository CommentRepository { get; }

        public CommentService(IMapper mapper, ICommentRepository commentRepository)
        {
            Mapper = mapper;
            CommentRepository = commentRepository;
        }


        public async Task<int> CreateCommentAsync(CommentCreate commentCreate)
        {
            var comment = Mapper.Map<Comment>(commentCreate);
            var commentId = await CommentRepository.CreateCommentAsync(comment);

            return commentId;
        }

        public async Task<bool> DeleteCommentAsync(CommentDelete comment)
        {
            var result = await CommentRepository.DeleteCommentByIdAsync(comment.Id);

            return result;
        }

        public async Task<List<CommentGet>> GetAllCommentsAsync()
        {
            var comments = await CommentRepository.GetAllCommentsAsync();
            var commentGet_List = Mapper.Map<List<CommentGet>>(comments);

            return commentGet_List;
        }

        public async Task<CommentGet> GetCommentAsync(int Id)
        {
            var comment = await CommentRepository.GetCommentByIdAsync(Id);
            var commentGet = Mapper.Map<CommentGet>(comment);

            return commentGet;
        }

        public async Task<bool> UpdateCommentAsync(CommentUpdate commentUpdate)
        {
            var comment = Mapper.Map<Comment>(commentUpdate);
            var result = await CommentRepository.UpdateCommentAsync(comment);

            return result;
        }
    }
}