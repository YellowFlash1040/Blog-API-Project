using BlogProj.Shared.Models;

namespace BlogProj.Shared.Dtos.PostDtos
{
    public record PostUpdate(int Id, string Title, User Owner, string Content, Blog blog);
}