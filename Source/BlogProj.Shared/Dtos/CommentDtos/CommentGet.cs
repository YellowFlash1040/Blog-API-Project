namespace BlogProj.Shared.Dtos.CommentDtos
{
    public record CommentGet(int Id, int AuthorId, int PostId, string Content);
}