using Microsoft.AspNetCore.Mvc;
using tryitter.Repository;
using tryitter.Models;

namespace tryitter.Controllers
{
  [ApiController]
  [Route("student")]
  public class StudentController : Controller
  {
    public StudentRepository? _repository;
    public StudentController(StudentRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
      var getAllStudents = _repository.GetStudents();
      return Ok(getAllStudents);
    }

    [HttpPost]
    public IActionResult PostAppointment(Student student)
    {
      _repository.AddStudent(student);
      return Ok();
    }
  }
}