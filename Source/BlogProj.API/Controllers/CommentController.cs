using BlogProj.Core.Services;
using BlogProj.Shared.Dtos.CommentDtos;
using BlogProj.Shared.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogProj.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private ICommentService CommentService { get; }

        //
        private IUserService UserService { get; }
        //

        public CommentController(ICommentService commentService, IUserService userService)
        {
            CommentService = commentService;
            UserService = userService;
        }

        //public CommentController(ICommentService commentService)
        //{
        //    CommentService = commentService;
        //}

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateComment(CommentCreate comment)
        {
            var commentId = await CommentService.CreateCommentAsync(comment);

            //experiments

            var user = await UserService.GetUserAsync(comment.AuthorId);

            // Проверьте, является ли адрес электронной почты действительным.
            if (!IsEmailValid(user.Email))
            {
                return BadRequest("Недействительный адрес электронной почты. Комментарий не может быть создан.");
            }

            //

            return Ok(commentId);
        }

        // Метод для проверки действительности адреса электронной почты.
        private bool IsEmailValid(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateComment(CommentUpdate comment)
        {
            var result = await CommentService.UpdateCommentAsync(comment);

            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteComment(CommentDelete comment)
        {
            var result = await CommentService.DeleteCommentAsync(comment);

            return Ok(result);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var comment = await CommentService.GetCommentAsync(id);

            return Ok(comment);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await CommentService.GetAllCommentsAsync();

            return Ok(comments);
        }
    }
}
