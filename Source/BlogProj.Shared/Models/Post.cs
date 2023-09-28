namespace BlogProj.Shared.Models
{
    public class Post : BaseEntity
    {
        public string Title { get; set; } = null!;

        [ForeignKey("UserId")]
        [Required]
        public int OwnerId { get; set; }
        public User Owner { get; set; } = null!;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string Content { get; set; } = null!;
        public List<Comment>? Comments { get; set; }

        public List<User>? Readers { get; set; }

        [ForeignKey("BlogId")]
        [Required]
        public int BlogId { get; set; }
        public Blog Blog { get; set; } = null!;

        public override string ToString()
        {
            return Title;
        }
    }
}