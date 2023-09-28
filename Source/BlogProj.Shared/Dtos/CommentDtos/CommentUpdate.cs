namespace BlogProj.Shared.Dtos.CommentDtos
{
    public record CommentUpdate(int Id, int AuthorId, int PostId, string Content);
}