namespace BlogProj.Shared.Models
{
    public class User : BaseEntity
    {
        public string? UserName { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public AuthorizationType AuthorizationType { get; set; }

        public List<Post>? Posts { get; set; }

        public Credentials? Credentials { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"Id: {Id}\n" +
                $"UserName: {UserName}\n" +
                $"FirstName: {FirstName}\n" +
                $"LastName: {LastName}\n" +
                $"Age: {Age}\n" +
                $"Email: {Email}\n" +
                $"AuthorizationType{AuthorizationType.ToString()}";
        }
    }
}