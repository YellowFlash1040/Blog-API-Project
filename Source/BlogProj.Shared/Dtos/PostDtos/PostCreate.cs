namespace BlogProj.Shared.Dtos.PostDtos
{
    public record PostCreate(string Title, int OwnerId, string Content, int BlogId);
}