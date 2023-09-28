using BlogProj.Shared.Models;

namespace BlogProj.Shared.Dtos.UserDtos
{
    public record UserUpdate(int Id, string? UserName, string? FirstName, string? LastName, int? Age, string? Email,
        AuthorizationType AuthorizationType);
}