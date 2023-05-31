using Microsoft.AspNetCore.Mvc;
using tryitter.Repository;
using tryitter.Models;
using tryitter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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

    [HttpPost]
    [Route("/Login")]
    public IActionResult Login([FromBody]Login model)
    {
      var student = _repository.Login(model.Email, model.Password);

      if (student == null)
      {
        return Unauthorized();
      }

      string token = new TokenGenerator().Generate(student);
      return Ok(token);
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

    [HttpGet("/student/{name}")]
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

    [HttpPut("/student/{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult UpdateStudent(int id, Student studentInfo)
    {
      var getStudent = _repository.GetStudentById(id);
      if (getStudent == null)
        {
            return BadRequest("Student not found!");
        }

      var updatedStudent = _repository.UpdateStudent(getStudent, studentInfo);
      return Ok(updatedStudent);
    }
    
    [HttpDelete("/student/{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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