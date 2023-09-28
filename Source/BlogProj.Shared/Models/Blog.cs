namespace BlogProj.Shared.Models
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; } = null!;

        [ForeignKey("OwnerId")]
        [Required]
        public int OwnerId { get; set; }
        public User Owner { get; set; } = null!;
        public List<User>? Users { get; set; }
        public List<Post>? Posts { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return Title;
        }
    }
}