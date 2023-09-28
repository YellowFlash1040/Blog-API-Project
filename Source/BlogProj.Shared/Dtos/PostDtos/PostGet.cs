namespace BlogProj.Shared.Dtos.PostDtos
{
    public record PostGet(int Id, string Title, string Content, DateTime CreationDate, int OwnerId, int BlogId);
}