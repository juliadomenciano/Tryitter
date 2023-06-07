using System.ComponentModel.DataAnnotations;

namespace tryitter.Models
{
  public class StudentResponse
  {
    public int StudentId { get; set; }
    public string? Name { get; set; }
    public string? Status { get; set; }
    public int ModuleId { get; set; }

  }
}