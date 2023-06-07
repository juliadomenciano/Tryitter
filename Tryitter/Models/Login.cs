using System.ComponentModel.DataAnnotations;

namespace tryitter.Models
{
  public class Login
  {
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
    public string? Password { get; set; }

    public object ValidateProperty(string v)
    {
      throw new NotImplementedException();
    }
  }
}