namespace BlogProj.Shared.Dtos.CommentDtos
{
    public record CommentCreate(int AuthorId, int PostId, string Content);
}