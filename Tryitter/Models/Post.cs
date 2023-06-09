using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tryitter.Models
{
  public class Post
  {
    public int PostId { get; set; }
    [Required]
    public string? Title { get; set; }
    
    [MaxLength(300)]
    [Required]
    public string? Text { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("StudentId")]
    public int StudentId { get; set; }
    public virtual Student? Student { get; set; }
  }
}