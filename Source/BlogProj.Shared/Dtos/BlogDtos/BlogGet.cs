namespace BlogProj.Shared.Dtos.BlogDtos
{
    public record BlogGet(int Id, string Title, int OwnerId, DateTime CreationDate);
}