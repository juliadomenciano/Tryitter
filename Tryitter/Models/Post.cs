using System.ComponentModel.DataAnnotations;

namespace tryitter.Models
{
  public class Post
  {
    public int PostId { get; set; }
    public string? Title { get; set; }
    [MaxLength(300)]
    public string? Text { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int StudentId { get; set; }
    public virtual Student? Student { get; set; }
  }
}