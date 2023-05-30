using System.ComponentModel.DataAnnotations;

namespace tryitter.Models
{
  public class Student
  {
    public int StudentId { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    public string? Status { get; set; }
    public int ModuleId { get; set; }
    public virtual Module? Module { get; set; }
    public virtual ICollection<Post>? Posts { get; set; }
  }
}