using Microsoft.AspNetCore.Mvc;
using tryitter.Repository;
using tryitter.Models;
using Microsoft.AspNetCore.Authorization;

namespace tryitter.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ModuleController : Controller
  {
    private readonly ModuleRepository _repository;
    public ModuleController(ModuleRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Get()
    {
      var getAllModules = _repository.GetModules();
      return Ok(getAllModules);
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult PostAppointment(Module module)
    {
      _repository.AddModule(module);
      return Ok();
    }
  }
}