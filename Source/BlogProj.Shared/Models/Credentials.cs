namespace BlogProj.Shared.Models
{
    public class Credentials : BaseEntity
    {
        [ForeignKey("UserId")]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}