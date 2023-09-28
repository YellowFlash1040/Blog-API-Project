namespace BlogProj.Shared.Dtos.ExperimentDtos
{
    public record UserCreateWithoutAuthorization(string? UserName, string? FirstName, string? LastName, int? Age, string? Email);
}