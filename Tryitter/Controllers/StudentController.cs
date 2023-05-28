using Microsoft.AspNetCore.Mvc;
using tryitter.Repository;
using tryitter.Models;
using Microsoft.AspNetCore.Authorization;

namespace tryitter.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class StudentController : Controller
  {
    private readonly StudentRepository _repository;
    public StudentController(StudentRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Get()
    {
      var getAllStudents = _repository.GetStudents();
      return Ok(getAllStudents);
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult PostAppointment(Student student)
    {
      _repository.AddStudent(student);
      return Ok();
    }
  }
}