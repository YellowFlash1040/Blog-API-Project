namespace BlogProj.Shared.Dtos.ExperimentDtos
{
    public class UserWithCredentials
    {
        public UserCreateWithoutAuthorization User { get; set; }
        public CredentialsWithoutUserId Credentials { get; set; }
    }
}