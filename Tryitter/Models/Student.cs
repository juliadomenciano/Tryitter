using System.ComponentModel.DataAnnotations;

namespace tryitter.Models
{
  public class Student
  {
    public int StudentId { get; set; }
    [Required]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
    [MaxLength(50)]
    public string? Name { get; set; }
    [Required]

    public string? Email { get; set; }
    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
    public string? Password { get; set; }
    public string? Status { get; set; }
    public int ModuleId { get; set; }
    public virtual Module? Module { get; set; }
    public virtual ICollection<Post>? Posts { get; set; }
  }
}