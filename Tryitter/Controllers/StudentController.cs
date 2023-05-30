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
    public IActionResult Login()
    {
      var getAllStudents = _repository.GetStudents();
      return Ok(getAllStudents);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetStudents()
    {
      var getAllStudents = _repository.GetStudents();
      return Ok(getAllStudents);
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult CreateStudent(Student student)
    {
      _repository.AddStudent(student);
      return Ok();
    }

    [HttpGet("/{name}")]
    [AllowAnonymous]
    public IActionResult GetStudentByName(string name)
    {
      if (string.IsNullOrEmpty(name))
        {
            return GetStudents();
        }

      var matchingStudents = _repository.GetStudentByName(name);
      return Ok(matchingStudents);
    }

    [HttpPut("/{id}")]
    [AllowAnonymous]
    public IActionResult UpdateStudent(int id)
    {
      var getStudent = _repository.GetStudentById(id);
      if (getStudent == null)
        {
            return BadRequest("Student not found!");
        }

      _repository.UpdateStudent(getStudent);
      return Ok();
    }
    
    [HttpDelete("/{id}")]
    [AllowAnonymous]
    public IActionResult DeleteStudent(int id)
    {
      var getStudent = _repository.GetStudentById(id);
      if (getStudent == null)
        {
            return BadRequest("Student not found!");
        }

      _repository.DeleteStudent(id);
      return Ok();
    }
  }
}