namespace tryitter.Models
{
  public class PostResponse
  {
    public int PostId { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int StudentId { get; set; }
  }
}