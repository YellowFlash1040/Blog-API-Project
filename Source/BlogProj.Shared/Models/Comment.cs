namespace BlogProj.Shared.Models
{
    public class Comment : BaseEntity
    {
        [ForeignKey("UserId")]
        [Required]
        public  int AuthorId { get; set; }
        public User Author { get; set; } = null!;

        [ForeignKey("PostId")]
        [Required]
        public int PostId { get; set; }
        public Post Post { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return Content;
        }
    }
}